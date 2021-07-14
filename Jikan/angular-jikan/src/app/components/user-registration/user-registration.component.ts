import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { RegisterUserRequest } from 'src/app/models/RegisteredUserRequest';
import { AuthService } from 'src/app/service/auth.service';

@Component({
  selector: 'app-user-registration',
  templateUrl: './user-registration.component.html',
  styleUrls: ['./user-registration.component.css']
})
export class UserRegistrationComponent implements OnInit {

  username : string = "";
  email : string = "";
  name : string = "";
  password : string = "";
  confirmPass : string = "";

  constructor(private authService : AuthService, private router : Router) { }

  ngOnInit(): void {
  }

  submit() {

    if(this.password == this.confirmPass)
    {
      let toRegister : RegisterUserRequest = {
        Username : this.username,
        Name : this.name,
        Email : this.email,
        Password : this.password,
      }
      console.log(toRegister)

      this.authService.registerUser(toRegister).subscribe((_) => console.log(_));
      this.router.navigate([""]);

    }
  }

}
