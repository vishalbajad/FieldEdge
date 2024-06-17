using FieldEdge.API.HTTP.Connector.Interfaces;
using FieldEdge.API.Object_Provider;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace FieldEdge.API.HTTP.Connector.Repositories
{
    /// <summary>
    /// Customer Repository
    /// </summary>
    public class HttpRepository<T> : IHttpRepository<T> where T : class
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="httpClient"></param>
        public HttpRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Get all details
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<T>> Get(string url)
        {
            var list = await _httpClient.GetFromJsonAsync<IEnumerable<T>>(url);
            return list;
        }

        /// <summary>
        /// Get single records
        /// </summary>
        /// <returns></returns>
        public async Task<T> GetSingle(string url)
        {
            var singleRecord = await _httpClient.GetFromJsonAsync<T>(url);
            return singleRecord;
        }

        /// <summary>
        /// Create new Record
        /// </summary>
        /// <param name="newRecord"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> Add(string url, T newRecord)
        {
            var response = await _httpClient.PostAsJsonAsync(url, newRecord);
            return response;
        }
        /// <summary>
        /// Update details
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateRecord"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> Update(string url, T updateRecord)
        {
            return await _httpClient.PostAsJsonAsync(url, updateRecord);
        }
        /// <summary>
        /// Delete 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> Delete(string url)
        {
            return await _httpClient.DeleteAsync(url);
        }
    }
}
