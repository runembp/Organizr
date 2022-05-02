import { Component, OnInit } from '@angular/core';
import { ApiClientService } from '../api/api-client.service';
import { User } from '../User';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {

  users: User[] = [];
  
  constructor(private apiClient: ApiClientService) { }

  ngOnInit(): void {
    this.apiClient.getUsers().subscribe((users) => (this.users = users));
  }


}
