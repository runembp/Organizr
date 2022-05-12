import { Component, OnInit } from '@angular/core';
import { ApiClientService } from '../../services/api-client/api-client.service';
import { ConfigurationConstantsService } from 'src/app/services/shared/configuration-constants.service';

@Component({
  selector: 'app-about-us',
  templateUrl: './about-us.component.html',
  styleUrls: ['./about-us.component.css']
})
export class AboutUsComponent implements OnInit {

  aboutUsContent: string;

  constructor(private configService: ConfigurationConstantsService) {
    this.configService.aboutUsPage.subscribe(value => {
      this.aboutUsContent = value;
    });
   }

  ngOnInit(): void {

  }
}