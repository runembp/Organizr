import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ApiClientService {

  private apiUrl = environment.baseUrl;

  constructor(private http: HttpClient) { }

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Accept': 'application/json'
    }),
  };

  // Config
  getAllConfigurations(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl + '/api/configuration');
  }

  // Member
  createOrganizrUser(user: any): Observable<any> {
    return this.http
      .post<any>(
        this.apiUrl + '/api/organizr-member',
        JSON.stringify(user),
        this.httpOptions)
      .pipe(retry(1), catchError(this.handleError));
  }

  // Login
  login(user: any): Observable<any> {

    return this.http.post<any>(
      this.apiUrl + '/api/auth/signin',
      JSON.stringify(user),
      this.httpOptions)
      .pipe(retry(1), catchError(this.handleError));
  }

  // Groups
  getAllGroups(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl + '/api/groups');
  }


  handleError(error: any) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Get client-side error
      errorMessage = error.error.message;

    } else {
      // Get server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;

    }
    window.alert(errorMessage);
    return throwError(() => {
      return errorMessage;
    });
  }
}