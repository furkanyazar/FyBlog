using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.Security.Hashing;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class UserController : Controller
    {
        private IUserService _userService;
        private IMapper _mapper;

        private UserValidator userValidator = new UserValidator();
        private ValidationResult validation;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index(int userId)
        {
            var user = _userService.GetByUserId(userId);

            var result = _mapper.Map<UserDto>(user);

            return View(result);
        }

        [HttpPost]
        public IActionResult Index(UserDto userDto)
        {
            var oldUser = _userService.GetByUserId(userDto.UserId);

            if (userDto.UserPassword is null)
                userDto.UserPassword = Defaults.PASSWORD_KEY;

            validation = userValidator.Validate(userDto);

            if (validation.IsValid)
            {
                var user = _mapper.Map<User>(userDto);

                if (userDto.UserPassword == Defaults.PASSWORD_KEY)
                {
                    user.UserPasswordHash = oldUser.UserPasswordHash;
                    user.UserPasswordSalt = oldUser.UserPasswordSalt;
                }
                else
                {
                    byte[] passwordHash, passwordSalt;
                    HashingHelper.CreatePasswordHash(userDto.UserPassword, out passwordHash, out passwordSalt);

                    user.UserPasswordHash = passwordHash;
                    user.UserPasswordSalt = passwordSalt;
                }

                _userService.Update(user);

                return RedirectToAction("Index", "Blog");
            }

            foreach (var item in validation.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }

            return View();
        }
    }
}
