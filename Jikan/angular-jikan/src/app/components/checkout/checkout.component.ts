import { Component, OnInit } from '@angular/core';
import { CartService } from 'src/app/service/cart.service';
import { Order } from '../../models/Order';
import { OrderDetail } from '../../models/OrderDetail';



@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent implements OnInit {

  subTotal : number = this.cartService.getSubTotal();
  tax : number = this.cartService.getTax();
  total : number = this.subTotal + this.tax;
  date : Date;
  deliveryAddress : string = "";
  orderDetails : OrderDetail[] = [];
  firstName : string = "";
  lastName : string = "";
  email : string = "";
  city : string = "";
  postalCode : number;

  constructor(private cartService : CartService) { }

  ngOnInit(): void {
  }

  createOrder() {

    console.log(new Date())
    // let toAdd : Order = {
    //   total : this.total,
    //   date : new Date(),

    // } 

  }

}
