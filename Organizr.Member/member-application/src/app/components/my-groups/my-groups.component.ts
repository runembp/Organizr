import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ApiClientService } from 'src/app/services/api-client/api-client.service';
import { NotificationType } from 'src/app/notification.message';
import { NotificationServiceService } from 'src/app/services/notification-message/notification-service.service';

@Component({
  selector: 'app-my-groups',
  templateUrl: './my-groups.component.html',
  styleUrls: ['./my-groups.component.css']
})
export class MyGroupsComponent implements OnInit {

  constructor(private apiClient: ApiClientService, private notificationService: NotificationServiceService) { }

  @Input() userId: any;
  @Input() groups: any[];

  @Output() memberIsRemovedFromGroup = new EventEmitter<any>();

  ngOnInit(): void {

  }

  leaveGroup(groupId: number, memberId: number, groupName: string): void {
    this.apiClient.removedMemberFromGroup(groupId, memberId).subscribe(response => {
      if (response.succeeded) {
        this.notificationService.sendMessage({
          message: `Du har forladt gruppen ${groupName}`,
          type: NotificationType.warning
        });
        this.memberIsRemovedFromGroup.emit();
      }
    });
  }

}
