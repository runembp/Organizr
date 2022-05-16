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
  allGroups: any[];
  myGroups: any[];

  ngOnInit(): void {

    this.loggedInUser = this.tokenStorage.getUser().id;

    this.apiClient.getAllGroups().subscribe(groups => {
      this.allGroups = groups;

      this.apiClient.getMembersGroups(this.loggedInUser).subscribe(value => {
        this.myGroups = value.groups;

        this.allGroups = this.allGroups.filter((x) => !this.myGroups.some(y => x.id === y.id));

      });

    });

  }
}




