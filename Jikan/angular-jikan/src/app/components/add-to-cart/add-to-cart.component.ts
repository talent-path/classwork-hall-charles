import { Component, Input, OnInit } from '@angular/core';
import { Watch } from 'src/app/models/Watch';
import { CartService } from 'src/app/service/cart.service';

@Component({
  selector: 'app-add-to-cart',
  templateUrl: './add-to-cart.component.html',
  styleUrls: ['./add-to-cart.component.css']
})
export class AddToCartComponent implements OnInit {

  @Input() watch : Watch;
  quantity : number = 1;

  constructor(private cartService : CartService) { }

  ngOnInit(): void {
  }

  addToCart(item : Watch) {
    this.cartService.addToCart(item, this.quantity);
    window.alert('Your item has been added to the cart!');
  }

  changeQuantity(quantityStr : string) {
    const quantityNum = parseInt(quantityStr);
    this.quantity = quantityNum;
  }

}
