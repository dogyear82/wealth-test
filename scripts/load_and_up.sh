#!/usr/bin/env bash
set -euo pipefail

REPO_ROOT_DIR="$(cd "$(dirname "$0")/.." && pwd)"
DATA_FILE_REL="Wealth.Api/Data/assets.json"
DATA_FILE_PATH="$REPO_ROOT_DIR/$DATA_FILE_REL"
DB_NAME="wealth"
COLL_NAME="asset_records"

if ! command -v docker >/dev/null 2>&1; then
  echo "Docker is required. Please install Docker Desktop and retry." >&2
  exit 1
fi

if ! command -v docker compose >/dev/null 2>&1; then
  echo "Docker Compose v2 is required. Update Docker Desktop or install compose plugin." >&2
  exit 1
fi

if [ ! -f "$DATA_FILE_PATH" ]; then
  echo "Dataset not found at $DATA_FILE_REL. Please provide assets.json and retry." >&2
  exit 1
fi

echo "Starting MongoDB only..."
docker compose up -d mongo

echo "Waiting for MongoDB to be healthy..."
for i in {1..60}; do
  STATUS=$(docker compose ps -q mongo | xargs -r docker inspect -f '{{.State.Health.Status}}' || echo "")
  if [ "$STATUS" = "healthy" ]; then
    break
  fi
  sleep 1
done

if [ "$STATUS" != "healthy" ]; then
  echo "MongoDB did not become healthy in time." >&2
  exit 1
fi

echo "Checking if collection $DB_NAME.$COLL_NAME has data..."
COUNT=$(docker compose exec -T mongo sh -lc "mongosh --quiet --eval \"const d=db.getSiblingDB('$DB_NAME'); const infos=d.getCollectionInfos({name:'$COLL_NAME'}); const exists=infos.length>0; const c=exists? d.$COLL_NAME.countDocuments():0; print(c);\"" | tr -d '\r')

if [ -z "$COUNT" ]; then
  echo "Failed to query MongoDB collection count." >&2
  exit 1
fi

if [ "$COUNT" -gt 0 ]; then
  echo "Collection already has $COUNT documents. Skipping import."
else
  echo "Importing dataset into $DB_NAME.$COLL_NAME ..."
  docker compose exec -T mongo sh -lc "mongoimport --db $DB_NAME --collection $COLL_NAME --file /imports/assets.json --jsonArray --mode=upsert --upsertFields assetId,balanceAsOf"
  echo "Import complete."
fi

echo "Starting API..."
docker compose up -d api

echo "Done. GraphQL at http://localhost:8080/graphql"

