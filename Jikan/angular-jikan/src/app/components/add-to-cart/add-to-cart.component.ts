import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Watch } from 'src/app/models/Watch';
import { CartServiceService } from 'src/app/service/cart-service.service';

@Component({
  selector: 'app-add-to-cart',
  templateUrl: './add-to-cart.component.html',
  styleUrls: ['./add-to-cart.component.css']
})
export class AddToCartComponent implements OnInit {

  @Input() watch : Watch;

  constructor(private route : ActivatedRoute, private cartService : CartServiceService) { }

  ngOnInit(): void {
  }

  addToCart(item : Watch) {
    this.cartService.addToCart(item);
    window.alert('Your item has been added to the cart!');
  }

}
