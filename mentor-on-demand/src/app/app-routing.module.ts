import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MentorCalendarComponent } from './mentor/mentor-calendar/mentor-calendar.component';
import { MentorSearchComponent } from './mentor/mentor-search/mentor-search.component';
import { UserLoginComponent } from './user/user-login/user-login.component';
import { UserSignupComponent } from './user/user-signup/user-signup.component';
import { MentorSkillsComponent } from './mentor/mentor-skills/mentor-skills.component';
import { AddCourseComponent } from './mentor/add-course/add-course.component';
import { EditCourseComponent } from './mentor/edit-course/edit-course.component';
import { MentorTrainingsComponent } from './mentor/mentor-trainings/mentor-trainings.component';
import { UserTrainingsComponent } from './user/user-trainings/user-trainings.component';
import { TrainingComponent } from './training/training.component';


const routes: Routes = [
  {path:'mentors', component:MentorSearchComponent},
  {path:'mentorSkills', component:MentorSkillsComponent},
  {path:'addCourse', component:AddCourseComponent},
  {path:'editCourse/:id', component:EditCourseComponent},
  {path:'login', component:UserLoginComponent},
  {path:'signup', component:UserSignupComponent},
  {path:'mentorTrainings/:id', component:MentorTrainingsComponent},
  {path:'userTrainings/:id', component:UserTrainingsComponent},
  {path:'training/:id', component:TrainingComponent},
  {path:'**', redirectTo:'mentors'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }