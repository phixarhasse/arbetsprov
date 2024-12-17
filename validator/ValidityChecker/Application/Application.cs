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
        var isValidLicensePlate = new IsValidLicensePlate(_logger);

        // Run null validity checker
        _logger.LogInfo("========== Null Validity Checker ========");
        _logger.LogInfo($"Result from null validating null: {notNull.Check(null)}");
        _logger.LogInfo($"Result from null validating object: {notNull.Check("test")}");
        _logger.LogInfo("=========================================");
        // Run personnummer validity checker
        _logger.LogInfo("====== Pers. nr. Validity Checker =======");
        _logger.LogInfo($"Result from validating null personnummer: {isPersonnummer.Check(null)}");

        var personnummer = "1234567890-7890";
        _logger.LogInfo($"Result from validating too long personnummer: {isPersonnummer.Check(personnummer)}");

        personnummer = "";
        _logger.LogInfo($"Result from validating wrong personnummer: {isPersonnummer.Check(personnummer)}");

        personnummer = "";
        _logger.LogInfo($"Result from validating real personnummer: {isPersonnummer.Check(personnummer)}");
        _logger.LogInfo("=========================================");

        // Run license plate validity checker
        _logger.LogInfo("==== License plate Validity Checker =====");
        string? licensePlate = null;
        _logger.LogInfo($"Result from validating null license plate: {isValidLicensePlate.Check(licensePlate)}");
        licensePlate = "";
        _logger.LogInfo($"Result from validating empty license plate: {isValidLicensePlate.Check(licensePlate)}");
        licensePlate = "ABCD1234";
        _logger.LogInfo($"Result from validating too long license plate: {isValidLicensePlate.Check(licensePlate)}");
        licensePlate = "ABCDEF";
        _logger.LogInfo($"Result from validating incorrect license plate: {isValidLicensePlate.Check(licensePlate)}");
        licensePlate = "123456";
        _logger.LogInfo($"Result from validating incorrect license plate: {isValidLicensePlate.Check(licensePlate)}");
        licensePlate = "IVC567";
        _logger.LogInfo($"Result from validating license plate with illegal characters: {isValidLicensePlate.Check(licensePlate)}");
        licensePlate = "ABC123";
        _logger.LogInfo($"Result from validating real license plate: {isValidLicensePlate.Check(licensePlate)}");
        licensePlate = "ABC12A";
        _logger.LogInfo($"Result from validating real license plate: {isValidLicensePlate.Check(licensePlate)}");
        licensePlate = "abs12p";
        _logger.LogInfo($"Result from validating real license plate, lower case: {isValidLicensePlate.Check(licensePlate)}");
        _logger.LogInfo("=========================================");

        _logger.LogInfo("Application finished");
    }
}
