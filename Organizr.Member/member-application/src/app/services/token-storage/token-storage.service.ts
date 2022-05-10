import { Injectable } from '@angular/core';
import { DataSharingService } from 'src/app/data-sharing/data-sharing.service';

const TOKEN_KEY = 'auth-token';

@Injectable({
  providedIn: 'root'
})
export class TokenStorageService {

  constructor(private dataSharing: DataSharingService) { }

  signOut(): void {
    window.localStorage.clear();
    this.dataSharing.isUserLoggedIn.next(false);
  }

  public saveToken(token: string): void {
    window.localStorage.removeItem(TOKEN_KEY);
    window.localStorage.setItem(TOKEN_KEY, token);
  }

  public getToken(): string | null {

    const token = window.localStorage.getItem(TOKEN_KEY);

    if (token) return token;

    return null;
  }


}
