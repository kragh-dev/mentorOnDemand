
import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { AuthServiceService } from 'src/app/service/auth-service.service';

@Component({
  selector: 'app-user-signup',
  templateUrl: './user-signup.component.html',
  styleUrls: ['./user-signup.component.css']
})
export class UserSignupComponent implements OnInit {

  isMentor: boolean
  isUser: boolean
  userCreationForm: FormGroup
  isEmailExist: boolean
  passwordNotSame:boolean
  constructor(private formBuilder: FormBuilder, private authService:AuthServiceService) { }

  ngOnInit() {
    this.isMentor = false
    this.isUser = false
    this.userCreationForm = this.formBuilder.group({
      firstName:['',[Validators.required, Validators.maxLength(20)]],
      lastName:['',Validators.required],
      contactNumber:['',[Validators.required, Validators.maxLength(10), Validators.pattern('[0-9]*$')]],
      password:['',[Validators.required,Validators.minLength(8)]],
      userName:['',[Validators.required, Validators.email]],
      linkedinUrl:['',Validators.required],
      yearsOfExperience:['',Validators.required],
      active:[true],
      reject:[false],
      role:[''],
      comments:['']
    })
  }

  mentorClick()
  {
    this.isMentor = true
    this.isUser = false
    this.userCreationForm = this.formBuilder.group({
      firstName:['',[Validators.required, Validators.maxLength(20)]],
      lastName:['',Validators.required],
      contactNumber:['',[Validators.required, Validators.maxLength(10), Validators.pattern('[0-9]*$')]],
      password:['',[Validators.required,Validators.minLength(8)]],
      userName:['',[Validators.required, Validators.email]],
      linkedinUrl:['',Validators.required],
      yearsOfExperience:['',Validators.required],
      active:[true],
      reject:[false],
      role:['mentor'],
      comments:['']
    })
  }
  userClick()
  {
    this.isMentor = false
    this.isUser = true
    this.userCreationForm = this.formBuilder.group({
      firstName:['',[Validators.required, Validators.maxLength(20)]],
      lastName:['',Validators.required],
      contactNumber:['',[Validators.required, Validators.maxLength(10), Validators.pattern('[0-9]*$')]],
      password:['',[Validators.required,Validators.minLength(8)]],
      userName:['',[Validators.required, Validators.email]],
      linkedinUrl:[''],
      yearsOfExperience:[0],
      active:[true],
      reject:[false],
      role:['user'],
      comments:['']
    })
  }

  onEmailChange(emailId:string)
  {
    console.log(emailId)
    this.authService.checkUserName(emailId).subscribe(
      data => {
        console.log(data)
        if(data['status'] == "No such User Name")
        {
          this.isEmailExist = false
        }
        else if(data['status'] == "User Name already exist")
        {
          this.isEmailExist = true
        }
      }
    )
  }

  onConfirmPassword(event:any){
    if(event.target.value != this.userCreationForm.value['password'])
    {
      this.passwordNotSame = true;
    }
    else
    {
      this.passwordNotSame = false;
    }
  }

  onPassword(event:any,password:string){
    this.passwordNotSame = true;
    if(event.target.value != password)
    {
      this.passwordNotSame = true;
    }
    else
    {
      this.passwordNotSame = false;
    }
  }
  onSubmit()
  {
    this.authService.register(this.userCreationForm).subscribe(
      data => {
        console.log(data)
      }
    )
  }
}
