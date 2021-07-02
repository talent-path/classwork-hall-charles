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
import { JikanService } from './service/jikan.service';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { TypeWatchListComponent } from './components/type-watch-list/type-watch-list.component';
import { FooterComponent } from './components/footer/footer.component';
import { ContactFormComponent } from './components/contact-form/contact-form.component';
import { WatchDetailPageComponent } from './components/watch-detail-page/watch-detail-page.component';
import { AddToCartComponent } from './components/add-to-cart/add-to-cart.component';
import { OrderDisplayComponent } from './components/order-display/order-display.component';

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
    WatchDetailDisplayComponent,
    TypeWatchListComponent,
    FooterComponent,
    ContactFormComponent,
    WatchDetailPageComponent,
    AddToCartComponent,
    OrderDisplayComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  exports: [
    HomePageComponent
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
