import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutUsPageComponent } from './components/about-us-page/about-us-page.component';
import { CartComponent } from './components/cart/cart.component';
import { ContactPageComponent } from './components/contact-page/contact-page.component';
import { HomePageComponent } from './components/home-page/home-page.component';
import { OrderDetailsPageComponent } from './components/order-details-page/order-details-page.component';
import { OrdersListComponent } from './components/orders-list/orders-list.component';
import { SearchPageComponent } from './components/search-page/search-page.component';
import { TypeWatchPageComponent } from './components/type-watch-page/type-watch-page.component';
import { WatchDetailPageComponent } from './components/watch-detail-page/watch-detail-page.component';
import { WatchesListComponent } from './components/watches-list/watches-list.component';

const routes: Routes = [
  { path: 'watches', component: WatchesListComponent },
  { path: 'orders', component: OrdersListComponent },
  { path: '', component: HomePageComponent },
  { path: 'watches/type/:type', component: TypeWatchPageComponent },
  { path: 'contact', component: ContactPageComponent },
  { path: 'search', component: SearchPageComponent },
  { path: 'watch/detail/:id', component: WatchDetailPageComponent },
  { path: 'about', component: AboutUsPageComponent },
  { path: 'cart', component: CartComponent },
  { path: 'order/details', component: OrderDetailsPageComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
