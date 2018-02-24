using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Himberry.Service.Contrcts.IncomingContracts.Users.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GenderContract
    {
        Male,
        Female
    }
}