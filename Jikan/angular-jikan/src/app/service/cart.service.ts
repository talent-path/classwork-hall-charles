import { Injectable } from '@angular/core';
import { Watch } from '../models/Watch';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  
  items : Watch[] = [];
  quantities : number[] = [];
  
  constructor() { }

  addToCart(item: Watch, quantity : number) {
    this.items.push(item);
    this.quantities.push(quantity);
  }

  getItems() {
    return this.items;
  }

  getQuantities() {
    return this.quantities;
  }

  clearCart() {
    this.items = [];
    this.quantities = [];
    console.log(this.items)
    console.log(this.quantities);
    return this.items;
  }

  getSubTotal() {
    var sum = 0;
    for(var i = 0; i < this.items.length; i++) {
      sum += this.items[i].price * this.quantities[i];
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
        this.quantities.splice(i, 1);
      }
    }
  }

  indexOf(watch : Watch) : number {
    return this.items.indexOf(watch);
  }
  
}
