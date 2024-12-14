using ValidityChecker.Util;

namespace ValidityChecker.Models;

internal class Personnummer : IValidatable
{
    private readonly ILogger _logger;

    public string Nr { get; set; } = string.Empty;

    public Personnummer(ILogger logger, string nummer)
    {
        _logger = logger;
        Nr = nummer;
    }

    public bool Check()
    {
        if (string.IsNullOrEmpty(Nr))
        {
            _logger.LogError("Personnummer is null or empty");
            return false;
        }

        var withoutHyphen = Nr.Replace("-", string.Empty);
        if (withoutHyphen.Length != 12)
        {
            _logger.LogError("Personnummer has to be 12 digits");
            return false;
        }

        if (!withoutHyphen.All(char.IsDigit))
        {
            _logger.LogError("Personnummer may only contain digits and hyphen");
            return false;
        }

        return LuhnAlgorithmVerification();
    }

    private bool LuhnAlgorithmVerification()
    {
        // format
        var shortened = Nr.Substring(2, Nr.Length - 2).Replace("-", string.Empty);
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
        if(sum % 10 == 0)
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

