import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LoginRequest } from '../models/LoginRequest';
import { RegisterUserRequest } from '../models/RegisteredUserRequest';
import { UserCredentials } from '../models/UserCredentials';
import { Output, EventEmitter } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  userCreds : UserCredentials | null = null;
  @Output() loggedInEvent : EventEmitter<boolean> = new EventEmitter<boolean>();

  baseUrl : string = "https://localhost:44302/api/user"
  httpOptions = {headers: new HttpHeaders({"Content-Type": "application/json"})}

  constructor(private http : HttpClient) { }

  registerUser(user : RegisterUserRequest) : Observable<boolean> {
    return this.http.post<boolean>(this.baseUrl, user, this.httpOptions);
  }

  loginUser(user : LoginRequest) {
    this.http.post<UserCredentials>(this.baseUrl + "/login", user, this.httpOptions)
    .subscribe(c => this.saveUserAndToken(c));
  }

  saveUserAndToken(c : UserCredentials) {
    this.loggedInEvent.emit(true);
    this.userCreds = c;
  }

  isSignedIn() : boolean {
    return this.userCreds != null;
  }

  signOut() {
    this.userCreds = null;
    this.loggedInEvent.emit(false);
  }

}
