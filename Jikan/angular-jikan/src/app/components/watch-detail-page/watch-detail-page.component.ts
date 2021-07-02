import { Component, OnInit } from '@angular/core';
import { Watch } from 'src/app/models/Watch';
import { JikanService } from 'src/app/service/jikan.service';
import { ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-watch-detail-page',
  templateUrl: './watch-detail-page.component.html',
  styleUrls: ['./watch-detail-page.component.css']
})
export class WatchDetailPageComponent implements OnInit {

  watch : Watch;
  id : number = 0;

  constructor(private jikanService : JikanService, private route : ActivatedRoute) { }

  ngOnInit(): void {
    this.route.params.subscribe(paramType => {
      this.id = paramType.id;
    });
    
    this.jikanService.getWatchById(this.id).subscribe(watch => {
      this.watch = watch;
    });
  }

}
