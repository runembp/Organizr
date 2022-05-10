import { Injectable } from '@angular/core';
import { DataSharingService } from 'src/app/services/data-sharing/data-sharing.service';

const USER = 'user';

@Injectable({
  providedIn: 'root'
})
export class TokenStorageService {

  constructor(private dataSharing: DataSharingService) { }

  public signOut(): void {
    window.localStorage.clear();
    this.dataSharing.isUserLoggedIn.next(false);
  }

  public saveUser(user: any): void {
    window.localStorage.removeItem(USER);
    window.localStorage.setItem(USER, user);
  }

  public getUser(): any | null {

    const user = window.localStorage.getItem(USER);

    if (user) return JSON.parse(user);

    return null;
  }

}