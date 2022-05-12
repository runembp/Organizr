import { Component, OnInit } from '@angular/core';
import { DataSharingService } from 'src/app/services/shared/data-sharing.service';


@Component({
  selector: 'app-side-bar',
  templateUrl: './side-bar.component.html',
  styleUrls: ['./side-bar.component.css']
})
export class SideBarComponent implements OnInit {

  isUserLoggedIn: boolean;

  constructor() { 
    
  }

  ngOnInit(): void {
  }

}
