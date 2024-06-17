using FieldEdge.API.Object_Provider;
using System.Net.Http;

namespace FieldEdge.API.HTTP.Connector.Interfaces
{
    public interface IHttpRepository<T>
    {
        /// <summary>
        /// Get all details
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> Get(string url);

        /// <summary>
        /// Get single records
        /// </summary>
        /// <returns></returns>
        Task<T> GetSingle(string url);

        /// <summary>
        /// Create new Record
        /// </summary>
        /// <param name="newRecord"></param>
        /// <returns></returns>
        Task<HttpResponseMessage> Add(string url, T newRecord);

        /// <summary>
        /// Update details
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateRecord"></param>
        /// <returns></returns>
        Task<HttpResponseMessage> Update(string url, T updateRecord);
        /// <summary>
        /// Delete 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<HttpResponseMessage> Delete(string url);
    }
}
