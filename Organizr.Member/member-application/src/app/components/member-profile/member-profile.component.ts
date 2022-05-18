import { Component, OnInit } from '@angular/core';
import { TokenStorageService } from 'src/app/services/token-storage/token-storage.service';
import { ApiClientService } from 'src/app/services/api-client/api-client.service';
import { NotificationServiceService } from 'src/app/services/notification-message/notification-service.service';
import { NotificationType } from 'src/app/notification.message';

@Component({
  selector: 'app-member-profile',
  templateUrl: './member-profile.component.html',
  styleUrls: ['./member-profile.component.css']
})
export class MemberProfileComponent implements OnInit {


  loggedInUser: number;

  constructor(private tokenStorage: TokenStorageService,
    private apiClient: ApiClientService,
    private notificationService: NotificationServiceService) { }

  firstName: string;
  lastName: string;
  phoneNumber: string;
  email: string;
  address: string;
  gender: string;


  ngOnInit(): void {
    this.loggedInUser = this.tokenStorage.getUser().id;

    this.apiClient.getMemberById(this.loggedInUser).subscribe(user => {
      this.firstName = user.firstName;
      this.lastName = user.lastName;
      this.phoneNumber = user.phoneNumber;
      this.email = user.email;
      this.address = user.address;
      this.gender = user.gender;
    });
  }

  deleteMember(memberId: number): void {
    if (confirm("Er du sikker på, at du vil slette din bruger?")) {

      this.apiClient.deleteMemberById(memberId).subscribe(response => {
        if (response.succeeded) {
          this.notificationService.sendMessage({
            message: "Din profil er blevet slettet.",
            type: NotificationType.success
          });
          this.tokenStorage.signOut();
        }
      });
    }
  }
}
