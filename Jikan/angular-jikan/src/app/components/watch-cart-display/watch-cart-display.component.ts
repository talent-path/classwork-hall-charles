import { Component, Input, OnInit } from '@angular/core';
import { Watch } from 'src/app/models/Watch';
import { CartService } from 'src/app/service/cart.service';

@Component({
  selector: 'app-watch-cart-display',
  templateUrl: './watch-cart-display.component.html',
  styleUrls: ['./watch-cart-display.component.css']
})
export class WatchCartDisplayComponent implements OnInit {

  @Input() watch : Watch;
  quantity : number = 0;

  constructor(private cartService : CartService) { }

  ngOnInit(): void {
    this.quantity = this.cartService.quantities[this.cartService.indexOf(this.watch)];
  }

  removeFromCart(toDelete : Watch) {
    this.cartService.removeItem(toDelete);
    window.alert('Your item has been removed from the cart!');
  }

  changeQuantity(quantityStr : string) {
    const quantityNum = parseInt(quantityStr);
    this.cartService.quantities[this.cartService.indexOf(this.watch)] = quantityNum;
    console.log(this.cartService.quantities);
  }

  


}
