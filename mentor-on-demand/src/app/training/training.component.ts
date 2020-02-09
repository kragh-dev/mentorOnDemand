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
  trainings

  constructor(private userService: UserServiceService, private activatedRoute: ActivatedRoute) { }

  ngOnInit() {
    this.trainingId = this.activatedRoute.snapshot.params['id'] as number
    this.trainings = this.userService.getTraining(this.trainingId)
  }

  onTraining(id, progress)
  {
    this.userService.completeTraining(id,progress).subscribe(
      data => {
        this.trainings = this.userService.getTraining(this.trainingId)
      }
    )
  }
}
