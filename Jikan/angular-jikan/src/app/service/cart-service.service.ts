import { Injectable } from '@angular/core';
import { Watch } from '../models/Watch';

@Injectable({
  providedIn: 'root'
})
export class CartServiceService {

  items : Watch[] = [];
  
  constructor() { }
}
