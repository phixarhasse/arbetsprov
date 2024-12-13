namespace ValidityChecker.Models;

internal interface IValidatable
{
    bool Check();
}

internal class Validator<T> where T : IValidatable
{
    // this solution is not ideal because it throws an exception if the object does not implement IValidatable i.e. won't work for primitive types
    public bool IsValid(T obj)
    {
        if (!(obj is IValidatable))
        {
            throw new ArgumentException("Object must implement IValidatable interface");
        }

        return obj != null && obj.Check();
    }
}