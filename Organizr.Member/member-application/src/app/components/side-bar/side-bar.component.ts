import { Component, OnInit } from '@angular/core';
import { ApiClientService } from 'src/app/services/api-client/api-client.service';
import { TokenStorageService } from 'src/app/services/token-storage/token-storage.service';

@Component({
  selector: 'app-side-bar',
  templateUrl: './side-bar.component.html',
  styleUrls: ['./side-bar.component.css'],

})
export class SideBarComponent implements OnInit {

  isUserLoggedIn: boolean;

  constructor(private apiClient: ApiClientService, private tokenStorage: TokenStorageService) {

  }

  myGroups: any[];
  loggedInUser: any;

  ngOnInit(): void {
    this.loggedInUser = this.tokenStorage.getUser().id;

    this.apiClient.getMembersGroups(this.loggedInUser).subscribe(value => {
      this.myGroups = value.groups;
    });
    
  }
}