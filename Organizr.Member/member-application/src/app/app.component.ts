import { Component, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { DataSharingService } from './data-sharing/data-sharing.service';
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

    if (this.tokenStorage.getToken()) {
      this.dataSharing.isUserLoggedIn.next(true);
      this.dataSharing.loggedInUser.next(this.tokenStorage.getToken());
    }
  }
}
