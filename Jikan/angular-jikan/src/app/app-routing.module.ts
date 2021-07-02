import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomePageComponent } from './components/home-page/home-page.component';
import { OrdersListComponent } from './components/orders-list/orders-list.component';
import { TypeWatchListComponent } from './components/type-watch-list/type-watch-list.component';
import { WatchesListComponent } from './components/watches-list/watches-list.component';

const routes: Routes = [
  { path: 'watches', component: WatchesListComponent },
  { path: 'orders', component: OrdersListComponent },
  {path: 'home', component: HomePageComponent },
  { path: 'watches/type/:type', component: TypeWatchListComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
