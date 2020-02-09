import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthServiceService } from 'src/app/service/auth-service.service';
import { MentorServiceService } from 'src/app/service/mentor-service.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-course',
  templateUrl: './add-course.component.html',
  styleUrls: ['./add-course.component.css']
})
export class AddCourseComponent implements OnInit {

  addCourseForm: FormGroup
  skills
  constructor(private mentorService: MentorServiceService, private formBuilder: FormBuilder, private authService:AuthServiceService, private router: Router) { }

  ngOnInit() {
    this.mentorService.getSkills().subscribe(
      data => {
        console.log(data)
        this.skills = data
        this.mentorService.skills = data
      }
    )
    this.addCourseForm = this.formBuilder.group({
      status:[true],
      name:['',Validators.required],
      skillId:['',Validators.required],
      skillName:[],
      mentorId:[this.authService.loggedInUser.id],
      mentorName:[this.authService.loggedInUser.firstName],
      mentorYearsOfExp:[this.authService.loggedInUser.yearsOfExperience],
      fees:['',Validators.required],
      commissionAmount:[],
      rating:[0],
      approved:[true],
      duration:['',Validators.required]
    })
  }
  onSubmit(){
    this.mentorService.addCourse(this.addCourseForm).subscribe(
      data => {
        console.log(data)
        if(data["status"]=="Course Added")
        {
          this.router.navigateByUrl("mentorSkills")
        }
      }
    )
  }
  onFeeChange()
  {
    this.addCourseForm.patchValue({commissionAmount: this.addCourseForm.get('fees').value*10/100})
  }
}
