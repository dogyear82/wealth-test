I setup the solution by reusing one of my old projects.  It's laid out using the Hexagonal Architecture pattern.  The project is a simple ASP.NET Core Web API that returns a list of assets on the as of date.  I chose this pattern because I wanted to simulate an actual system that I would build in a real-world scenario and the Hexagonal pattern provides is great for separating concerns.

I decided to try my hand at graphql for the API layer.  I have never used it before and wanted to see how it works.  I found it to be a bit more complex than REST in setup and I was unable to get it to return back the desired output.  I will need to spend more time with it to fully understand it.

Due to time constraints, I was unable to implement any Authentication or Authorization.  I also didn't implement any passwords for the database either. I'm also not sure if I've extracted all the values form teh asset json into C# classes.

I have included a shell file that will spin up everything so running the solution should be as simple as running  "./load_and_up.sh" in the scripts folder.
