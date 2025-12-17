using Server.Interfaces;
using Task2.Objects.Entities;

namespace Server.Data
{
    public class SomeEntityRepository : ISomeEntityRepository
    {
        private readonly Dictionary<Guid, SomeEntity> _storage = new()
        {
            {
                Guid.Parse("f1a7bb3f-6f4e-4a43-8d71-0a7f90cb95ea"),
                new SomeEntity
                {
                    Id = Guid.Parse("f1a7bb3f-6f4e-4a43-8d71-0a7f90cb95ea"),
                    Name = "First",
                    Description = "First test entity.",
                    Status = SomeEntityStatus.Enabled
                }
            },
            {
                Guid.Parse("58a02eb7-c18a-4b16-a5e7-812fd5b2586f"),
                new SomeEntity
                {
                    Id = Guid.Parse("58a02eb7-c18a-4b16-a5e7-812fd5b2586f"),
                    Name = "Second",
                    Description = "Second test entity.",
                    Status = SomeEntityStatus.Disabled
                }
            },
            {
            Guid.Parse("c0c19189-d362-4ad8-81e3-552967f440d8"),
                new SomeEntity
                {
                    Id = Guid.Parse("c0c19189-d362-4ad8-81e3-552967f440d8"),
                    Name = "Third",
                    Description = "Third test entity.",
                    Status = SomeEntityStatus.Pending
                }
            },
            {
            Guid.Parse("1b86e94e-6cb2-4ab4-b05e-8e1ee5d8ae54"),
                new SomeEntity
                {
                    Id = Guid.Parse("1b86e94e-6cb2-4ab4-b05e-8e1ee5d8ae54"),
                    Name = "Fourth",
                    Description = "Fourth test entity.",
                    Status = SomeEntityStatus.Enabled
                }
            }
        };

        public SomeEntity Create(SomeEntity entity)
        {
           entity.Id = entity.Id == Guid.Empty ? Guid.NewGuid() : entity.Id;
            _storage[entity.Id] = entity;
            return entity;
        }

        public void Delete(Guid id) => _storage.Remove(id);

        public void DeleteMany() => _storage.Clear();

        public SomeEntity? GetOne(Guid id) => _storage.TryGetValue(id, out var entity) ? entity : null;

        public IEnumerable<SomeEntity> GetMany() => _storage.Values;

        public IEnumerable<SomeEntity> GetByFilter(Func<SomeEntity, bool> filter) => _storage.Values.Where(filter);

        public void SetStatus(Guid id, SomeEntityStatus status)
        {
            if (_storage.TryGetValue(id, out var entity))
            {
                entity.Status = status;
            }
        }

        public SomeEntity? Update(SomeEntity entity)
        {
            if (!_storage.ContainsKey(entity.Id))
            {
                return null;
            }

            _storage[entity.Id] = entity;
            return entity;
        }
    }
}
