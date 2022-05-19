import { Component, OnInit } from '@angular/core';
import { ApiClientService } from './services/api-client/api-client.service';
import { DataSharingService } from './services/shared/data-sharing.service';
import { TokenStorageService } from './services/token-storage/token-storage.service';
import { ConfigurationConstantsService } from './services/shared/configuration-constants.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { AuthService } from './services/authentication/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  constructor(private dataSharing: DataSharingService,
    private tokenStorage: TokenStorageService,
    private configService: ConfigurationConstantsService,
    private apiClient: ApiClientService, private router: Router,
    private authService: AuthService
  ) {

    this.apiClient.getAllConfigurations().subscribe(configurations => {
      this.configService.organizationAddress.next(configurations.find(({ id }) => id === 1).stringValue);
      this.configService.organizationPhoneNumber.next(configurations.find(({ id }) => id === 2).stringValue);
      this.configService.organizationEmailAddress.next(configurations.find(({ id }) => id === 4).stringValue);
      this.configService.predeterminedGroupToAssignNewMembersTo.next(configurations.find(({ id }) => id === 5).idValue);
      this.configService.activateCommentsOnNews.next(configurations.find(({ id }) => id === 5).boolValue);
      this.configService.activateAdministratorMemberAbilityToCommentOnNews.next(configurations.find(({ id }) => id === 6).boolValue);
      this.configService.activateBasicMemberAbilityToCommentOnNews.next(configurations.find(({ id }) => id === 7).boolValue);
      this.configService.activateAbilityForAllMembersToCreateNews.next(configurations.find(({ id }) => id === 8).boolValue);
      this.configService.frontpageTopTextBox.next(configurations.find(({ id }) => id === 9).stringValue);
      this.configService.loginForgottenPassword.next(configurations[9]);
      this.configService.aboutUsPage.next(configurations.find(({ id }) => id === 11).stringValue);
      this.configService.contactPageTopTextBox.next(configurations.find(({ id }) => id === 12).stringValue);
      this.configService.contactPageLeftTextBox.next(configurations.find(({ id }) => id === 13).stringValue);
      this.configService.createMembershipTopText.next(configurations.find(({ id }) => id === 14).stringValue);
      this.configService.memberApplicationCss.next(configurations.find(({ id }) => id === 15).stringValue);
    });

  }

  ngOnInit(): void {
    const userData = this.tokenStorage.getUser();

    if (userData) {

      this.dataSharing.isUserLoggedIn.next(true);
      this.dataSharing.loggedInUser.next(userData.email);
      this.authService.setUserIsAuthenticated(true);
      this.router.navigate(["/user"]);
    }

  }

}