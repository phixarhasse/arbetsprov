namespace ValidityChecker.Models;

internal interface IValidatable
{
    bool Check();
}

internal class Validator<T> where T : IValidatable
{
    public bool IsValid(T? obj)
    {
        if (obj is null)
        {
            return false;
        }

        if (!(obj is IValidatable))
        {
            throw new ArgumentException("Object must implement IValidatable interface");
        }

        return obj.Check();
    }
}