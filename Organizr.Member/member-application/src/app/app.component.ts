import { Component, OnInit } from '@angular/core';
import { ApiClientService } from './services/api-client/api-client.service';
import { DataSharingService } from './services/shared/data-sharing.service';
import { TokenStorageService } from './services/token-storage/token-storage.service';
import { ConfigurationConstantsService } from './services/shared/configuration-constants.service';

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
      this.configService.organizationPhoneNumber.next(value[1].stringValue);
      this.configService.organizationEmailAddress.next(value[2].stringValue);
      this.configService.predeterminedGroupToAssignNewMembersTo.next(value[3].idValue);
      this.configService.activateCommentsOnNews.next(value[4].boolValue);
      this.configService.activateAdministratorMemberAbilityToCommentOnNews.next(value[5].boolValue);
      this.configService.activateBasicMemberAbilityToCommentOnNews.next(value[6].boolValue);
      this.configService.activateAbilityForAllMembersToCreateNews.next(value[7].boolValue);
      this.configService.frontpageTopTextBox.next(value[8].stringValue);
      this.configService.loginForgottenPassword.next(value[9]);
      this.configService.aboutUsPage.next(value[10].stringValue);
      this.configService.contactPageTopTextBox.next(value[11].stringValue);
      this.configService.contactPageLeftTextBox.next(value[12].stringValue);
      this.configService.createMembershipTopText.next(value[13].stringValue);
      this.configService.memberApplicationCss.next(value[14].stringValue);
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