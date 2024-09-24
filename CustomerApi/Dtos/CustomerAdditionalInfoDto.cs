using System.Text.Json.Serialization;
namespace CustomerApi.Dtos;

public class CustomerAdditionalInfoDto
{
    [JsonPropertyName("id")]
    public string Id { get; set; }
    [JsonPropertyName("customerId")]
    public string CustomerId { get; set; }
    [JsonPropertyName("address")]
    public string Address { get; set; }
    [JsonPropertyName("phoneNumber")]
    public string  PhoneNumber { get; set; }
}
