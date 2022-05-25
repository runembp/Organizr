import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MembersApiClientService } from 'src/app/services/api-client/members/members-api-client.service';
import { TokenStorageService } from 'src/app/services/token-storage/token-storage.service';
import { NewspostsApiClientService } from 'src/app/services/api-client/newsposts/newsposts-api-client.service';
import { NotificationServiceService } from 'src/app/services/notification-message/notification-service.service';
import { NotificationType } from 'src/app/notification.message';

@Component({
  selector: 'app-create-newspost',
  templateUrl: './create-newspost.component.html',
  styleUrls: ['./create-newspost.component.css']
})
export class CreateNewspostComponent implements OnInit {

  constructor(private tokenStorage: TokenStorageService, private memberApiClient: MembersApiClientService,
    private newspostApiClient: NewspostsApiClientService, private notificationService: NotificationServiceService,) { }

  myGroups: any[] = [];
  memberships: any[] = [];
  loggedInUserId: number;
  newNewsPostForm: FormGroup;

  ngOnInit(): void {

    this.loggedInUserId = this.tokenStorage.getUser().id;

    this.memberApiClient.getMembersGroups(this.loggedInUserId).subscribe(member => {
      this.memberships = member.memberships;
      this.myGroups = this.memberships.map(x => x);
    });

    this.newNewsPostForm = new FormGroup({
      group: new FormControl('', Validators.required),
      title: new FormControl('', Validators.required),
      content: new FormControl('', Validators.required),
      isPublic: new FormControl(false)
    });

  }

  onSubmit(): void {
    const newspost = {
      title: this.newNewsPostForm.get('title')?.value,
      content: this.newNewsPostForm.get('content')?.value,
      isPublic: this.newNewsPostForm.get('isPublic')?.value,
      memberId: Number(this.loggedInUserId),
      memberGroupId: Number(this.newNewsPostForm.get('group')?.value),

    };

    this.newspostApiClient.createNewspost(newspost).subscribe(response => {
      if (response.succeeded) {
        this.notificationService.sendMessage({
          message: "Din nyhed er blevet oprettet",
          type: NotificationType.success
        });

        this.newNewsPostForm.reset();
      }

    })
  };

}
