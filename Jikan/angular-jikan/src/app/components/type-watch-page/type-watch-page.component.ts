import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-type-watch-page',
  templateUrl: './type-watch-page.component.html',
  styleUrls: ['./type-watch-page.component.css']
})
export class TypeWatchPageComponent implements OnInit {

  type : string = "";

  constructor(private route : ActivatedRoute) { }

  ngOnInit(): void {
    this.route.params.subscribe(paramType => {
      this.type = paramType.type;
    });
  }

}
