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
    public class UserController : ControllerBase
    {
        modDBContext modcontext = new modDBContext();
        [Route("proposeTraining/{id}/{userId}/{userName}")]
        [HttpPost("{id}/{userId}/{userName}")]
        public IActionResult ProposeTraining(long id,long userId, string userName)
        {
            Training training = new Training();
            var training_details = modcontext.Training.Where(t => t.CourseId == id && t.UserId == userId).FirstOrDefault();
            if(training_details == null)
            {
                var course = modcontext.Course.Where(p => p.Id == id).FirstOrDefault();
                training.Completed = false;
                training.Progress = 0;
                training.CourseId = course.Id;
                training.CourseName = course.Name;
                training.SkillId = course.SkillId;
                training.SkillName = course.SkillName;
                training.MentorId = course.MentorId;
                training.MentorName = course.MentorName;
                training.UserId = userId;
                training.UserName = userName;
                training.Approved = false;
                training.Rejected = false;
                training.StartDate = DateTime.Now;
                training.PartOne = false;
                training.PartTwo = false;
                training.PartThree = false;
                training.PartFour = false;
                training.Rating = course.Rating;
                training.PaymentStatus = false;
                training.Fees = course.Fees;
                training.CommissionAmount = course.CommissionAmount;
                modcontext.Training.Add(training);
                modcontext.SaveChanges();
                return Ok(new { status = "Training requested", training = training });
            }
            else
            {
                return Ok(new { status = "Training already requested for this course"});
            }
        }


        [Route("getCourses")]
        [HttpGet]
        public IActionResult GetCourses()
        {
            return Ok(modcontext.Course);
        }

        [Route("getMyTrainings/{id}")]
        [HttpGet("{id}")]
        public IActionResult GetMyTrainings(long id)
        {
            return Ok(modcontext.Training.Where(t => t.UserId == id));
        }
        [Route("payForTraining/{id}/{userId}/{amount}")]
        [HttpPut("{id}/{userId}/{amount}")]
        public IActionResult PayForTraining(long id, long userId, long amount)
        {
            Payment payment = new Payment();
            long adminId = 2;
            payment.UserId = userId;
            payment.PaymentMethod = "Online";
            payment.AmountPaid = amount;
            payment.TransactionStatus = "Success";
            modcontext.Payment.Add(payment);
            modcontext.SaveChanges();
            var training = modcontext.Training.Where(t => t.Id == id).FirstOrDefault();
            var wallet = modcontext.Wallet.Where(w => w.UserId == adminId).FirstOrDefault();
            training.AmountPaid = amount;
            wallet.Balance = wallet.Balance + amount;
            training.PaymentStatus = true;
            training.PaymentId = payment.Id;
            modcontext.Wallet.Update(wallet);
            modcontext.Training.Update(training);
            modcontext.SaveChanges();
            return Ok(new { status = "Payment Successful", payment = payment });
        }
        [Route("getTraining/{id}")]
        [HttpGet("{id}")]
        public IActionResult GetTraining(long id)
        {
            return Ok(modcontext.Training.Where(t => t.Id == id));
        }
    }
}