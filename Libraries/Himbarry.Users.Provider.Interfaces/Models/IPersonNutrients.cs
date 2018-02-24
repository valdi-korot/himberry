namespace Himbarry.Users.Provider.Interfaces.Models
{
    public interface IPersonNutrients
    {
        int Proteins { get; set; }
        int Fat { get; set; }
        int Carbohydrates { get; set; }
        int Calories { get; set; }
    }
}