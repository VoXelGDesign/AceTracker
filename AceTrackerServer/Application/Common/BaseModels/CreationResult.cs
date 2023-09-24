using Application.Common.Interfaces;

namespace Application.Common.BaseModels
{
    public class CreationResult<T> : ICreationResult<T>
    {
        public T Obj;
        public bool IsSuccessful { get; }

        public CreationResult()
        {
            
        }

        public CreationResult(T obj, bool isSuccessful)
        {
            this.Obj = obj;
            IsSuccessful = isSuccessful;
        }

    }
}
