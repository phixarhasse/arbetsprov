using ValidityChecker.Application;
using ValidityChecker.Util;

ILogger consoleLogger = new ConsoleLogger();
var app = new Application(consoleLogger);
app.Run();

