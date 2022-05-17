import { Component, OnInit, Input, OnChanges, SimpleChanges, Output, EventEmitter } from '@angular/core';
import { NotificationType } from 'src/app/notification.message';
import { Router } from '@angular/router';
import { ApiClientService } from 'src/app/services/api-client/api-client.service';
import { NotificationServiceService } from 'src/app/services/notification-message/notification-service.service';

@Component({
  selector: 'app-all-groups',
  templateUrl: './all-groups.component.html',
  styleUrls: ['./all-groups.component.css']
})
export class AllGroupsComponent {

  constructor(private apiClient: ApiClientService, private  notificationService: NotificationServiceService
    , private router: Router) { }

  @Input() groups: any[];
  @Input() userId: any;

  @Output() memberIsAddedToGroup = new EventEmitter<any>();

  joinGroup(groupId: number, memberId: number, groupName: string): void {
    this.apiClient.addMemberToGroup(groupId, memberId).subscribe(response => {
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
