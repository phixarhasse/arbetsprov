using ValidityChecker.Util;

namespace ValidityChecker.Models.ValidityCheckers;
internal class NotNull : IValidityCheck
{
    private readonly ILogger _logger;
    private readonly object _value;

    public NotNull(ILogger logger, string value)
    {
        _logger = logger;
        _value = value;
    }

    public bool Check()
    {
        if (_value is null)
        {
            _logger.LogError("Value is null");
            return false;
        }

        return true;
    }
}
