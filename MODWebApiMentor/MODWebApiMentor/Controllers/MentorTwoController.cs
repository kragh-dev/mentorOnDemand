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
    public class MentorTwoController : ControllerBase
    {
        modDBContext modcontext = new modDBContext();

        [Route("getCoursesById/{id}")]
        [HttpGet("{id}")]
        public IActionResult GetCoursesById(long id)
        {
            return Ok(modcontext.Course.Where(c => c.MentorId == id));
        }

        [Route("getCourse/{id}")]
        [HttpGet("{id}")]
        public IActionResult GetCourse(long id)
        {
            return Ok(modcontext.Course.Where(c => c.Id == id).FirstOrDefault());
        }

        [Route("getMySubscribers/{id}")]
        [HttpGet("{id}")]
        public IActionResult GetMySubscribers(long id)
        {
            return Ok(modcontext.Training.Where(p => p.MentorId == id && p.Rejected == false));
        }

        
    }
}