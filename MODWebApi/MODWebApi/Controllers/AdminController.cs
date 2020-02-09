using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MODWebApi.Models;
using MODWebApi.Controllers;

namespace MODWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        modDBContext modcontext = new modDBContext();

        [Route("addSkill")]
        [HttpPost]
        public IActionResult AddSkill([FromBody] Skill skill)
        {
            Skill skill_details = new Skill();
            skill_details.Name = skill.Name;
            skill_details.Toc = skill.Toc;
            skill_details.Prerequistes = skill.Prerequistes;
            modcontext.Skill.Add(skill_details);
            modcontext.SaveChanges();
            return Ok(new { status = "Skill added", skill = skill_details });
        }

        [Route("deleteSkill/{id}")]
        [HttpDelete("{id}")]
        public IActionResult DeleteSkill(long id)
        {
            var skill = modcontext.Skill.Where(s => s.Id == id).FirstOrDefault();
            modcontext.Skill.Remove(skill);
            modcontext.SaveChanges();
            return Ok(new { status = "Deleted successfully" });
        }
    }
}