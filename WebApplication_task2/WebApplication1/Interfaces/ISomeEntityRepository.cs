using Task2.EntityObjects;

namespace Task2.Interfaces
{
    public interface ISomeEntityRepository
    {
        SomeEntity Create(SomeEntity entity);
        SomeEntity? Update(SomeEntity entity);
        SomeEntity? GetOne(Guid id);
        IEnumerable<SomeEntity> GetMany();
        IEnumerable<SomeEntity> GetByFilter(Func<SomeEntity, bool> filter);
        void Delete(Guid id);
        void DeleteMany();
        void SetStatus(Guid id, SomeEntityStatus status);
    }
}
