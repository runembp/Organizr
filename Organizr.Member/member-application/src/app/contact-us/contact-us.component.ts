import { Component, OnInit } from '@angular/core';
import { GeocodingService } from '../google-api/geocoding.service';
import { GeocoderResponse } from '../google-api/geocoder-response.model';

@Component({
  selector: 'app-contact-us',
  templateUrl: './contact-us.component.html',
  styleUrls: ['./contact-us.component.css']
})
export class ContactUsComponent implements OnInit {

  address: string;
  locationCoords?: google.maps.LatLng | null = null;

  topContactUsContent: string;
  addressDescriptionContent: string;

  zoom = 12
  center: google.maps.LatLng;
  options: google.maps.MapOptions = {
    mapTypeId: 'roadmap',
    zoomControl: false,
    scrollwheel: false,
    disableDoubleClickZoom: true,
    maxZoom: 15,
    minZoom: 8,
  }

  constructor(private geocoderService: GeocodingService) { }

  ngOnInit(): void {

    this.setMarkerForAddress();

    this.topContactUsContent = `<!DOCTYPE html>
    <html lang="en">
    <head>
        <meta charset="UTF-8">
        <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>Document</title>
    </head>
    <body>
        <h1>Jeg er top content</h1>
    </body>
    </html>`;

    this.addressDescriptionContent = `<!DOCTYPE html>
    <html lang="en">
    <head>
        <meta charset="UTF-8">
        <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>Document</title>
    </head>
    <body>
        <h1>Jeg er addresse content</h1>
    </body>
    </html>`;

  }

  setMarkerForAddress() {

    this.address = "kløvermarken 12 9430 Vadum";

    this.geocoderService
      .getLocation(this.address).subscribe((response: GeocoderResponse) => {
        if (response.status === 'OK' && response.results?.length) {
          const location = response.results[0];
          const loc: any = location.geometry.location;

          this.locationCoords = new google.maps.LatLng(loc.lat, loc.lng);
          this.center = location.geometry.location;
        }
      });
  }
}
