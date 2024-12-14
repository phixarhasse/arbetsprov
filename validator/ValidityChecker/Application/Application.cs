using ValidityChecker.Models;
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

        // Validating null and Personnummer
        var validator = new Validator<Personnummer>();
        _logger.LogInfo($"Result from validating null: {validator.IsValid(null).ToString()}");

        var personnummer = new Personnummer("123456-7890");
        _logger.LogInfo($"Result from validating fake personnummer: {validator.IsValid(personnummer).ToString()}");

        personnummer.Nr = "19920223-4135";
        _logger.LogInfo($"Result from validating real personnummer: {validator.IsValid(personnummer).ToString()}");

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