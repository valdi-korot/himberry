using Himbarry.Users.Provider.Interfaces.Models;

namespace Himbarry.Users.Provider.Models
{
    public sealed class PersonNutrients : IPersonNutrients
    {
        public int Proteins { get; set; }
        public int Fat { get; set; }
        public int Carbohydrates { get; set; }
        public int Calories { get; set; }
    }
}
