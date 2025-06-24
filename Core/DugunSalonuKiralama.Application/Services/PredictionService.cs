﻿using DugunSalonuKiralama.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DugunSalonuKiralama.Application.Services
{
    public class PredictionService
    {
        private readonly HttpClient _httpClient;

        public PredictionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
       
        public async Task<double> PredictAsync(double[] features)
        {
            var request = new
            {
                capacity = features[0],
                location= features[1],
                food_service = features[2],
                Cookie_service = features[3],
                Alcohol_services = features[4]
            
            };

            var response = await _httpClient.PostAsJsonAsync("http://127.0.0.1:5000/predict", request);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<PredictionResponse>();
            return result.PredictedPrice;
        }

    }
}
