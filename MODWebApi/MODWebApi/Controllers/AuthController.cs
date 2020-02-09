using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MODWebApi.Models;

namespace MODWebApi.Controllers
{
    [EnableCors("MODPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        modDBContext modContext = new modDBContext();

        [Route("login")]
        [HttpPost]
        public IActionResult Login([FromBody] Credentials credentials)
        {
            var user = modContext.User.Where(person => person.UserName == credentials.UserName && person.Password == credentials.Password).FirstOrDefault();
            if(user != null)
            {
                return Ok(new { status = "Valid", user = user });
            }
            else
            {
                return Ok(new { status = "Invalid"});
            }
        }
        [Route("register")]
        [HttpPost]
        public IActionResult Register([FromBody] User user)
        {
            User user_details = new User();

            Wallet wallet = new Wallet();
            user_details.UserName = user.UserName;
            user_details.Password = user.Password;
            user_details.FirstName = user.FirstName;
            user_details.LastName = user.LastName;
            user_details.ContactNumber = user.ContactNumber;
            user_details.RegCode = user.RegCode;
            user_details.Role = user.Role;
            user_details.LinkedinUrl = user.LinkedinUrl;
            user_details.YearsOfExperience = user.YearsOfExperience;
            user_details.Active = true;
            user_details.Reject = false;
            user_details.Comments = user.Comments;
            modContext.User.Add(user_details);
            modContext.SaveChanges();
            var userReg = modContext.User.Where(u => u.UserName == user.UserName).FirstOrDefault();
            wallet.UserId = userReg.Id;
            wallet.Balance = 0;
            modContext.Wallet.Add(wallet);
            modContext.SaveChanges();
            return Ok(new { status = "Registered Successfully", user = user_details });
        }
        [Route("checkUserName/{userName}")]
        [HttpGet("{userName}")]
        public ActionResult EmailExist(string userName)
        {
            var user = modContext.User.Where(person => person.UserName == userName).FirstOrDefault();
            if (user == null)
                return Ok(new { status = "No such User Name" });
            else
                return Ok(new { status = "User Name already exist" });
        }
    }
}