using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OnionPattern.DataAccess
{
    public class DataServiceAsync : IDataServiceAsync
    {
        private readonly HttpClient _httpClient;
        private Uri BaseEndpoint { get; set; }

        public DataServiceAsync(Uri baseEndpoint)
        {
            if (baseEndpoint == null)
            {
                throw new ArgumentNullException("baseEndpoint");
            }
            BaseEndpoint = baseEndpoint;

            _httpClient = new HttpClient();

        }

        public async Task<T> GetAsync<T>(Uri requestUrl)
        {


            AddHeaders();
            try
            {
                var response = await _httpClient.GetAsync(requestUrl, HttpCompletionOption.ResponseHeadersRead);
                var json = JsonConvert.SerializeObject(response);

                response.EnsureSuccessStatusCode();
                var data = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<T>(data);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }

        public async Task<Stream> GetAsyncStream(Uri requestUrl)
        {




            AddHeaders();
            try
            {
                var response = await _httpClient.GetAsync(requestUrl, HttpCompletionOption.ResponseHeadersRead);
                var json = JsonConvert.SerializeObject(response);


                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStreamAsync(); ;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public async Task<Stream> GetAsyncStreamHtml(Uri requestUrl)
        {

            AddHeaders();

            try
            {
                var response = await _httpClient.GetAsync(requestUrl);
                var json = JsonConvert.SerializeObject(response);

                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStreamAsync();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }



        }

        public async Task<string> GetAsyncString(Uri requestUrl)
        {


            AddHeaders();
            try
            {
                var response = await _httpClient.GetAsync(requestUrl, HttpCompletionOption.ResponseHeadersRead);
                var json = JsonConvert.SerializeObject(response);

                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
        public async Task<T> PostAsync<T>(Uri requestUrl, T content)
        {


            AddHeaders();


            try
            {
                var response = await _httpClient.PostAsync(requestUrl.ToString(), CreateHttpContent<T>(content));
                var json = JsonConvert.SerializeObject(response);
                var jsoncontent = JsonConvert.SerializeObject(content);

                response.EnsureSuccessStatusCode();
                var data = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<T>(data);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }


        public async Task<T2> PostAsync<T1, T2>(Uri requestUrl, T1 content)
        {


            AddHeaders();

            try
            {
                var response = await _httpClient.PostAsync(requestUrl.ToString(), CreateHttpContent<T1>(content));
                var json = JsonConvert.SerializeObject(response);
                var jsoncontent = JsonConvert.SerializeObject(content);

                response.EnsureSuccessStatusCode();
                var data = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<T2>(data);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public Uri CreateRequestUri(string relativePath, string queryString = "")
        {
            var endpoint = new Uri(BaseEndpoint, relativePath);
            var uriBuilder = new UriBuilder(endpoint);
            uriBuilder.Query = queryString;
            return uriBuilder.Uri;
        }


        public HttpContent CreateHttpContent<T>(T content)
        {
            var json = JsonConvert.SerializeObject(content, MicrosoftDateFormatSettings);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        private static JsonSerializerSettings MicrosoftDateFormatSettings
        {
            get
            {
                return new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
                };
            }
        }

        public void AddHeaders()
        {
            _httpClient.DefaultRequestHeaders.Remove("userIP");
            _httpClient.DefaultRequestHeaders.Add("userIP", "192.168.14.183");
        }

    }
}
