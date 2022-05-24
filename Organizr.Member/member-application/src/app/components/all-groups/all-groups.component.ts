import { Component, Input, Output, EventEmitter } from '@angular/core';
import { NotificationType } from 'src/app/notification.message';
import { MembergroupsApiClientService } from 'src/app/services/api-client/membergroups/membergroups-api-client.service';
import { NotificationServiceService } from 'src/app/services/notification-message/notification-service.service';

@Component({
  selector: 'app-all-groups',
  templateUrl: './all-groups.component.html',
  styleUrls: ['./all-groups.component.css']
})
export class AllGroupsComponent {

  constructor(private apiClient: MembergroupsApiClientService, private  notificationService: NotificationServiceService) { }

  @Input() groups: any[];
  @Input() userId: any;

  @Output() memberIsAddedToGroup = new EventEmitter<any>();

  joinGroup(groupId: number, memberId: number, groupName: string): void {
    
    let membership = { groupId: groupId, memberId: memberId, roleId: 2}

    this.apiClient.addMemberToGroup(membership).subscribe(response => {
      if (response.succeeded) {
        this.notificationService.sendMessage({
          message:`Du er nu tilmeldt gruppen ${groupName}`,
          type: NotificationType.success
        });
        this.memberIsAddedToGroup.emit();
      }
     
    });
  }
}
