using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.Security.Hashing;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

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
                if (Request.Form.Files["UserImage"] is not null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(Request.Form.Files[0].FileName);
                    string path = Path.Combine(Directory.GetCurrentDirectory(), Defaults.DEFAULT_PROFILE_PHOTO_UPLOAD_PATH, fileName);

                    var stream = new FileStream(path, FileMode.Create);
                    Request.Form.Files["UserImage"].CopyTo(stream);

                    userDto.UserImageUrl = Defaults.DEFAULT_PROFILE_PHOTO_URL_PATH + fileName;

                    stream.Close();
                }

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

        public IActionResult DeletePhoto(int userId)
        {
            var result = _userService.GetByUserId(userId);
            result.UserImageUrl = Defaults.DEFAULT_AVATAR_URL;

            _userService.Update(result);

            return RedirectToAction("Index", new { userId = userId });
        }
    }
}
