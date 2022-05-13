import { Component, OnInit } from '@angular/core';
import { ApiClientService } from 'src/app/services/api-client/api-client.service';

@Component({
  selector: 'app-groups',
  templateUrl: './groups.component.html',
  styleUrls: ['./groups.component.css']
})
export class GroupsComponent implements OnInit {

  constructor(private apiClient: ApiClientService) { }

  allGroups: any[] = [];
  myGroups: any[] = [];

  ngOnInit(): void {
    this.apiClient.getAllGroups().subscribe(groups => {
      this.allGroups = groups
    });
  }

  joinGroup(groupId: number): void {
    this.apiClient.addMemberToGroup(groupId).subscribe();
  }

}
