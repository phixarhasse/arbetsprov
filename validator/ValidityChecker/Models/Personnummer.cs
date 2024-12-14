namespace ValidityChecker.Models;

internal class Personnummer : IValidatable
{
    public string Nr { get; set; } = string.Empty;

    public Personnummer(string nummer)
    {
        Nr = nummer;
    }

    public bool Check()
    {
        if (string.IsNullOrEmpty(Nr))
        {
            // TODO: logging
            return false;
        }

        if (Nr.Length > 13 || Nr.Length < 12)
        {
            // TODO: logging
            return false;
        }

        var withoutHyphen = Nr.Replace("-", string.Empty);
        if (!withoutHyphen.All(char.IsDigit))
        {
            // TODO: logging
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
        return sum % 10 == 0;
    }
}

