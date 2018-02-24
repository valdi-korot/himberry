using System;
using Himbarry.Users.Provider.Handlers.Models;
using Himbarry.Users.Provider.Interfaces.Enums;
using Himbarry.Users.Provider.Interfaces.Models;
using Himbarry.Users.Provider.Models;

namespace Himbarry.Users.Provider.Handlers
{
    public sealed class PersonNutrisionCalculator
    {
        private double _basicMetabolicRate;
        private IUserInfo _userInfo;
        private DateTime _date;

        public PersonNutrisionCalculator(DateTime date, IUserInfo userInfo)
        {
            _date = date;
            _userInfo = userInfo;
        }

        public IPersonNutrients Calculate()
        {
            CalculateBasicMetabolicRate();
            return new PersonNutrients();
        }

        private void CalculateBasicMetabolicRate()
        {
            int age = DateTime.Now.Year - _userInfo.BirthDay.Year;
            var coefficient = GetCoefficient(age, _userInfo.Gender);

            _basicMetabolicRate = coefficient.HeightCoefficient * _userInfo.Height
                                  + coefficient.WeightCoefficient * _userInfo.Weight
                                  + coefficient.IncrementalCoefficient;
        }

        private MetabolicCoefficientModel GetCoefficient(int age, Gender gender)
        {
            if (gender == Gender.Male)
            {
                if (age >= 10 && age <= 18)
                {
                    return new MetabolicCoefficientModel
                    {
                        WeightCoefficient = 16.6,
                        HeightCoefficient = 77,
                        IncrementalCoefficient = 572
                    };
                }

                if (age > 18 && age <= 30)
                {
                    return new MetabolicCoefficientModel
                    {
                        WeightCoefficient = 15.4,
                        HeightCoefficient = 27,
                        IncrementalCoefficient = 717

                    };
                }
            }

            return null;
        }
    }
}
