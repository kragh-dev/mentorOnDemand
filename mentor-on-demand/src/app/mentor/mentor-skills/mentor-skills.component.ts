import { Component, OnInit } from '@angular/core';
import { MentorServiceService } from 'src/app/service/mentor-service.service';
import { AuthServiceService } from 'src/app/service/auth-service.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-mentor-skills',
  templateUrl: './mentor-skills.component.html',
  styleUrls: ['./mentor-skills.component.css']
})
export class MentorSkillsComponent implements OnInit {

  skills
  myCourses
  constructor(private mentorService: MentorServiceService, private authService: AuthServiceService, private router: Router) { }

  ngOnInit() {
    this.mentorService.getSkills().subscribe(
      data => {
        console.log(data)
        this.mentorService.skills = data
      }
    )
    this.mentorService.getMyCourses(this.authService.loggedInUser.id).subscribe(
      data => {
        console.log(data)
        this.myCourses = data
      }
    )
  }
  onAdd()
  {
    this.router.navigateByUrl('addCourse')
  }
  onEdit(id)
  {
    this.router.navigateByUrl('editCourse/'+id)
  }
}
