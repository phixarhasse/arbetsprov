using System.Text.RegularExpressions;
using ValidityChecker.Util;

namespace ValidityChecker.Models.ValidityCheckers;

internal class IsValidLicensePlate : IValidityCheck
{
    private readonly ILogger _logger;

    public IsValidLicensePlate(ILogger logger)
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

        if (input.Length != 6)
        {
            _logger.LogError("License plate number must be 6 characters long");
            return false;
        }

        // Swedish license plate format, excluded letters in standard plates are I, V, Q, Å, Ä, Ö
        // credit to https://github.com/jop-io/js-regex
        string pattern = @"^[A-HJ-PR-UW-Z]{3}[0-9]{2}[A-HJ-PR-UW-Z0-9]{1}$";
        if (!Regex.IsMatch(input, pattern))
        {
            _logger.LogError("License plate number not in correct format");
            return false;
        }

        return true;
    }
}
