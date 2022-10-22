using Business.Abstract;
using Core.Security.Hashing;
using DataAccesss.Abstract;
using Entities.DTOs;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthManager
    {
        private readonly IAuthDal _authDal;
        private readonly IUserRoleManager _userRoleManager;
        private readonly HashingHandler _hashingHandler;
        public AuthManager(IAuthDal authDal, HashingHandler hashingHandler, IUserRoleManager userRoleManager)
        {
            _authDal = authDal;
            _hashingHandler = hashingHandler;
            _userRoleManager = userRoleManager;
        }

        public User GetUserByEmail(string email)
        {
            return _authDal.GetUserByMail(email);
        }

        //public List<User> GetUsers()
        //{
        //    throw new NotImplementedException();
        //}

        public User Login(string email)
        {
            
                var user = _authDal.GetUserByMail(email);
                if (user == null)
                    return null;

                return user;

        }

        public void Register(DtoRegister model)
        {
                User user = new()
                {
                    Email = model.Email,
                    FullName = model.FullName,
                    Password = _hashingHandler.CreatePasswordHash(model.Password),
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                };
                _authDal.Add(user);
                var currentUser = _authDal.GetUserByMail(user.Email);
                _userRoleManager.AddDefaultRole(currentUser.Id);
        }
    }
}
