import { Injectable } from '@angular/core';
import { ReplaySubject } from 'rxjs';
import { Watch } from '../models/Watch';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  
  items : Watch[] = [];
  quantities : number[] = [];
  count = 0;
  private cartCount = new ReplaySubject<number>(1);
  cartCount$ = this.cartCount.asObservable();
  
  constructor() { }

  addCount() {
    this.count += 1;
    this.cartCount.next(this.count);
  }

  removeCount() {
    if(this.count > 0) {
      this.count -= 1;
    }
    this.cartCount.next(this.count);
  }

  clearCount() {
    this.count = 0;
    this.cartCount.next(this.count);
  }

  getCount() {
    return this.cartCount$;
  }

  addToCart(item: Watch, quantity : number) {
    this.items.push(item);
    this.quantities.push(quantity);
    this.addCount();
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
    this.clearCount();
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
        this.removeCount();
      }
    }
  }

  indexOf(watch : Watch) : number {
    return this.items.indexOf(watch);
  }
  
}
