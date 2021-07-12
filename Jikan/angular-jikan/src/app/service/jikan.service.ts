import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import {tap, catchError} from 'rxjs/operators';
import { Watch } from '../models/Watch';
import { Order } from '../models/Order';

@Injectable({
  providedIn: 'root'
})
export class JikanService {

  baseUrl : string = "https://localhost:44302/api"
  httpOptions = {headers: new HttpHeaders({"Content-Type": "application/json"})}

  constructor(private http : HttpClient) { }

  getAllWatches() : Observable<Watch[]> {
    return this.http.get<Watch[]>(this.baseUrl + "/watch")
    .pipe(
      tap(x => console.log(x)),
      catchError(err => {
        console.log(err);
        let empty : Watch[] = [];
        return of(empty);
      })
    );
  }

  getWatchById(id : number) : Observable<Watch> {
    return this.http.get<Watch>(this.baseUrl + "/watch/" + id);
  }

  getWatchByName(name : string) : Observable<Watch> {
    return this.http.get<Watch>(this.baseUrl + "/watch/name/" + name);
  }

  getWatchesByType(type : string) : Observable<Watch[]> {
    return this.http.get<Watch[]>(this.baseUrl + "/watch/type/" + type);
  }

  getWatchesByOrderId(id : number) : Observable<Watch[]> {
    return this.http.get<Watch[]>(this.baseUrl + "/watch/order/" + id)
    .pipe(
      tap(x => console.log(x)),
      catchError(err => {
        console.log(err);
        let empty : Watch[] = [];
        return of(empty);
      })
    );
  }

  getWatchQuantityByOrderId(id : number) : Observable<number[]> {
    return this.http.get<number[]>(this.baseUrl + "/watch/order/quantity/" + id)
    .pipe(
      tap(x => console.log(x)),
      catchError(err => {
        console.log(err);
        let empty : number[] = [];
        return of(empty);
      })
    );
  }
  createOrder(toAdd : Order) : Observable<Order> {
    return this.http.post<Order>(this.baseUrl + "/order", toAdd, this.httpOptions).pipe(
      tap(x => console.log(x)),
      catchError(err => {
        alert(err.error);
        let empty : Order = {
          total : 0,
          date : new Date(),
          deliveryAddress : "",
          orderDetails : [],
          name : "",
          email : "",
          city : "",
          postalCode : 0
        };
        return of(empty);
      })
    );
  }

  getAllOrders() : Observable<Order[]> {
    return this.http.get<Order[]>(this.baseUrl + "/order")
    .pipe(
      tap(x => console.log(x)),
      catchError(err => {
        console.log(err);
        let empty : Order[] = [];
        return of(empty);
      })
    );
  }

  getOrderById(id : number) : Observable<Order> {
    return this.http.get<Order>(this.baseUrl + "/order/" + id).pipe(
      tap(x => console.log(x)),
      catchError(err => {
        alert(err.error);
        let empty : Order = {
          total : 0,
          date : new Date(),
          deliveryAddress : "",
          orderDetails : [],
          name : "",
          email : "",
          city : "",
          postalCode : 0
        };
        return of(empty);
      })
    );;
  }

}
