using System;
using AutoMapper;
using Himbarry.Users.Provider.Interfaces.Enums;
using Himbarry.Users.Provider.Models;
using Himbarry.Users.Storage.Interfaces.Enums;
using Himbarry.Users.Storage.Interfaces.Models;
using Himberry.Service.Contrcts.IncomingContracts.Users.Enums;
using Himberry.Users.Storage.Entities;

namespace Himberry.DepencyConfigurator
{
    public static class MappingInitializer
    {
        public static void Init()
        {
            InitUsersModels();
        }

        private static void InitUsersModels()
        {
            Mapper.Initialize(p =>
            {
                p.CreateMap<Gender, GenderContract>();
                p.CreateMap<Gender, GenderData>();
                p.CreateMap<UserInfo, UserInfoDataModel>();
                p.CreateMap<TraningDataModel, TraningEntity>();//ForMember(f => f.Id, prop => prop.Ignore());
                p.CreateMap<UserInfoDataModel, UserInfoEntity>();
                p.CreateMap<User, UserDataModel>();
                p.CreateMap<TypeWork, TypeWorkContract>();
                p.CreateMap<Intensity, IntensityContract>();
                p.CreateMap<Purpose, PurposeContract>();
            });
        }
    }
}