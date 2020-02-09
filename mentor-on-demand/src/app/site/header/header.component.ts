import { Component, OnInit } from '@angular/core';
import { AuthServiceService } from 'src/app/service/auth-service.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  constructor(private authService: AuthServiceService, private router:Router) { }

  ngOnInit() {
  }

  getRole()
  {
    return this.authService.role
  }

  getUser()
  {
    return this.authService.loggedInUser
  }
  onLogout()
  {
    this.authService.onLogout()
    this.router.navigateByUrl('/login')
  }
}
