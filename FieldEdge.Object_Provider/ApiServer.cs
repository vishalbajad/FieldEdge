namespace FieldEdge.Object_Provider
{
    /// <summary>
    /// Remote Server API Details for Communications
    /// </summary>
    public class ApiServer
    {
        public string ServerBaseUrl { get; set; }
        /// <summary>
        /// Content Type
        /// </summary>
        public string RequestContentType = "application/json; charset=utf-8";
        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public string Expiration { get; set; }
        public ApiServer()
        {

        }

    }
}
