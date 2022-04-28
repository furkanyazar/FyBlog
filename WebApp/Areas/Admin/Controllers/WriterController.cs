using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.Security.Hashing;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {
        private IWriterService _writerService;
        private IUserService _userService;

        private IMapper _mapper;

        private UserRegisterValidator userRegisterValidator = new UserRegisterValidator();
        private WriterValidator writerValidator = new WriterValidator();
        private ValidationResult validation;

        public WriterController(IWriterService writerService, IUserService userService, IMapper mapper)
        {
            _writerService = writerService;
            _userService = userService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var result = _writerService.GetAllWithIncludes();

            return View(result);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(UserRegisterDto userRegisterDto)
        {
            validation = userRegisterValidator.Validate(userRegisterDto);

            if (validation.IsValid)
            {
                byte[] passwordHash, passwordSalt;

                HashingHelper.CreatePasswordHash(userRegisterDto.UserPassword, out passwordHash, out passwordSalt);

                var user = new User
                {
                    UserEmail = userRegisterDto.UserEmail,
                    UserFirstName = userRegisterDto.UserFirstName,
                    UserLastName = userRegisterDto.UserLastName,
                    UserImageUrl = Defaults.DEFAULT_AVATAR_URL,
                    UserPasswordHash = passwordHash,
                    UserPasswordSalt = passwordSalt
                };

                _userService.Add(user);

                var writer = new Writer
                {
                    UserId = _userService.GetAll().LastOrDefault().UserId
                };

                _writerService.Add(writer);

                return RedirectToAction("Index");
            }

            foreach (var item in validation.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }

            return View();
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var writer = _writerService.GetByUserId(id);

            var result = _mapper.Map<WriterDto>(writer);

            return View(result);
        }

        [HttpPost]
        public IActionResult Update(WriterDto writerDto)
        {
            var oldWriter = _writerService.GetByUserId(writerDto.UserId);

            writerDto.UserImageUrl = oldWriter.User.UserImageUrl;

            if (writerDto.UserPassword is null)
                writerDto.UserPassword = Defaults.PASSWORD_KEY;

            validation = writerValidator.Validate(writerDto);

            if (validation.IsValid)
            {
                var writer = _mapper.Map<Writer>(writerDto);

                writer.WriterId = oldWriter.WriterId;

                if (writerDto.UserPassword == Defaults.PASSWORD_KEY)
                {
                    writer.User.UserPasswordHash = oldWriter.User.UserPasswordHash;
                    writer.User.UserPasswordSalt = oldWriter.User.UserPasswordSalt;
                }
                else
                {
                    byte[] passwordHash, passwordSalt;

                    HashingHelper.CreatePasswordHash(writerDto.UserPassword, out passwordHash, out passwordSalt);

                    writer.User.UserPasswordHash = passwordHash;
                    writer.User.UserPasswordSalt = passwordSalt;
                }

                _userService.Update(writer.User);

                _writerService.Update(writer);

                return RedirectToAction("Index");
            }

            foreach (var item in validation.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }

            return View();
        }

        public IActionResult Delete(int id)
        {
            var result = _writerService.GetByUserId(id);

            result.User.UserStatus = !result.User.UserStatus;

            _userService.Update(result.User);

            return RedirectToAction("Index");
        }
    }
}
