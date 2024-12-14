namespace ValidityChecker.Models;

internal class Personnummer
{
    public string Nr { get; set; } = string.Empty;

    public Personnummer(string nummer)
    {
        Nr = nummer;
    }

}

