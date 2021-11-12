﻿using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpClients;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpResponseLoaders
{
    public class PriceSegmentsResponseLoader : BaseResponseLoader
    {
        private readonly PriceSegmentsClient _client;

        public PriceSegmentsResponseLoader()
        {
            _client = new PriceSegmentsClient();
        }

        public async Task<Stream> GetStreamFromGetCountPriceSegmentsResponseAsync(PriceSegmentsFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetCountPriceSegmentsAsync(filters));
        }

        public async Task<Stream> GetStreamFromGetNamesPriceSegmentsResponseAsync(string searchString)
        {
            return await GetStreamFromResponseAsync(await _client.GetNamesPriceSegmentsAsync(searchString));
        }

        public async Task<Stream> GetStreamFromGetPriceSegmentsResponseAsync(PriceSegmentsFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetPriceSegmentsAsync(filters));
        }

        public async Task<Stream> GetStreamFromGetPriceSegmentsResponseAsync()
        {
            return await GetStreamFromResponseAsync(await _client.GetPriceSegmentsAsync());
        }

        public async Task<Stream> GetStreamFromContainsPriceSegmentResponseAsync(string name, string ruName)
        {
            return await GetStreamFromResponseAsync(await _client.ContainsPriceSegmentAsync(name, ruName));
        }

        public async Task<Stream> GetStreamFromGetPriceSegmentResponseAsync(Guid id)
        {
            return await GetStreamFromResponseAsync(await _client.GetPriceSegmentAsync(id));
        }

        public async Task<Stream> GetStreamFromAddPriceSegmentResponseAsync(PriceSegment priceSegment)
        {
            return await GetStreamFromResponseAsync(await _client.AddPriceSegmentAsync(priceSegment));
        }

        public async Task<Stream> GetStreamFromUpdatePriceSegmentResponseAsync(PriceSegment priceSegment)
        {
            return await GetStreamFromResponseAsync(await _client.UpdatePriceSegmentAsync(priceSegment));
        }

        public async Task<Stream> GetStreamFromDeletePriceSegmentResponseAsync(Guid id)
        {
            return await GetStreamFromResponseAsync(await _client.DeletePriceSegmentAsync(id));
        }
    }
}
