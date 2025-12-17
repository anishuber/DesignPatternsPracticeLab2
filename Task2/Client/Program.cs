using Client.Clients;
using Task2.Objects.Entities;
using System.Net.Http.Json;

namespace Client
{
    internal static class Program
    {
        async static Task Main(string[] args)
        {
            var http = new HttpClient { BaseAddress = new Uri("https://localhost:7154/") };
            var api = new ApiClient(http);
            var enhancedApi = new EnhancedApiClient(api);
            var testEntity = await api.CreateAsync(new SomeEntity { 
                Id = Guid.NewGuid(), 
                Name = "Test", Description = "Test", 
                Status = SomeEntityStatus.Enabled });

            Console.WriteLine("=== 1. Get requests ===");
            await enhancedApi.PrintAsync(() => api.GetOneAsync(testEntity.Id));
            await enhancedApi.PrintAsync(() => api.GetManyAsync());
            await enhancedApi.PrintAsync(() => api.GetByFilterAsync(status: SomeEntityStatus.Enabled));

            Console.WriteLine("=== 2. Post requests ===");
            var createdEntity = await api.CreateAsync(new SomeEntity { Name = "I", Description = "Am", Status = SomeEntityStatus.Disabled });
            await enhancedApi.PrintAsync(createdEntity);
            await api.ActivateAsync(createdEntity.Id);
            await enhancedApi.PrintAsync(createdEntity);
            await api.DeactivateAsync(createdEntity.Id);
            await enhancedApi.PrintAsync(createdEntity);
            await api.SetStatusAsync(createdEntity.Id, SomeEntityStatus.Pending);
            await enhancedApi.PrintAsync(createdEntity);

            Console.WriteLine("=== 3. Put requests ===");
            var updated = await api.UpdateAsync(createdEntity.Id, new SomeEntity { Name = "You", Description = "Are" });
            await enhancedApi.PrintAsync(updated!);

            Console.WriteLine("=== 4. Delete requests ===");
            await api.DeleteAsync(createdEntity.Id);
            await enhancedApi.PrintAsync(createdEntity);

            Console.WriteLine("=== 5. Enhanced api requests ===");
            await enhancedApi.PrintAsync(() => enhancedApi.SearchAsync(name: "o"));
            await enhancedApi.PrintAsync(() => enhancedApi.FindByStatusAsync(status: SomeEntityStatus.Enabled));
            await enhancedApi.PrintAsync(() => enhancedApi.GetActiveAsync());

            Console.WriteLine("=== 6. Image entity requests ===");
            await http.PostAsJsonAsync($"api/SomeImageEntity/set-image/{testEntity.Id}", new Uri("http://aaa.com/aaa.png"));
            var testImage = await http.GetFromJsonAsync<SomeImageEntity>($"api/SomeImageEntity/get-image/{testEntity.Id}");
            Console.WriteLine($"[{testImage!.Id}] {testImage.Name} ({testImage.Status}) - {testImage.Description} | ImageUrl={testImage.ImageUrl}");
            var imageList = await http.GetFromJsonAsync<List<SomeImageEntity>>($"api/SomeImageEntity/get-entities-by-filter?status={(int)SomeEntityStatus.Enabled}");
            foreach (var i in imageList!)
            {
                Console.WriteLine($"[{i.Id}] {i.Name} ({i.Status}) - {i.Description} | ImageUrl={i.ImageUrl}");
            }
        }
    }
}
