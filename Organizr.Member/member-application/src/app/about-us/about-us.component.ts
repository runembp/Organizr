import { Component, OnInit } from '@angular/core';
import { ApiClientService } from '../api-client/api-client.service';

@Component({
  selector: 'app-about-us',
  templateUrl: './about-us.component.html',
  styleUrls: ['./about-us.component.css']
})
export class AboutUsComponent implements OnInit {

  aboutUsContent: string;

  constructor(private apiClient: ApiClientService) { }

  ngOnInit(): void {

    this.apiClient.getAllConfigurations().subscribe((configurations) => {
      this.aboutUsContent = configurations[11]['stringValue'];
    });
  }
}