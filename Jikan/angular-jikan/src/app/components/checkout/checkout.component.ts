import { Component, OnInit } from '@angular/core';
import { CartService } from 'src/app/service/cart.service';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent implements OnInit {

  subTotal : number = this.cartService.getSubTotal();
  tax : number = this.cartService.getTax();
  total = this.subTotal + this.tax;

  constructor(private cartService : CartService) { }

  ngOnInit(): void {
  }

}
