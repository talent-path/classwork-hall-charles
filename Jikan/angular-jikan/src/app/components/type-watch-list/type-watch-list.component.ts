import { Component, OnInit } from '@angular/core';
import { JikanService } from 'src/app/service/jikan.service';
import { Watch } from '../../models/Watch';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-type-watch-list',
  templateUrl: './type-watch-list.component.html',
  styleUrls: ['./type-watch-list.component.css']
})
export class TypeWatchListComponent implements OnInit {

  watches : Watch[] = [];
  type : string = "";

  constructor(private jikanService : JikanService, private route : ActivatedRoute) { }

  ngOnInit(): void {
    this.route.params.subscribe(paramType => {
      this.type = paramType.type;
    });
    
    this.jikanService.getWatchesByType(this.type).subscribe(list => {
      this.watches = list;
    });
  }

}
