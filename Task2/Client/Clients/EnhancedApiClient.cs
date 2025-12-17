using Client.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Objects.Entities;

namespace Client.Clients
{
    public class EnhancedApiClient
    {
        private readonly IApiClient _client;

        public EnhancedApiClient(IApiClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public Task<IReadOnlyList<SomeEntity>> FindByNameAsync(string part) => _client.GetByFilterAsync(nameHas: part);
        public Task<IReadOnlyList<SomeEntity>> FindByDescriptionAsync(string part) => _client.GetByFilterAsync(descriptionHas: part);
        public Task<IReadOnlyList<SomeEntity>> FindByStatusAsync(SomeEntityStatus status) => _client.GetByFilterAsync(status: status);

        public Task<IReadOnlyList<SomeEntity>> GetActiveAsync() => _client.GetByFilterAsync(status: SomeEntityStatus.Enabled);
        public Task<IReadOnlyList<SomeEntity>> GetInactiveAsync() => _client.GetByFilterAsync(status: SomeEntityStatus.Disabled);
        public Task<IReadOnlyList<SomeEntity>> GetPendingAsync() => _client.GetByFilterAsync(status: SomeEntityStatus.Pending);

        public async Task DeactivateAll()
        {
            var items = (await _client.GetByFilterAsync(status: SomeEntityStatus.Enabled))
                .Concat(await _client.GetByFilterAsync(status: SomeEntityStatus.Pending));

            foreach (var item in items)
            {
                await _client.SetStatusAsync(item.Id, SomeEntityStatus.Disabled);
            }
        }

        public async Task ActivateAll()
        {
            var items = (await _client.GetByFilterAsync(status: SomeEntityStatus.Disabled))
                .Concat(await _client.GetByFilterAsync(status: SomeEntityStatus.Pending));

            foreach (var item in items)
            {
                await _client.SetStatusAsync(item.Id, SomeEntityStatus.Enabled);
            }
        }

        public async Task<IReadOnlyList<SomeEntity>> SearchAsync(
            string? name = null,
            string? description = null,
            SomeEntityStatus? status = null)
        {
            return await _client.GetByFilterAsync(name, description, status);
        }

        public async Task PrintAsync(Func<Task<IReadOnlyList<SomeEntity>>> method)
        {
            var items = await method();
            foreach (var item in items)
            {
                var text = await _client.PrintAsync(item.Id) ?? "[Item not found]";
                Console.WriteLine(text);
            }
        }

        public async Task PrintAsync(Func<Task<SomeEntity?>> method)
        {
            var item = await method();

            if (item is null)
            {
                Console.WriteLine("[Nothing was found]");
                return;
            }

            var text = await _client.PrintAsync(item.Id) ?? "[Item not found]";
            Console.WriteLine(text);
        }

        public async Task PrintAsync(SomeEntity entity)
        {
            var text = await _client.PrintAsync(entity.Id) ?? "[Item not found]";
            Console.WriteLine(text);
        }

        public async Task PrintAllAsync()
        {
            var strings = await _client.PrintManyAsync();
            foreach (var item in strings)
            {
                Console.WriteLine(item);
            }
        }
    }
}
