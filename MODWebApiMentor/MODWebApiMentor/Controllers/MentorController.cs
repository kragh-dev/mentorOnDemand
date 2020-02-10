using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MODWebApiMentor.Models;

namespace MODWebApiMentor.Controllers
{
    [EnableCors("MODPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class MentorController : ControllerBase
    {
        modDBContext modcontext = new modDBContext();

        [Route("addCourse")]
        [HttpPost]
        public IActionResult AddCourses([FromBody] Course course)
        {
            var skill = modcontext.Skill.Where(s => s.Id == course.SkillId).FirstOrDefault();
            Course course_details = new Course();
            course_details.Name = course.Name;
            course_details.Status = course.Status;
            course_details.SkillId = course.SkillId;
            course_details.SkillName = skill.Name;
            course_details.MentorId = course.MentorId;
            course_details.MentorName = course.MentorName;
            course_details.MentorYearsOfExp = course.MentorYearsOfExp;
            course_details.Fees = course.Fees;
            course_details.CommissionAmount = course.CommissionAmount;
            course_details.Rating = course.Rating;
            course_details.Approved = course.Approved;
            course_details.Duration = course.Duration;
            modcontext.Course.Add(course_details);
            modcontext.SaveChanges();
            return Ok(new { status = "Course Added", course = course_details });
        }

        [Route("getSkills")]
        [HttpGet]
        public IActionResult GetSkills()
        {
            return Ok(modcontext.Skill);
        }

        [Route("approveStatus/{id}/{status}")]
        [HttpPut("{id}/{status}")]
        public IActionResult ApproveStatus(long id,bool status)
        {
            var training = modcontext.Training.Where(p => p.UserId == id).FirstOrDefault();
            if(status == true)
            {
                training.Approved = status;
            }
            modcontext.Training.Update(training);
            modcontext.SaveChanges();
            return Ok(new { status = "updated successfully", training = training });

        }

        [Route("editCourse/{id}")]
        [HttpPut("{id}")]
        public IActionResult EditCourse(long id,[FromBody] Course course)
        {
            var course_details = modcontext.Course.Where(s => s.Id == id).FirstOrDefault();
            var skill = modcontext.Skill.Where(s => s.Id == course.SkillId).FirstOrDefault();
            course_details.Name = course.Name;
            course_details.Status = course.Status;
            course_details.SkillId = course.SkillId;
            course_details.SkillName = skill.Name;
            course_details.MentorId = course.MentorId;
            course_details.MentorName = course.MentorName;
            course_details.Fees = course.Fees;
            course_details.CommissionAmount = course.CommissionAmount;
            course_details.Rating = course.Rating;
            course_details.Approved = course.Approved;
            course_details.Duration = course.Duration;
            modcontext.Course.Update(course_details);
            modcontext.SaveChanges();
            return Ok(new { status = "Course updated", course = course_details });
        }
    }
}