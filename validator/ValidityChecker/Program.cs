// See https://aka.ms/new-console-template for more information

using ValidityChecker.Application;
using ValidityChecker.Util;

ILogger consoleLogger = new ConsoleLogger();
var app = new Application(consoleLogger);
app.Run();

