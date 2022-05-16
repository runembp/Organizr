import { Component, OnInit } from '@angular/core';
import { ApiClientService } from 'src/app/services/api-client/api-client.service';
import { TokenStorageService } from 'src/app/services/token-storage/token-storage.service';

@Component({
  selector: 'app-groups',
  templateUrl: './groups.component.html',
  styleUrls: ['./groups.component.css']
})
export class GroupsComponent implements OnInit {

  constructor(private tokenStorage: TokenStorageService, private apiClient: ApiClientService) { }

  loggedInUser: any;
  allGroups: any[] = [];
  bla: any[] = [];
  members: any[] = [];

  ngOnInit(): void {
    this.apiClient.getAllGroups().subscribe(groups => {
      this.allGroups = groups;
    });

    this.loggedInUser = this.tokenStorage.getUser().id;
  }
}




