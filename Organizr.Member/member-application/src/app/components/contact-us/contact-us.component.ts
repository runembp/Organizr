import { Component, OnInit } from '@angular/core';
import { GeocodingService } from 'src/app/services/google-api/geocoding.service';
import { GeocoderResponse } from 'src/app/services/google-api/geocoder-response.model';
import { ApiClientService } from 'src/app/services/api-client/api-client.service';
import { ConfigurationConstantsService } from 'src/app/services/data-sharing/configuration-constants.service';

@Component({
  selector: 'app-contact-us',
  templateUrl: './contact-us.component.html',
  styleUrls: ['./contact-us.component.css']
})
export class ContactUsComponent implements OnInit {

  locationCoords?: google.maps.LatLng | null = null;

  topText: string;
  leftBoxText: string;

  zoom = 15
  center: google.maps.LatLng;
  options: google.maps.MapOptions = {
    mapTypeId: 'roadmap',
    zoomControl: false,
    scrollwheel: false,
    disableDoubleClickZoom: true,
    maxZoom: 15,
    minZoom: 8,
  }

  constructor(private geocoderService: GeocodingService, private configService: ConfigurationConstantsService) {
    this.configService.organizationAddress.subscribe(value => {
      this.setMarkerForAddress(value);
    });
   }

  ngOnInit(): void {
    
    //this.topText = this.configService.contactPageTopTextBox;
    this.topText = "hello";

    //console.log("bla:" + this.configService.contactPageTopTextBox)
    //this.leftBoxText = this.configService.contactPageLeftTextBox;
    this.leftBoxText = "hellooo";
    
  }

  setMarkerForAddress(address: string) {

    this.geocoderService
      .getLocation(address).subscribe((response: GeocoderResponse) => {
        if (response.status === 'OK' && response.results?.length) {
          const location = response.results[0];
          const loc: any = location.geometry.location;

          this.locationCoords = new google.maps.LatLng(loc.lat, loc.lng);
          this.center = location.geometry.location;
        }
      });
  }
}
