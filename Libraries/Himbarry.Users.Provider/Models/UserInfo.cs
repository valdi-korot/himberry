using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Himbarry.Users.Provider.Interfaces.Enums;
using Himbarry.Users.Provider.Interfaces.Exceptions;
using Himbarry.Users.Provider.Interfaces.Models;
using Himbarry.Users.Storage.Interfaces.Managers;
using Himbarry.Users.Storage.Interfaces.Models;
using Himberry.Common.Helpers;

namespace Himbarry.Users.Provider.Models
{
    public sealed class UserInfo : IUserInfo
    {
        #region Fields

        private readonly IUserDataManager _userDataManager;
        private bool _isChanged;

        private string _firstName;
        private DateTime _birthDay;
        private float _weight;
        private Gender _gender;
        private float _height;
        private TypeWork _typeWork;
        private Purpose _purpose;
        private List<Traning> _tranings = new List<Traning>();
        private int _sleepTime;
        private int _workTime;
        private int _activeTime;
        private int _passiveTime;

        #endregion

        #region Properties

        private bool IsChanged
        {
            get { return _isChanged || (_tranings != null && _tranings.Any(p => p.isChanged)); }
        }
        public string UserId { get; set; }
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                if (value != _firstName)
                {
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        throw new FirstNameNotValidException();
                    }
                    _firstName = value;
                    _isChanged = true;
                }
            }
        }
        public DateTime BirthDay
        {
            get
            {
                return _birthDay;
            }
            set
            {
                if (value != _birthDay)
                {
                    _birthDay = value;
                    _isChanged = true;
                }
            }
        }
        public float Weight
        {
            get
            {
                return _weight;
            }
            set
            {
                if (value != _weight)
                {
                    _weight = value;
                    _isChanged = true;
                }
            }
        }
        public float Height
        {
            get
            {
                return _height;
            }
            set
            {
                if (value != _height)
                {
                    _height = value;
                    _isChanged = true;
                }
            }
        }
        public Gender Gender
        {
            get
            {
                return _gender;
            }
            set
            {
                if (value != _gender)
                {
                    _gender = value;
                    _isChanged = true;
                }
            }
        }
        public TypeWork TypeWork
        {
            get
            {
                return _typeWork;
            }
            set
            {
                if (value != _typeWork)
                {
                    _typeWork = value;
                    _isChanged = true;
                }
            }
        }
        public Purpose Purpose
        {
            get
            {
                return _purpose;
            }
            set
            {
                if (value != _purpose)
                {
                    _purpose = value;
                    _isChanged = true;
                }
            }
        }
        public IReadOnlyCollection<ITraning> Tranings
        {
            get
            {
                return _tranings;
            }
        }
        public int SleepTime
        {
            get
            {
                return _sleepTime;
            }
            set
            {
                if (value != _sleepTime)
                {
                    _sleepTime = value;
                    _isChanged = true;
                }
            }
        }
        public int WorkTime
        {
            get
            {
                return _workTime;
            }
            set
            {
                if (value != _workTime)
                {
                    _workTime = value;
                    _isChanged = true;
                }
            }
        }
        public int ActiveTime
        {
            get
            {
                return _activeTime;
            }
            set
            {
                if (value != _activeTime)
                {
                    _activeTime = value;
                    _isChanged = true;
                }
            }
        }
        public int PassiveTime
        {
            get
            {
                return _passiveTime;
            }
            set
            {
                if (value != _passiveTime)
                {
                    _passiveTime = value;
                    _isChanged = true;
                }
            }
        }

        #endregion

        public UserInfo(string userId, IUserDataManager userDataManager)
        {
            UserId = userId;
            _userDataManager = userDataManager;
        }

        public void AddTraining(DayOfWeek dayOfWeek, TimeSpan avgDuration, Intensity intensity)
        {
            var training = _tranings.FirstOrDefault(p => p.DayOfWeek == dayOfWeek);
            if (training == null)
            {
                training = new Traning(UserId, dayOfWeek, avgDuration, intensity);
            }
            else
            {
                training.AvgDuration = avgDuration;
                training.Intensity = intensity;
            }

            _tranings.Add(training);
        }

        internal async Task SaveAsync()
        {
            if (IsChanged)
            {
                var isValidModel = IsScheduleDayTimeValid();
                if (!isValidModel)
                {
                    throw new ScheduleDayTimeNotValidException();
                }
                var userDataModel = ConvertToDataModel();
                await _userDataManager.SaveUserInfoAsync(userDataModel);
                _tranings.ForEach(p => { p.isChanged = false; });
                _isChanged = false;
            }
        }

        private UserInfoDataModel ConvertToDataModel()
        {
            var dataModel = Converter.Convert<UserInfoDataModel, UserInfo>(this);
            return dataModel;
        }
        private bool IsScheduleDayTimeValid()
        {
            var result = 24 == ActiveTime + PassiveTime + SleepTime + WorkTime;
            return result;
        }
    }
}
