import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomePageComponent } from './components/home-page/home-page.component';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { SearchPageComponent } from './components/search-page/search-page.component';
import { ContactPageComponent } from './components/contact-page/contact-page.component';
import { CheckoutPageComponent } from './components/checkout-page/checkout-page.component';
import { CartComponent } from './components/cart/cart.component';
import { OrdersListComponent } from './components/orders-list/orders-list.component';
import { WatchesListComponent } from './components/watches-list/watches-list.component';
import { WatchDisplayComponent } from './components/watch-display/watch-display.component';
import { WatchDetailDisplayComponent } from './components/watch-detail-display/watch-detail-display.component';

@NgModule({
  declarations: [
    AppComponent,
    HomePageComponent,
    NavBarComponent,
    SearchPageComponent,
    ContactPageComponent,
    CheckoutPageComponent,
    CartComponent,
    OrdersListComponent,
    WatchesListComponent,
    WatchDisplayComponent,
    WatchDetailDisplayComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
