using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace OnionPattern.DataAccess
{
    public interface IDataServiceAsync
    {
        Task<T> GetAsync<T>(Uri requestUrl);
        Task<string> GetAsyncString(Uri requestUrl);
        Task<Stream> GetAsyncStream(Uri requestUrl);
        Task<T> PostAsync<T>(Uri requestUrl, T content);
        Task<T2> PostAsync<T1, T2>(Uri requestUrl, T1 conten);
        Uri CreateRequestUri(string relativePath, string queryString = "");
        HttpContent CreateHttpContent<T>(T content);
        Task<Stream> GetAsyncStreamHtml(Uri requestUrl);
        void AddHeaders();
    }
}
