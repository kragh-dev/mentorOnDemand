import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserServiceService } from 'src/app/service/user-service.service';

@Component({
  selector: 'app-user-trainings',
  templateUrl: './user-trainings.component.html',
  styleUrls: ['./user-trainings.component.css']
})
export class UserTrainingsComponent implements OnInit {

  userId
  trainings
  constructor(private activatedRoute: ActivatedRoute, private userService: UserServiceService, private router: Router) { }

  ngOnInit() {
    this.userId = this.activatedRoute.snapshot.params['id'] as number
    this.trainings = this.userService.getMyTrainings(this.userId)
  }

  onPay(id, userId, amount)
  {
    console.log(id+" "+userId+" "+amount)
    this.userService.payForTraining(id,userId,amount).subscribe(
      data => {
        console.log(data)
        this.trainings = this.userService.getMyTrainings(this.userId)
      }
    )
  }

  onTraining(id)
  {
    this.router.navigateByUrl('training/'+id)
  }
}
