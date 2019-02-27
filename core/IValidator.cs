namespace DoubleSplit.Core
{
    public interface IValidator<T>
    {
        void Validate(T entity);
    }
}