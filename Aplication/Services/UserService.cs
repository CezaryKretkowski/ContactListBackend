using Aplication.Dtos;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services
{
    public class UserService : IUserServices
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserRegisterDto Add(UserRegisterDto userDto)
        {
            User user = new User{
                Email = userDto.Email,
                Name = userDto.Name,
                LastName = userDto.LastName,
                BirthDayDate = DateOnly.FromDateTime(userDto.BirthDayDate),
                SubCategoryId = userDto.SubCategoryId,
                Telephone = userDto.Telephone,
                PasswordHash = userDto.PasswordHash,
            };
            _userRepository.Add(user);
            return userDto;
        }

        public void Delete(Guid id)
        {
            User user = _userRepository.GetById(id);
            _userRepository.Delete(user);
            
            
        }

        public IEnumerable<UserDto> GetAll()
        {
            List<UserDto> users = new List<UserDto>();
            foreach (var i in _userRepository.FindAll()) {
                users.Add(new UserDto { 
                    Id = i.Id,
                    Email = i.Email,    
                    Name = i.Name,
                    LastName = i.LastName,
                    PasswordHash = i.PasswordHash,
                    BirthDayDate = i.BirthDayDate.ToDateTime(TimeOnly.Parse("10:00 PM")),  
                    SubCategoryId = i.SubCategoryId,
                    Telephone = i.Telephone
                });
            }
            return users;
        }

        public IEnumerable<UserUnregisterDto> GetAllUnregister()
        {
            List<UserUnregisterDto> users = new List<UserUnregisterDto>();
            foreach (var i in _userRepository.FindAll())
            {
                users.Add(new UserUnregisterDto
                {
                    Email = i.Email,
                    Name = i.Name,
                    LastName = i.LastName,
                    BirthDayDate = i.BirthDayDate,
                    SubCategoryId = i.SubCategoryId,
                    SubCategory = new SubCategoryDto(i.SubCategory.Id, i.SubCategory.Name, (int)i.SubCategory.CategoryId,i.SubCategory.Category),
                    Telephone = i.Telephone
                });
            }
            return users;
        }

        public UserDto GetById(Guid id)
        {
            User user = _userRepository.GetById(id);
            return new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
                LastName = user.LastName,
                PasswordHash = user.PasswordHash,
                BirthDayDate = user.BirthDayDate.ToDateTime(TimeOnly.Parse("10:00 PM")),
                SubCategoryId = user.SubCategoryId,
             
                Telephone = user.Telephone
            };
        }

        public UserDto GetUserByEmail(string s)
        {
            User user = _userRepository.GetByEmail(s);
            if (user == null)
            {
                return null;
            }
            else
                return new UserDto
                {
                    Id = user.Id,
                    Email = user.Email,
                    Name = user.Name,
                    LastName = user.LastName,
                    PasswordHash = user.PasswordHash,
                    BirthDayDate = user.BirthDayDate.ToDateTime(TimeOnly.Parse("10:00 PM")),
                    SubCategoryId = user.SubCategoryId,
             
                    Telephone = user.Telephone
                };
        }

        public bool IsUserExist(string email)
        {
            var user = _userRepository.GetByEmail(email);
            if (user == null) 
                return false;
                  
                return true;
            
        }

        public UserDto Update(UserDto userDto)
        {
            User user = new User {
                Id = userDto.Id,
                Email = userDto.Email,
                Name = userDto.Name,
                LastName = userDto.LastName,
                BirthDayDate = DateOnly.FromDateTime(userDto.BirthDayDate),
                SubCategoryId = userDto.SubCategoryId,
                Telephone = userDto.Telephone,
                PasswordHash = userDto.PasswordHash,
            };

            _userRepository.Update(user);
            return userDto;
        }
    }
}
