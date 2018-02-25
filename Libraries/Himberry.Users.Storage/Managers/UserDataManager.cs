﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Himbarry.Users.Storage.Interfaces.Managers;
using Himbarry.Users.Storage.Interfaces.Models;
using System.Data.Entity.Migrations;
using System.Linq;
using Himbarry.Users.Storage.Interfaces.Exceptions;
using Himberry.Common.Helpers;
using Himberry.Users.Storage.Entities;

namespace Himberry.Users.Storage.Managers
{
    public sealed class UserDataManager : IDisposable, IUserDataManager
    {
        private readonly UsersContext _authContext;
        private readonly UserManager<IdentityUser> _userManager;

        public UserDataManager(string userConnectionString)
        {
            _authContext = new UsersContext(userConnectionString);
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_authContext));
        }

        public async Task RegisterUserAsync(UserDataModel userDataModel, string password)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = userDataModel.UserName,
                Email = userDataModel.Email
            };

            var result = await _userManager.CreateAsync(user, password);
            if (!result.Succeeded)
            {
                throw new UserRegisterDataException();
            }
        }

        public async Task<UserDataModel> GetUserAsync(string userName, string password)
        {
            IdentityUser user = await _userManager.FindAsync(userName, password);
            if (user == null)
            {
                throw new UserNotFoundDataException();
            }
            var userDataModel = ConvertUserIdentityToDataModel(user);
            return userDataModel;
        }

        public void Dispose()
        {
            _authContext.Dispose();
            _userManager.Dispose();

        }

        public async Task SaveUserInfoAsync(UserInfoDataModel userInfoDataModel, IReadOnlyCollection<TraningDataModel> obsoloteTranings)
        {
            var userInfoEnity = Converter.Convert<UserInfoEntity, UserInfoDataModel>(userInfoDataModel);
            _authContext.Set<UserInfoEntity>().AddOrUpdate(userInfoEnity);
            if (obsoloteTranings.Any())
            {
                var obsolteTraningEntities = _authContext.UserInfo.Include(p => p.Tranings)
                    .FirstOrDefault(p => p.UserId.Equals(userInfoEnity.UserId, StringComparison.InvariantCultureIgnoreCase))
                    ?.Tranings.Where(p => obsoloteTranings.Any(t => t.DayOfWeek.ToString().Equals(p.DayOfWeek, StringComparison.InvariantCultureIgnoreCase)))
                    .ToList();
                _authContext.Tranings.RemoveRange(obsolteTraningEntities);
                _authContext.SaveChanges();
            }

            userInfoEnity.Tranings.ForEach(p => { _authContext.Set<TraningEntity>().AddOrUpdate(p); });
            await _authContext.SaveChangesAsync();
        }

        public async Task<UserDataModel> GetUserAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new UserNotFoundDataException();
            }
            return ConvertUserIdentityToDataModel(user);
        }

        public async Task<UserInfoDataModel> GetUserInfoAsync(string userId)
        {
            var userInfo = _authContext.UserInfo.Include(p => p.Tranings).FirstOrDefault(x => x.UserId == userId);
            if (userInfo == null)
            {
                throw new UserInfoNotFoundDataException();
            }
            var result = Converter.Convert<UserInfoDataModel, UserInfoEntity>(userInfo);
            return result;
        }

        private UserDataModel ConvertUserIdentityToDataModel(IdentityUser user)
        {
            return new UserDataModel
            {
                UserId = user.Id,
                Email = user.Email,
                UserName = user.UserName
            };
        }
    }
}