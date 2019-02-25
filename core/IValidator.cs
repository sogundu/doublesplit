namespace alg.core
{
    public interface IValidator<T>
    {
        void Validate(T entity);
    }
}