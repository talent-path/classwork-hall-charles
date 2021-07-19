import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginRequest } from 'src/app/models/LoginRequest';
import { AuthService } from 'src/app/service/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private authService : AuthService, private router : Router) { }

  ngOnInit(): void {
  }

  submit(loginForm : NgForm) {
    if(loginForm.valid) {
      const user = loginForm.value;

      let toLogin : LoginRequest = {
        Username : user.username,
        Password : user.password
      }

      this.authService.loginUser(toLogin);
      this.router.navigate([""]);
    }
  }

}
