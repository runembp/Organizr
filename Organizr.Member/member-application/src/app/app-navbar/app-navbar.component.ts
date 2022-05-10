import { Component, OnInit } from '@angular/core';
import { DataSharingService } from '../services/data-sharing/data-sharing.service';
import { TokenStorageService } from '../services/token-storage/token-storage.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-app-navbar',
  templateUrl: './app-navbar.component.html',
  styleUrls: ['./app-navbar.component.css']
})
export class AppNavbarComponent implements OnInit {

  isUserLoggedIn: boolean;

  constructor(private dataSharing: DataSharingService, private tokenStorage: TokenStorageService, private router: Router) {
    this.dataSharing.isUserLoggedIn.subscribe(value => {
      this.isUserLoggedIn = value;
    });
   }

   signOut(): void {
     this.tokenStorage.signOut();
     window.location.reload();
   }

  ngOnInit(): void {
  }

}
