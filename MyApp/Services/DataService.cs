using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MonkeyCache.FileStore;
using MyApp.Models;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace MyApp.Services
{
    public class DataService : IDataService
    {
        //public async Task<IEnumerable<Item>> GetItems()
        //{
            //try
            //{
            //    var url = "https://gist.githubusercontent.com/erni-ph-mobile-team/c5b401c4fad718da9038669250baff06/raw/7e390e8aa3f7da4c35b65b493fcbfea3da55eac9/test.json";

            //    var httpClient = new HttpClient();
            //    var response = await httpClient.GetAsync(url);

            //    if (!response.IsSuccessStatusCode)
            //    {
            //        return Enumerable.Empty<Item>();
            //    }

            //    var json = await response.Content.ReadAsStringAsync();
            //    var list = JsonConvert.DeserializeObject<IEnumerable<Item>>(json);

            //    return list;
            //}
            //catch (Exception ex)
            //{
            //    Debug.WriteLine(ex);
            //    return Enumerable.Empty<Item>();
            //}

            //var url = @"https://en.wikipedia.org/w/api.php?action=opensearch&search=designpattern&limit=20&namespace=0&format=json";
            //var httpClient = new HttpClient();
            //var response = await httpClient.GetAsync(url);
            //var json = await response.Content.ReadAsStringAsync();
            //var list = JsonConvert.DeserializeObject<dynamic>(json);

            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //}

            //return list;
        //}

        public Task<IEnumerable<Item>> GetItems() =>
            GetAsync<IEnumerable<Item>>("https://gist.githubusercontent.com/erni-ph-mobile-team/c5b401c4fad718da9038669250baff06/raw/7e390e8aa3f7da4c35b65b493fcbfea3da55eac9/test.json", "get-items");

        public async Task<T> GetAsync<T>(string url, string key, int mins = 1, bool forceRefresh = false)
        {
            var json = string.Empty;
            var client = new HttpClient();

            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
                json = Barrel.Current.Get<string>(key);
            else if (!forceRefresh && !Barrel.Current.IsExpired(key))
                json = Barrel.Current.Get<string>(key);

            try
            {
                if (string.IsNullOrWhiteSpace(json))
                {
                    json = await client.GetStringAsync(url);

                    Barrel.Current.Add(key, json, TimeSpan.FromMinutes(mins));
                }
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw ex;
            }
        }
    }
}
