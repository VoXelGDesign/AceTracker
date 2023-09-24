using Application.Common.BaseModels;

namespace Application.Common.Interfaces
{
    public interface ICreationResult<T>
    {
        public CreationResult<T> IsSuccessful(T obj) 
            => new CreationResult<T>(obj, true);

         public CreationResult<T> IsUnsuccessful(T obj)
            => new CreationResult<T>(obj, false);
    }
}
