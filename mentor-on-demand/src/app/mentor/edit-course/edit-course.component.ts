import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-edit-course',
  templateUrl: './edit-course.component.html',
  styleUrls: ['./edit-course.component.css']
})
export class EditCourseComponent implements OnInit {

  courseId: number
  editCourseForm: FormGroup

  constructor(private activatedRoute: ActivatedRoute, private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.courseId = this.activatedRoute.snapshot.params['id'] as number
    // this.editCourseForm = this.formBuilder.group({
    //   status:[true],
    //   name:['',Validators.required],
    //   skillId:['',Validators.required],
    //   skillName:[],
    //   mentorId:[this.authService.loggedInUser.id],
    //   mentorName:[this.authService.loggedInUser.firstName],
    //   fees:['',Validators.required],
    //   commissionAmount:[],
    //   rating:[0],
    //   approved:[true],
    //   duration:['',Validators.required]
    // })
  }

}
