import { Component, OnInit } from '@angular/core';
import { Order } from 'src/app/models/Order';
import { JikanService } from 'src/app/service/jikan.service';

@Component({
  selector: 'app-orders-list',
  templateUrl: './orders-list.component.html',
  styleUrls: ['./orders-list.component.css']
})
export class OrdersListComponent implements OnInit {

  orders : Order[] = [];

  constructor(private jikanService : JikanService) { }

  ngOnInit(): void {
    this.jikanService.getAllOrders().subscribe(list => {
      this.orders = list;
    });
  }

}
