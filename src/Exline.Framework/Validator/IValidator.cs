namespace Exline.Framework.Validator
{
    public interface IValidator
    {
        ValidatorResult Valid(object obj);
    }
}