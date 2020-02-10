import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AuthServiceService {

  loggedInUser
  role: string
  baseUrl = 'http://localhost:1477/api/'
  constructor(private http: HttpClient) { }

  authenticate(credentials:any)
  {
    let body = JSON.stringify(credentials.value)
    let header = new HttpHeaders({ 'Content-Type': 'application/json', 'responseType':'text' })
    let options = { headers: header }
    return this.http.post(this.baseUrl+"auth/login",body,options)
  }
  register(user:any)
  {
    let body = JSON.stringify(user.value)
    let header = new HttpHeaders({ 'Content-Type': 'application/json', 'responseType':'text' })
    let options = { headers: header }
    return this.http.post(this.baseUrl+"auth/register",body,options)
  }
  checkUserName(userName:string)
  {
    let body = userName
    let header = new HttpHeaders({ 'Content-Type': 'application/json', 'responseType':'text' })
    let options = { headers: header }
    return this.http.get(this.baseUrl+"auth/checkUserName/"+body,options)
  }
  onLogout()
  {
    this.loggedInUser = null
    this.role = null
  }
}
