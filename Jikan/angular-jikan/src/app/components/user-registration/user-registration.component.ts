import { Component, OnInit } from '@angular/core';
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

  constructor(private authService : AuthService) { }

  ngOnInit(): void {
  }

  submit() {

    let toRegister : RegisterUserRequest = {
      Username : this.username,
      Name : this.name,
      Email : this.email,
      Password : this.password,
    }

    this.authService.registerUser(toRegister).subscribe((_) => console.log(_));
  }

}
