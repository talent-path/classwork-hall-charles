import { Injectable } from '@angular/core';
import { Watch } from '../models/Watch';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  
  items : Watch[] = [];
  
  constructor() { }

  addToCart(item: Watch) {
    this.items.push(item);
  }

  getItems() {
    return this.items;
  }

  clearCart() {
    this.items = [];
    return this.items;
  }

  getSubTotal() {
    var sum = 0;
    for(var i = 0; i < this.items.length; i++) {
      sum += this.items[i].price;
    }
    return sum;
  }

  getTax() {
    return this.getSubTotal() * 0.07;
  }

  removeItem(watch : Watch) {
    for(var i = 0; i < this.items.length; i++) {
      if(this.items[i].id == watch.id) {
        this.items.splice(i, 1);
      }
    }
  }
  
}
