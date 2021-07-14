import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CartService } from 'src/app/service/cart.service';
import { JikanService } from 'src/app/service/jikan.service';
import { Order } from '../../models/Order';
import { User } from 'src/app/models/User';
import { OrderDetail } from '../../models/OrderDetail';
import { OrderDetailsPageComponent } from '../order-details-page/order-details-page.component';
import { AuthService } from 'src/app/service/auth.service';



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
  userToAdd : User;

  constructor(private cartService : CartService, private jikanService : JikanService, private router : Router, private authService : AuthService) { }

  ngOnInit(): void {
    this.userToAdd  = {
      id : 0,
      username : this.authService.userCreds?.username,
      email : "",
      name : "",
      passwordHash : [],
      passwordSalt : []
    }
  }

  createOrder() {

    let toAdd : Order = {
      total : this.total,
      date : new Date(),
      deliveryAddress : this.deliveryAddress,
      orderDetails : this.setOrderDetails(),
      name : this.firstName + " " + this.lastName,
      email : this.email,
      city : this.city,
      postalCode : this.postalCode,
      purchaser : this.userToAdd
    } 

    this.jikanService.createOrder(toAdd).subscribe((_) => {this.router.navigate(["/orders"])});
    this.cartService.clearCart();
  }

  setOrderDetails() : OrderDetail[] {
    let orderDetails : OrderDetail [] = [];

    for(var i = 0; i < this.cartService.items.length; i++) {
        let orderDetail : OrderDetail = { 
          watchId : this.cartService.items[i].id, 
          quantity :  this.cartService.quantities[i]
        }
      orderDetails.push(orderDetail);
    }

    return orderDetails;
  }

}
