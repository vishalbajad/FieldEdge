using System.Net;
using System.Text.Json;
using System.Text;
using FieldEdge.Object_Provider;


namespace FieldEdge.API.HTTP.Connector
{
    public class HttpConnector
    {
        public class HTTPConnector
        {
            /// <summary>
            /// Rest API Request Methods
            /// </summary>
            public struct RequestMethod
            {
                public static string GET = "GET";
                public static string POST = "POST";
                public static string PUT = "PUT";
                public static string DELETE = "DELETE";
            }
            
            /// <summary>
            /// API Server Details
            /// </summary>
            private readonly ApiServer _apiserver;
            
            /// <summary>
            /// This Logic is being use to communicate with API ends points
            /// </summary>
            /// <param name="apiserver"></param>
            public HTTPConnector(ApiServer apiserver)
            {
                _apiserver = apiserver;
            }

            /// <summary>
            /// Send Request to API Endpoint
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="apiUrl"></param>
            /// <param name="apiMethod"></param>
            /// <param name="apiJson"></param>
            /// <param name="queryString"></param>
            /// <returns></returns>
            public T SendJsonRequest<T>(string apiUrl, string apiMethod, string apiJson = "", string queryString = "")
            {
                T result;

                try
                {
                    UriBuilder actionUri = new UriBuilder(_apiserver.ServerBaseUrl.TrimEnd('/') + "/" + apiUrl.TrimStart('/'));
                    string ResponseText = String.Empty;
                    HttpStatusCode ResponseStatusCode = HttpStatusCode.Unused;

                    if (!String.IsNullOrEmpty(queryString))
                    {
                        if (String.IsNullOrEmpty(actionUri.Query))
                            actionUri.Query = queryString.TrimStart(new char[] { '?' });
                        else
                            actionUri.Query = actionUri.Query.TrimStart(new char[] { '?' }) + "&" + queryString;
                    }

                    ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                    HttpWebRequest request = WebRequest.Create(actionUri.Uri) as HttpWebRequest;
                    request.Method = apiMethod;
                    request.Headers["Authorization"] = $"Bearer {_apiserver.Token}";

                    if (!String.IsNullOrEmpty(apiJson))
                    {
                        byte[] bytes = UTF8Encoding.UTF8.GetBytes(apiJson);
                        request.ContentType = _apiserver.RequestContentType;
                        request.ContentLength = bytes.Length;
                        using (Stream postStream = request.GetRequestStream())
                        {
                            postStream.Write(bytes, 0, bytes.Length);
                        }
                    }
                    using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                    {
                        ResponseStatusCode = response.StatusCode;

                        using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                        {
                            ResponseText = reader.ReadToEnd();
                        }
                    }
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    result = JsonSerializer.Deserialize<T>(@ResponseText, options);
                }
                catch
                {
                    return default(T);
                }

                return result;
            }

            /// <summary>
            /// Autherization Types
            /// </summary>
            public enum AuthorizationType
            {
                BEARER,
                BASIC
            }
        }
    }
}
