import { Component, Input, OnInit } from '@angular/core';
import { Watch } from 'src/app/models/Watch';

@Component({
  selector: 'app-watch-cart-display',
  templateUrl: './watch-cart-display.component.html',
  styleUrls: ['./watch-cart-display.component.css']
})
export class WatchCartDisplayComponent implements OnInit {

  @Input() watch : Watch;

  constructor() { }

  ngOnInit(): void {
  }

}
