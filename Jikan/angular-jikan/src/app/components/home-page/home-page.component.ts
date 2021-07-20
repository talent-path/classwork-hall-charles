import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/service/auth.service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {

  signedIn : boolean = false;

  constructor(private authService : AuthService) { }

  ngOnInit(): void {
    this.authService.loggedInEvent.subscribe((signedIn) => this.signedIn = signedIn);
  }
}
