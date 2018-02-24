using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Himberry.Service.Contrcts.IncomingContracts.Users.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TypeWorkContract
    {
        WithoutExercise,
        EasyExercise,
        MediumExercise,
        HardExercise,
        HarderExercise
    }
}
