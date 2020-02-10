import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthServiceService } from 'src/app/service/auth-service.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.css']
})
export class UserLoginComponent implements OnInit {

  loginForm: FormGroup
  isAdmin: boolean
  isMentor: boolean
  isUser: boolean

  constructor(private formBuilder: FormBuilder, private authService: AuthServiceService, private router: Router) { }

  ngOnInit() {
    this.isAdmin = false
    this.isMentor = false
    this.isUser = false
    this.loginForm = this.formBuilder.group({
      username: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(8)]]
    });
  }

  get formControls() { return this.loginForm.controls; }

  adminClick()
  {
    this.isAdmin = true
    this.isMentor = false
    this.isUser = false
    this.loginForm = this.formBuilder.group({
      username: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(8)]]
    });
  }
  mentorClick()
  {
    this.isAdmin = false
    this.isMentor = true
    this.isUser = false
    this.loginForm = this.formBuilder.group({
      username: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(8)]]
    });
  }
  userClick()
  {
    this.isAdmin = false
    this.isMentor = false
    this.isUser = true
    this.loginForm = this.formBuilder.group({
      username: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(8)]]
    });
  }
  onLogin()
  {
    this.authService.authenticate(this.loginForm).subscribe(
      data => {
        console.log(data)
        if(data["status"] == "Valid")
        {
          this.authService.role = data["user"].role
          this.authService.loggedInUser = data["user"]
          if(this.authService.role == "mentor")
          {
            this.router.navigateByUrl("/mentorSkills")
          }
          else if(this.authService.role == "user")
          {
            this.router.navigateByUrl("/mentors")
          }
          else if(this.authService.role == "admin")
          {
            alert("Admin UI view under construction - optional")
            this.authService.onLogout()
          }
        }
      }
    )
  }
}