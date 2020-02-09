import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MentorServiceService } from 'src/app/service/mentor-service.service';

@Component({
  selector: 'app-mentor-trainings',
  templateUrl: './mentor-trainings.component.html',
  styleUrls: ['./mentor-trainings.component.css']
})
export class MentorTrainingsComponent implements OnInit {

  mentorId: number
  subscribers
  constructor(private activatedRoute: ActivatedRoute, private mentorService: MentorServiceService) { }

  ngOnInit() {
    this.mentorId = this.activatedRoute.snapshot.params['id'] as number
    this.subscribers = this.mentorService.getMySubscribers(this.mentorId)
  }

  reject(id:any)
  {
    this.mentorService.updateTrainingStatus(id,false).subscribe(
      data => {
        console.log(data)
        this.subscribers = this.mentorService.getMySubscribers(this.mentorId)
      }
    )
  }
  approve(id:any)
  {
    this.mentorService.updateTrainingStatus(id,true).subscribe(
      data => {
        console.log(data)
        this.subscribers = this.mentorService.getMySubscribers(this.mentorId)
      }
    )
  }
}
