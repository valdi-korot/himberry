using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Himberry.Service.Contrcts.IncomingContracts.Users.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum IntensityContract
    {
        Default,
        Hard,
        Harder
    }
}
