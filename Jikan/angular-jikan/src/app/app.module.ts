import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomePageComponent } from './components/home-page/home-page.component';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { ItemDisplayComponent } from './components/item-display/item-display.component';
import { ItemDetailComponent } from './components/item-detail/item-detail.component';
import { SearchPageComponent } from './components/search-page/search-page.component';
import { ContactPageComponent } from './components/contact-page/contact-page.component';
import { CheckoutPageComponent } from './components/checkout-page/checkout-page.component';
import { CartComponent } from './components/cart/cart.component';

@NgModule({
  declarations: [
    AppComponent,
    HomePageComponent,
    NavBarComponent,
    ItemDisplayComponent,
    ItemDetailComponent,
    SearchPageComponent,
    ContactPageComponent,
    CheckoutPageComponent,
    CartComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
