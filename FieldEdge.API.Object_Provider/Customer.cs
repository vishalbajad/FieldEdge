using Newtonsoft.Json;
namespace FieldEdge.API.Object_Provider
{
    public class Customer
    {
        [JsonProperty(PropertyName = "id")]
        public int CustomerId { get; set; }
        [JsonProperty(PropertyName = "firstname")] 
        public string FirstName { get; set; }
        [JsonProperty(PropertyName = "lastname")] 
        public string LastName { get; set; }
        [JsonProperty(PropertyName = "email")] 
        public string Email { get; set; }
        [JsonProperty(PropertyName = "phone_Number")] 
        public string PhoneNumber { get; set; }
        [JsonProperty(PropertyName = "country_code")] 
        public string CountryCode { get; set; }
        [JsonProperty(PropertyName = "gender")] 
        public string Gender { get; set; }
        [JsonProperty(PropertyName = "balance")] 
        public decimal Balance { get; set; }
    }

}
