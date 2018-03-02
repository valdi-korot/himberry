using System;
using Himbarry.Users.Provider.Handlers.Models;
using Himbarry.Users.Provider.Interfaces.Enums;
using Himbarry.Users.Provider.Interfaces.Exceptions;
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
            var age = DateTime.Now.Year - _userInfo.BirthDay.Year;
            var coefficient = GetCoefficient(age, _userInfo.Gender);

            if (_userInfo.Gender == Gender.Male)
            {
                if (age >= 10 && age <= 18)
                {
                    _basicMetabolicRate = coefficient.WeightCoefficient * _userInfo.Weight
                        + coefficient.HeightCoefficient * _userInfo.Height
                        + coefficient.IncrementalCoefficient;
                }

                if (age > 18 && age <= 30)
                {
                    _basicMetabolicRate = coefficient.WeightCoefficient * _userInfo.Weight
                        - coefficient.HeightCoefficient * _userInfo.Height
                        + coefficient.IncrementalCoefficient;
                }

                if (age > 30 && age <= 60)
                {
                    _basicMetabolicRate = coefficient.WeightCoefficient * _userInfo.Weight
                        + coefficient.HeightCoefficient * _userInfo.Height
                        + coefficient.IncrementalCoefficient;
                }

                if (age > 60)
                {
                    _basicMetabolicRate = coefficient.WeightCoefficient * _userInfo.Weight
                        + coefficient.HeightCoefficient * _userInfo.Height
                        - coefficient.IncrementalCoefficient;
                }
            }
            if (_userInfo.Gender == Gender.Female)
            {
                if (age >= 10 && age <= 18)
                {
                    _basicMetabolicRate = coefficient.WeightCoefficient * _userInfo.Weight
                        + coefficient.HeightCoefficient * _userInfo.Height
                        + coefficient.IncrementalCoefficient;
                }

                if (age > 18 && age <= 30)
                {
                    _basicMetabolicRate = coefficient.WeightCoefficient * _userInfo.Weight
                        + coefficient.HeightCoefficient * _userInfo.Height
                        + coefficient.IncrementalCoefficient;
                }

                if (age > 30 && age <= 60)
                {
                    _basicMetabolicRate = coefficient.WeightCoefficient * _userInfo.Weight
                        - coefficient.HeightCoefficient * _userInfo.Height
                        + coefficient.IncrementalCoefficient;
                }

                if (age > 60)
                {
                    _basicMetabolicRate = coefficient.WeightCoefficient * _userInfo.Weight
                        + coefficient.HeightCoefficient * _userInfo.Height
                        - coefficient.IncrementalCoefficient;
                }
            }
        }

        private MetabolicCoefficientModel GetCoefficient(int age, Gender gender)
        {
            if ( gender == Gender.Male )
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

                if(age> 30 && age <= 60)
                {
                    return new MetabolicCoefficientModel
                    {
                        WeightCoefficient = 11.3,
                        HeightCoefficient = 16,
                        IncrementalCoefficient = 901
                    };
                }

                if(age > 60)
                {
                    return new MetabolicCoefficientModel
                    {
                        WeightCoefficient = 8.8,
                        HeightCoefficient = 1128,
                        IncrementalCoefficient = 1071
                    };
                }
            }
            if ( gender == Gender.Female )
            {
                if (age >= 10 && age <= 18)
                {
                    return new MetabolicCoefficientModel
                    {
                        WeightCoefficient = 7.4,
                        HeightCoefficient = 482,
                        IncrementalCoefficient = 217
                    };
                }

                if (age > 18 && age <= 30)
                {
                    return new MetabolicCoefficientModel
                    {
                        WeightCoefficient = 13.3,
                        HeightCoefficient = 334,
                        IncrementalCoefficient = 35
                    };
                }

                if (age > 30 && age <= 60)
                {
                    return new MetabolicCoefficientModel
                    {
                        WeightCoefficient = 8.7,
                        HeightCoefficient = 25,
                        IncrementalCoefficient = 865
                    };
                }

                if (age > 60)
                {
                    return new MetabolicCoefficientModel
                    {
                        WeightCoefficient = 9.2,
                        HeightCoefficient = 637,
                        IncrementalCoefficient = 302
                    };
                }
            }
            throw new MetabolicCoefficientCalculateException();
        }
    }
}
