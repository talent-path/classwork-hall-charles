import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Order } from 'src/app/models/Order';
import { Watch } from 'src/app/models/Watch';
import { JikanService } from 'src/app/service/jikan.service';

@Component({
  selector: 'app-order-details-page',
  templateUrl: './order-details-page.component.html',
  styleUrls: ['./order-details-page.component.css']
})
export class OrderDetailsPageComponent implements OnInit {

  order : Order;
  id : number = 0;
  dateStr : string = "";
  items : Watch[] = [];
  quantities : number[] = [];
  count : number = 0;

  constructor(private jikanService : JikanService, private route : ActivatedRoute) { }

  ngOnInit(): void {
    this.route.params.subscribe(paramType => {
      this.id = paramType.id;
    });
    
    this.jikanService.getOrderById(this.id).subscribe(order => {
      this.order = order;    
      this.dateStr = this.order.date.toString().substring(0,10);
    });

    this.jikanService.getWatchesByOrderId(this.id).subscribe(watches => {
      this.items = watches;
    });

    this,this.jikanService.getWatchQuantityByOrderId(this.id).subscribe(quantities => {
      this.quantities = quantities;
    });

  }

}
