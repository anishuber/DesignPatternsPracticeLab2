using Client.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using Task2.Objects.Entities;

namespace Client.Clients
{
    public class ApiClient : IApiClient
    {
        private readonly HttpClient _http;

        public ApiClient(HttpClient http)
        {
            _http = http ?? throw new ArgumentNullException(nameof(http));
        }

        public async Task ActivateAsync(Guid id)
        {
            var response = await _http.PostAsync($"api/SomeEntity/activate/{id}", null);
            response.EnsureSuccessStatusCode();
        }

        public async Task<SomeEntity> CreateAsync(SomeEntity entity)
        {
            var response = await _http.PostAsJsonAsync($"api/SomeEntity/create", entity);
            response.EnsureSuccessStatusCode();
            return (await response.Content.ReadFromJsonAsync<SomeEntity>())!;
        }

        public async Task DeactivateAsync(Guid id)
        {
            var response = await _http.PostAsync($"api/SomeEntity/deactivate/{id}", null);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(Guid id)
        {
            var response = await _http.DeleteAsync($"api/SomeEntity/delete/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteManyAsync()
        {
            var response = await _http.DeleteAsync("api/SomeEntity/delete-many/");
            response.EnsureSuccessStatusCode();
        }

        public async Task<IReadOnlyList<SomeEntity>> GetByFilterAsync(
            string? nameHas = null,
            string? descriptionHas = null,
            SomeEntityStatus? status = null)
        {
            var query = new List<string>();
            if (!string.IsNullOrWhiteSpace(nameHas))
            {
                query.Add($"nameHas={Uri.EscapeDataString(nameHas)}");
            }
            if (!string.IsNullOrWhiteSpace(descriptionHas))
            {
                query.Add($"descriptionHas={Uri.EscapeDataString(descriptionHas)}");
            }
            if (status.HasValue)
            {
                query.Add($"status={(int)status.Value}");
            }

            var url = "api/SomeEntity/get-by-filter";
            if (query.Count != 0)
            {
                url += "?" + string.Join("&", query);
            }

            var response = await _http.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var items = await response.Content.ReadFromJsonAsync<List<SomeEntity>>();
            return items ?? [];
        }

        public async Task<IReadOnlyList<SomeEntity>> GetManyAsync()
        {
            var response = await _http.GetAsync("api/SomeEntity/get-many/");
            response.EnsureSuccessStatusCode();

            var items = await response.Content.ReadFromJsonAsync<List<SomeEntity>>();
            return items ?? [];
        }

        public async Task<SomeEntity?> GetOneAsync(Guid id)
        {
            var response = await _http.GetAsync($"api/SomeEntity/get-one/{id}");

            if (response.StatusCode.Equals(HttpStatusCode.NotFound))
            {
                return null;
            }

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<SomeEntity>();
        }

        public async Task<string?> PrintAsync(Guid id)
        {
            var response = await _http.GetAsync($"api/SomeEntity/print/{id}");
            if (response.StatusCode.Equals(HttpStatusCode.NotFound))
            {
                return null;
            }

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<IReadOnlyList<string>> PrintManyAsync()
        {
            var response = await _http.GetAsync($"api/SomeEntity/print-many");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<IReadOnlyList<string>>() ?? [];
        }

        public async Task SetStatusAsync(Guid id, SomeEntityStatus status)
        {
            var response = await _http.PostAsJsonAsync($"api/SomeEntity/set-status/{id}", status);
            response.EnsureSuccessStatusCode();
        }

        public async Task<SomeEntity?> UpdateAsync(Guid id, SomeEntity entity)
        {
            var response = await _http.PutAsJsonAsync($"api/SomeEntity/update/{id}", entity);
            if (response.StatusCode.Equals(HttpStatusCode.NotFound))
            {
                return null;
            }

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<SomeEntity>();
        }
    }
}
