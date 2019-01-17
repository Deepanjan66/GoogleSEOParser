﻿using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SEOParser.Helpers
{
    public class SEOClient
    {

        /// <summary>
        /// Performs a get request with the provided url
        /// </summary>
        /// <returns>Returns the page source obtained from performing
        /// the get request</returns>
        /// <param name="url">URL.</param>
        public string getRequest(string url)
        { 
            return GetAsync(url).Result;
        }

        // Async method for performing async requests
        private async Task<string> GetAsync(string uri)
        {
            var httpClient = new HttpClient();
            var content = await httpClient.GetStringAsync(uri);
            return await Task.Run(() => content);
        }

    }
}
