import { Component, OnInit } from '@angular/core';
import { UserServiceService } from '../service/user-service.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-training',
  templateUrl: './training.component.html',
  styleUrls: ['./training.component.css']
})
export class TrainingComponent implements OnInit {

  trainingId
  training

  constructor(private userService: UserServiceService, private activatedRoute: ActivatedRoute) { }

  ngOnInit() {
    this.trainingId = this.activatedRoute.snapshot.params['id'] as number
    this.userService.getTraining(this.trainingId).subscribe(
      data => {
        this.training = data
      }
    )
  }

}
