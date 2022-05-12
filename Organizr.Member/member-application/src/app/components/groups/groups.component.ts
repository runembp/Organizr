import { Component, OnInit } from '@angular/core';
import { ApiClientService } from 'src/app/services/api-client/api-client.service';

@Component({
  selector: 'app-groups',
  templateUrl: './groups.component.html',
  styleUrls: ['./groups.component.css']
})
export class GroupsComponent implements OnInit {

  constructor(private apiClient: ApiClientService) { }

  groups: any [] = [];

  ngOnInit(): void {
    this.apiClient.getAllGroups().subscribe(groups => this.groups = groups);
  }

}
