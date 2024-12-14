using ValidityChecker.Util;

namespace ValidityChecker.Models.ValidityCheckers;
internal class IsPersonnummer : IValidityCheck
{
    private readonly ILogger _logger;

    public IsPersonnummer(ILogger logger)
    {
        _logger = logger;
    }

    public bool Check(string? persNr)
    {
        if (string.IsNullOrEmpty(persNr))
        {
            _logger.LogError("Personnummer cannot be null or empty");
            return false;
        }

        var withoutHyphen = persNr.Replace("-", string.Empty);
        if (withoutHyphen.Length != 12)
        {
            _logger.LogError("Personnummer has to have 12 digits");
            return false;
        }

        if (!withoutHyphen.All(char.IsDigit))
        {
            _logger.LogError("Personnummer may only contain digits and hyphen");
            return false;
        }

        return LuhnAlgorithmVerification(persNr);
    }

    private bool LuhnAlgorithmVerification(string input)
    {
        // format
        var shortened = input.Substring(2, input.Length - 2).Replace("-", string.Empty);
        // split
        var digits = shortened.ToCharArray();

        // calculate each digit's result
        // original algorithm calls for starting from the right
        int multiplier = 1;
        int[] results = new int[digits.Length];
        foreach (var digit in digits.Reverse())
        {
            var result = int.Parse(digit.ToString()) * multiplier;
            if (result >= 10)
            {
                result = 1 + (result % 10); // add the two digits together
            }
            results.Append(result);
            multiplier = multiplier == 1 ? 2 : 1;
        }

        // sum all results
        var sum = results.Sum();
        // if sum is divisible by 10, the personnummer is valid
        if (sum % 10 == 0)
        {
            return true;
        }
        else
        {
            _logger.LogError("Personnummer failed Luhn algorithm verification");
            return false;
        }
    }
}
