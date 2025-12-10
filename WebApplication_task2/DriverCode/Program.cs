using System.Net.Http.Json;
using Task2;
using Task2.Clients;
using Task2.EntityObjects;
using Task2.Interfaces;

namespace DriverCode
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var webApp = BuildApp.BuildWebApplication(args);
            var webTask = webApp.RunAsync();

            var baseUrl = webApp.Urls.First();
            using var http = new HttpClient { BaseAddress = new Uri(baseUrl) };

            ApiClient apiClient = new ApiClient(http);
            var enhancedApiClient = new EnhancedApiClient(apiClient);

            Console.WriteLine("===== Get all entities =====");
            await enhancedApiClient.PrintAsync(() => apiClient.GetManyAsync());
            Console.WriteLine("===== Get only active entities =====");
            await enhancedApiClient.PrintAsync(() => enhancedApiClient.GetActiveAsync());

            var newEntity = new SomeEntity
            {
                Name = "My damn entity",
                Description = "I got acute scoliosis and a severe mental breakdown from sitting at my desk this long and now I'm ",
                Status = SomeEntityStatus.Disabled,
            };

            Console.WriteLine("===== Create entity =====");
            var createdEntity = await apiClient.CreateAsync(newEntity);

            createdEntity.Status = SomeEntityStatus.Pending;
            createdEntity.Description = "Kill me please I have NEVER done this in my entire LIFE";
            await enhancedApiClient.PrintAsync(createdEntity);

            Console.WriteLine("===== Update entity =====");
            await apiClient.UpdateAsync(createdEntity.Id, createdEntity);
            await enhancedApiClient.PrintAsync(createdEntity);

            Console.WriteLine("===== All entities after activation =====");
            await enhancedApiClient.ActivateAll();
            await enhancedApiClient.PrintAllAsync();

            Console.WriteLine("===== Found by filter entities =====");
            await enhancedApiClient.PrintAsync(() => enhancedApiClient.SearchAsync(description: "kill"));
            await enhancedApiClient.PrintAsync(() => enhancedApiClient.SearchAsync(name: "a", status: SomeEntityStatus.Pending));

            var imageUrl = new Uri("https://aaaaaaaa.com/images/assync.png");


            //Add prints here or client idk
            Console.WriteLine("===== Entity with set image: =====");
            var setImageResponse = await http.PostAsJsonAsync($"api/SomeImageEntity/set-image/{createdEntity.Id}", imageUrl);
            setImageResponse.EnsureSuccessStatusCode();

            var imageEntity = await http.GetFromJsonAsync<SomeImageEntity>($"api/SomeImageEntity/get-image/{createdEntity.Id}");


            Console.WriteLine("===== Filtered image entities: =====");
            var filteredEntities = await http.GetFromJsonAsync<List<SomeImageEntity>>("api/SomeImageEntity/get-entities-by-filter?nameHas=s");
            foreach (var e in filteredEntities!)
            {
                Console.WriteLine($"[{e.Id}] {e.Name} {e.Description} {e.Status} | {e.ImageUrl}");
            }

            await webApp.StopAsync();
            await webTask;

            Console.WriteLine("The examples are above. Press any key to finish...");
            Console.ReadKey();
        }
    }
}
