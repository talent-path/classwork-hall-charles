import { Injectable } from '@angular/core';
import { Watch } from '../models/Watch';

@Injectable({
  providedIn: 'root'
})
export class CartServiceService {

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
}
