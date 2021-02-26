import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { TictactoeBoardComponent } from './tictactoe-board/tictactoe-board.component';
import { TictactoeSquareComponent } from './tictactoe-square/tictactoe-square.component';
import { TictactoePageComponent } from './tictactoe-page/tictactoe-page.component';

@NgModule({
  declarations: [
    AppComponent,
    TictactoeBoardComponent,
    TictactoeSquareComponent,
    TictactoePageComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
