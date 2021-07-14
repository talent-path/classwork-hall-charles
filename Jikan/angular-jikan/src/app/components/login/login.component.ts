import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginRequest } from 'src/app/models/LoginRequest';
import { AuthService } from 'src/app/service/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  username : string = "";
  password : string = "";

  constructor(private authService : AuthService, private router : Router) { }

  ngOnInit(): void {
  }

  submit() {
    let toLogin : LoginRequest = {
      Username : this.username,
      Password : this.password
    }
    console.log(toLogin);

    this.authService.loginUser(toLogin);
    this.router.navigate([""]);
  }

}
