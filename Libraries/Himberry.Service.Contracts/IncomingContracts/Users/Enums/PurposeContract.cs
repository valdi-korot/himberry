using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Himberry.Service.Contrcts.IncomingContracts.Users.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PurposeContract
    {
        WeightLoss,
        Drying,
        SetOfMasses,
        SetOfMusculs,
        SupportMass
    }
}
