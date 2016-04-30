using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace VR2_Klientrakendus.Service
{
    public class BaseService
    {
        private HttpClient _client;
        private string _serviceUrl;


        public BaseService(string serviceUrl)
        {
            this._client = new HttpClient();
            this._client.BaseAddress = new Uri(serviceUrl);
            this._serviceUrl = serviceUrl;

        }

        public async Task<T> GetData<T>(string url)
        {
            //            Task<HttpResponseMessage> result = this._client.GetAsync(url);
            //            //siin on hästi palju tööd
            //            var ret = await result;
            string lol = url;
            HttpResponseMessage resp = await this._client.GetAsync(""); //kui meil on vaja tulemust tagasi saada kirjutame await operaatori ette.
            resp.EnsureSuccessStatusCode();
            return await resp.Content.ReadAsAsync<T>();
        }

        public async Task<T> PostData<T>(T data)
        {
            HttpResponseMessage resp = await this._client.PostAsJsonAsync("", data);
            resp.EnsureSuccessStatusCode();
            return await resp.Content.ReadAsAsync<T>();
        }

        public async Task<T> PutData<T>(T data, int dataId)
        {
            HttpResponseMessage resp = await this._client.PutAsJsonAsync(_serviceUrl + "/" + dataId, data);
            resp.EnsureSuccessStatusCode();
            return await resp.Content.ReadAsAsync<T>();
        }

        public async Task<T> DeleteData<T>(int dataId)
        {
            HttpResponseMessage resp = await this._client.DeleteAsync(_serviceUrl + "/" + dataId);
            resp.EnsureSuccessStatusCode();
            return await resp.Content.ReadAsAsync<T>();
        }
    }
}
