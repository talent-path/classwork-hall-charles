import { Component, OnInit } from '@angular/core';
import { Watch } from '../../models/Watch';
import { JikanService } from 'src/app/service/jikan.service';

@Component({
  selector: 'app-watches-list',
  templateUrl: './watches-list.component.html',
  styleUrls: ['./watches-list.component.css']
})
export class WatchesListComponent implements OnInit {

  watches: Watch[] = [];

  constructor(private jikanService : JikanService) { }

  ngOnInit(): void {
    this.jikanService.getAllWatches().subscribe(list => {
      this.watches = list;
    });
  }

}
