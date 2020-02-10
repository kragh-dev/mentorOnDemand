import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserServiceService {

  baseUrl = 'http://localhost:11567/api/'
  constructor(private http: HttpClient) { }

  getCourses()
  {
    let header = new HttpHeaders({ 'Content-Type': 'application/json', 'responseType':'text' })
    let options = { headers: header }
    return this.http.get(this.baseUrl+"user/getCourses",options)
  }
  getTraining(id)
  {
    let body = id
    let header = new HttpHeaders({ 'Content-Type': 'application/json', 'responseType':'text' })
    let options = { headers: header }
    return this.http.get(this.baseUrl+"user/getTraining/"+body,options)
  }
  addTraining(id:number,userId:number,userName:string)
  {
    let body = id+"/"+userId+"/"+userName;
    let header = new HttpHeaders({ 'Content-Type': 'application/json', 'responseType':'text' })
    let options = { headers: header }
    return this.http.get(this.baseUrl+"user/proposeTraining/"+body,options)
  }
  getMyTrainings(id:any)
  {
    let body = id
    let header = new HttpHeaders({ 'Content-Type': 'application/json', 'responseType':'text' })
    let options = { headers: header }
    return this.http.get(this.baseUrl+"user/getMyTrainings/"+body,options)
  }
  payForTraining(id, userId, amount)
  {
    let body = id+"/"+userId+"/"+amount
    let header = new HttpHeaders({ 'Content-Type': 'application/json', 'responseType':'text' })
    let options = { headers: header }
    return this.http.put(this.baseUrl+"user/payForTraining/"+body,options)
  }
  completeTraining(id, progress)
  {
    let body = id+"/"+progress
    let header = new HttpHeaders({ 'Content-Type': 'application/json', 'responseType':'text' })
    let options = { headers: header }
    return this.http.put(this.baseUrl+"userTwo/completeTraining/"+body,options)
  }
}
