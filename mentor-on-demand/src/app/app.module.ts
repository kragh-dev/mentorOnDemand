import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MentorSearchComponent } from './mentor/mentor-search/mentor-search.component';
import { MentorTrainingsComponent } from './mentor/mentor-trainings/mentor-trainings.component';
import { MentorCalendarComponent } from './mentor/mentor-calendar/mentor-calendar.component';
import { MentorProfileComponent } from './mentor/mentor-profile/mentor-profile.component';
import { MentorSkillsComponent } from './mentor/mentor-skills/mentor-skills.component';
import { TrainingComponent } from './training/training.component';
import { UserTrainingsComponent } from './user/user-trainings/user-trainings.component';
import { UserLoginComponent } from './user/user-login/user-login.component';
import { UserSignupComponent } from './user/user-signup/user-signup.component';
import { HeaderComponent } from './site/header/header.component';
import { BannerOneComponent } from './site/banner/banner-one/banner-one.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AddCourseComponent } from './mentor/add-course/add-course.component';
import { EditCourseComponent } from './mentor/edit-course/edit-course.component';
import { AsyncPipe } from '@angular/common';

@NgModule({
  declarations: [
    AppComponent,
    MentorSearchComponent,
    MentorTrainingsComponent,
    MentorCalendarComponent,
    MentorProfileComponent,
    MentorSkillsComponent,
    TrainingComponent,
    UserTrainingsComponent,
    UserLoginComponent,
    UserSignupComponent,
    HeaderComponent,
    BannerOneComponent,
    AddCourseComponent,
    EditCourseComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [AsyncPipe],
  bootstrap: [AppComponent]
})
export class AppModule { }
