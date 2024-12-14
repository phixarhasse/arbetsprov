using ValidityChecker.Models;
using ValidityChecker.Models.ValidityCheckers;
using ValidityChecker.Util;

namespace ValidityChecker.Application;

public interface IApplication
{
    void Run();
}

public class Application
{
    private readonly ILogger _logger;

    public Application(ILogger logger)
    {
        _logger = logger;
    }

    public void Run()
    {
        _logger.LogInfo("Application started");

        var notNull = new NotNull(_logger);
        var isPersonnummer = new IsPersonnummer(_logger);

        // Run null validity checker
        _logger.LogInfo($"Result from null validating null: {notNull.Check(null)}");
        _logger.LogInfo($"Result from null validating object: {notNull.Check("test")}");

        // Run personnummer validity checker
        _logger.LogInfo($"Result from validating null personnummer: {isPersonnummer.Check(null)}");

        var personnummer = new Personnummer("1234567890-7890");
        _logger.LogInfo($"Result from validating too long personnummer: {isPersonnummer.Check(personnummer.Nr)}");

        personnummer.Nr = "19922023-4135";
        _logger.LogInfo($"Result from validating wrong personnummer: {isPersonnummer.Check(personnummer.Nr)}");

        personnummer.Nr = "19920223-4135";
        _logger.LogInfo($"Result from validating real personnummer: {isPersonnummer.Check(personnummer.Nr)}");

        _logger.LogInfo("Application finished");
    }
}

/*
 * Plan:
 * A generic class called ValidityChecker<T> (that has a single method called IsValid() that returns a boolean?)
 * T represents the type of the object that the class will check for validity
 * The type should implement the IValidatable interface which has a function called Check that returns a boolean
 * ValidityChecker will call the Check function of the object and returns the result
 * This allows ValidityChecker to check the validity of any complexity of object
 * By default, ValidityChecker will check if input is not null
 */