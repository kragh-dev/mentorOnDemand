import { Component, OnInit } from '@angular/core';
import { UserServiceService } from 'src/app/service/user-service.service';
import { AuthServiceService } from 'src/app/service/auth-service.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-mentor-search',
  templateUrl: './mentor-search.component.html',
  styleUrls: ['./mentor-search.component.css']
})
export class MentorSearchComponent implements OnInit {

  allCourses
  courses
  constructor(private userService: UserServiceService, private authServcie:AuthServiceService, private router: Router) { }

  ngOnInit() {
    this.userService.getCourses().subscribe(
      data => {
        this.courses = data
        this.allCourses = this.courses
      }
    )
  }

  onSearch(event:any)
  {
    if(event.target.value == '')
    {
      this.courses = this.allCourses
    }
    else
    {
      this.courses = this.allCourses.filter(course => course.skillName.toLocaleLowerCase().includes(event.target.value.toLocaleLowerCase()))
    }
  }

  onPropose(id)
  {
    if(this.authServcie.loggedInUser != null)
    {
      this.userService.addTraining(id,this.authServcie.loggedInUser.id,this.authServcie.loggedInUser.firstName).subscribe(
        data => {
          console.log(data)
        }
      )
    }
    else
    {
      this.router.navigateByUrl('login');
    }
  }
}
