import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { GeocoderResponse } from './geocoder-response.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})

export class GeocodingService {

  constructor(private http: HttpClient) { }

  /**
   * Fetch from google api 
   * @param address 
   * @returns 
   */
  getLocation(address: string): Observable<GeocoderResponse> {
    const url = `https://maps.google.com/maps/api/geocode/json?address=${address}&sensor=false&key=${environment.apiKey}`;
    return this.http.get<GeocoderResponse>(url);
  }
}