## Validity checker

This is a simple console app which can be run either in an IDE such as VS or using dotnet runtime commands.
It's programmed to run a few validity checks: null, Swedish personal ID number and Swedish license plates.
`Program.cs` acts as the entry point and start for dependency injection while logic for running the app is located in `Application\Application.cs`.

## Developers notes

The task was straightforward with an interesting quirk in implementing the Luhn algorithm for checking Swedish personal ID numbers.
First attempt included a solution with a generic class, where the class requiring validition was respoinsible for implementing a Check function.
This, however, did not prove flexible enough and to further separate concerns of responsibility another approach was required (and, honestly, a solution probably closer to what the task creator had in mind).
First attempt is kept in the `Validator.cs` file as discussion material.
In the second attempt, an interface for a validity checker class (`Models\ValidityCheckers\IValidityCheck.cs`) was added and then specific checkers can be implemented as classes inheriting this interface.
Pros of this solution was a further separation of concerns and increased flexibility as each checker class can hold the logic required to perform its specific vailidation.
All checkers implementation can be found in the `Models\ValidityCheckers` folder.

Potential improvements include unit testing - this was left out for time reasons. Code feels naked without them.
Further on, allowing validity checkers to be chained together in the style of LINQ by returning a ValidityChecker at the end of each validity check would be a nice touch.
This makes the code easier to follow, less clustered and you can even further increase the separation of concerns.
