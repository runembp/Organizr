import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { DataSharingService } from 'src/app/services/shared/data-sharing.service';

const USER = 'user';

@Injectable({
  providedIn: 'root'
})
export class TokenStorageService {

  constructor(private dataSharing: DataSharingService, private router: Router) { }

  public signOut(): void {
    window.localStorage.clear();
    this.dataSharing.isUserLoggedIn.next(false);
    this.router.navigateByUrl('/');
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