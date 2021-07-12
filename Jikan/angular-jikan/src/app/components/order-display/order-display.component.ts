import { Component, Input, OnInit } from '@angular/core';
import { Order } from 'src/app/models/Order';

@Component({
  selector: 'app-order-display',
  templateUrl: './order-display.component.html',
  styleUrls: ['./order-display.component.css']
})
export class OrderDisplayComponent implements OnInit {

  @Input() order : Order; 
  dateStr : string = "";

  constructor() { }

  ngOnInit(): void {
    this.dateStr = this.order.date.toString().substring(0,10);
  }


}
