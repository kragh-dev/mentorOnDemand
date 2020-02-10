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
    public class UserTwoController : ControllerBase
    {
        modDBContext modcontext = new modDBContext();
        [Route("completeTraining/{id}/{progress}")]
        [HttpPut("{id}/{progress}")]
        public IActionResult CompleteTraining(long id, int progress)
        {
            var training = modcontext.Training.Where(t => t.Id == id).FirstOrDefault();
            var wallet = modcontext.Wallet.Where(w => w.UserId == training.MentorId).FirstOrDefault();
            var adminWallet = modcontext.Wallet.Where(w => w.UserId == 1).FirstOrDefault();
            if (training.PartOne == false && progress == 25)
            {
                training.PartOne = true;
                training.Progress = progress;
                wallet.Balance = wallet.Balance + (training.Fees / 4.0);
                adminWallet.Balance = adminWallet.Balance - (training.Fees / 4.0);
            }
            if (training.PartOne == true && training.PartTwo == false && progress == 50)
            {
                training.PartTwo = true;
                training.Progress = progress;
                wallet.Balance = wallet.Balance + (training.Fees / 4.0);
                adminWallet.Balance = adminWallet.Balance - (training.Fees / 4.0);
            }
            if (training.PartOne == true && training.PartTwo == true && training.PartThree == false && progress == 75)
            {
                training.PartThree = true;
                training.Progress = progress;
                wallet.Balance = wallet.Balance + (training.Fees / 4.0);
                adminWallet.Balance = adminWallet.Balance - (training.Fees / 4.0);
            }
            if (training.PartOne == true && training.PartTwo == true && training.PartThree == true && training.PartFour == false && progress == 100)
            {
                training.PartFour = true;
                training.Progress = progress;
                training.Completed = true;
                wallet.Balance = wallet.Balance + (training.Fees / 4.0);
                adminWallet.Balance = adminWallet.Balance - (training.Fees / 4.0);
            }
            modcontext.Training.Update(training);
            modcontext.Wallet.Update(wallet);
            modcontext.Wallet.Update(adminWallet);
            modcontext.SaveChanges();
            return Ok(new { status = "Training Completion Updated", training = training, wallet = wallet });
        }
    }
}