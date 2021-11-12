﻿using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpClients
{
    public class SectionsClient : BaseHttpClient
    {
        public SectionsClient() : base("sections/")
        {

        }

        public async Task<HttpResponseMessage> GetCountSectionsAsync(SectionsFilters filters)
        {
            return await _client.PostAsync("count", new StringContent(JsonConvert.SerializeObject(filters),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetNamesSectionsAsync(string searchString)
        {
            return await _client.PostAsync("names", new StringContent(JsonConvert.SerializeObject(searchString),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetSectionsAsync()
        {
            return await _client.GetAsync("");
        }

        public async Task<HttpResponseMessage> GetSectionsAsync(SectionsFilters filters)
        {
            return await _client.PostAsync("", new StringContent(JsonConvert.SerializeObject(filters),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> ContainsSectionAsync(string name, string ruName)
        {
            return await _client.GetAsync($"contains?name={name}&ruName={ruName}");
        }

        public async Task<HttpResponseMessage> GetSectionAsync(Guid id)
        {
            return await _client.GetAsync($"{id}");
        }

        public async Task<HttpResponseMessage> AddSectionAsync(Section section)
        {
            return await _client.PostAsync("save", new StringContent(JsonConvert.SerializeObject(section),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> UpdateSectionAsync(Section section)
        {
            return await _client.PutAsync("save", new StringContent(JsonConvert.SerializeObject(section),
                Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> DeleteSectionAsync(Guid id)
        {
            return await _client.DeleteAsync($"{id}");
        }
    }
}
