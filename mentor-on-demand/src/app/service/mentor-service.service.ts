import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class MentorServiceService {

  skills
  baseUrl = 'http://localhost:5000/api/'
  constructor(private http: HttpClient) { }

  getSkills()
  {
    let header = new HttpHeaders({ 'Content-Type': 'application/json', 'responseType':'text' })
    let options = { headers: header }
    return this.http.get(this.baseUrl+"mentor/getSkills",options)
  }
  getMyCourses(id:any)
  {
    let body = id
    let header = new HttpHeaders({ 'Content-Type': 'application/json', 'responseType':'text' })
    let options = { headers: header }
    return this.http.get(this.baseUrl+"mentorTwo/getCoursesById/"+body,options)
  }
  addCourse(course:any)
  {
    let body = JSON.stringify(course.value)
    let header = new HttpHeaders({ 'Content-Type': 'application/json', 'responseType':'text' })
    let options = { headers: header }
    return this.http.post(this.baseUrl+"mentor/addCourse",body,options)
  }
  getMySubscribers(id:any)
  {
    let body = id
    let header = new HttpHeaders({ 'Content-Type': 'application/json', 'responseType':'text' })
    let options = { headers: header }
    return this.http.get(this.baseUrl+"mentorTwo/getMySubscribers/"+body,options)
  }
  updateTrainingStatus(id:any,status:boolean)
  {
    let body = id+"/"+status
    let header = new HttpHeaders({ 'Content-Type': 'application/json', 'responseType':'text' })
    let options = { headers: header }
    return this.http.put(this.baseUrl+"training/updateTrainingStatus/"+body,options)
  }
}
