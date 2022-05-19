import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private isAuthenticated: boolean;

  constructor() { }

  public isUserAuthenticated(): boolean {
    return this.isAuthenticated;
  }

  public setUserIsAuthenticated(isAuth: boolean){
    this.isAuthenticated = isAuth;
  }

}