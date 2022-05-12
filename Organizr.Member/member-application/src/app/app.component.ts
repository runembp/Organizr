import { Component, OnInit } from '@angular/core';
import { ApiClientService } from './services/api-client/api-client.service';
import { DataSharingService } from './services/data-sharing/data-sharing.service';
import { TokenStorageService } from './services/token-storage/token-storage.service';
import { ConfigurationConstantsService } from './services/data-sharing/configuration-constants.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  loggedInUser: string;

  constructor(private dataSharing: DataSharingService,
    private tokenStorage: TokenStorageService,
    private configService: ConfigurationConstantsService,
    private apiClient: ApiClientService) {
    this.dataSharing.loggedInUser.subscribe(value => {
      this.loggedInUser = value;
    });

    this.apiClient.getAllConfigurations().subscribe(value => {
      this.configService.organizationAddress.next(value[0].stringValue);
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