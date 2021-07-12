import { Component, OnInit } from '@angular/core';
import { CartService } from 'src/app/service/cart.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {

  totalItem = 0;

  constructor(private cartService : CartService) { }

  ngOnInit(): void {
    this.cartService.getCount().subscribe(
      count => {
        this.totalItem = count;
        console.log(count);
      }
    );

  }

}
