import { Component, OnInit } from '@angular/core';
import { GeocodingService } from '../services/google-api/geocoding.service';
import { GeocoderResponse } from '../services/google-api/geocoder-response.model';
import { ApiClientService } from '../services/api-client/api-client.service';

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

  constructor(private geocoderService: GeocodingService, private apiClient: ApiClientService) { }

  ngOnInit(): void {

    this.apiClient.getAllConfigurations().subscribe((configuration) => {
      this.setMarkerForAddress(configuration[0]['stringValue']);
      this.topText = configuration[11]['stringValue'];
      this.leftBoxText = configuration[12]['stringValue'];
    });
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
