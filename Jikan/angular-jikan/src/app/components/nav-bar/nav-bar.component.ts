import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/service/auth.service';
import { CartService } from 'src/app/service/cart.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {

  totalItem = 0;
  signedIn : boolean = false;


  constructor(private cartService : CartService, private authService : AuthService) { }

  ngOnInit(): void {
    this.cartService.getCount().subscribe(
      count => {
        this.totalItem = count;
      }
    );

    this.signedIn = this.authService.isSignedIn();

    this.authService.loggedInEvent.subscribe((signedIn) => this.signedIn = signedIn);
  }

  signOut() {
    this.authService.signOut();
  }
}
