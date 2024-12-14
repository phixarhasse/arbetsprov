using ValidityChecker.Util;

namespace ValidityChecker.Models.ValidityCheckers;
internal class NotNull : IValidityCheck
{
    private readonly ILogger _logger;

    public NotNull(ILogger logger)
    {
        _logger = logger;
    }

    public bool Check(string? input)
    {
        if (input is null)
        {
            _logger.LogError("Input is null");
            return false;
        }

        return true;
    }
}
