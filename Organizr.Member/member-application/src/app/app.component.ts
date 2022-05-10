import { Component, OnInit } from '@angular/core';
import { DataSharingService } from './services/data-sharing/data-sharing.service';
import { TokenStorageService } from './services/token-storage/token-storage.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  loggedInUser: string;

  constructor(private dataSharing: DataSharingService, private tokenStorage: TokenStorageService) {
    this.dataSharing.loggedInUser.subscribe(value => {
      this.loggedInUser = value;
    });
  }

  ngOnInit(): void {

    const userData = this.tokenStorage.getUser();

    if (userData) {
      this.dataSharing.isUserLoggedIn.next(true);
      this.dataSharing.loggedInUser.next(userData.email);
    }

  }
}