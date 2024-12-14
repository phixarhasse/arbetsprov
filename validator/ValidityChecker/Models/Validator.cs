namespace ValidityChecker.Models;

internal interface IValidatable
{
    bool Check(); // this method holds the validation logic implemented by each class requiring validation
}

internal class Validator<T> where T : IValidatable
{
    public bool IsValid(T? obj)
    {
        if (!(obj is IValidatable))
        {
            throw new ArgumentException("Object must implement IValidatable interface");
        }

        return obj != null && obj.Check();
    }
}