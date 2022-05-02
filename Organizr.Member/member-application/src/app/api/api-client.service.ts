import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { throwError } from 'rxjs'; 
import { User } from '../User';

@Injectable({
  providedIn: 'root'
})
export class ApiClientService {

  private apiUrl = 'https://localhost:7157'

  constructor(private http: HttpClient) { }

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Accept': 'text/plain'
    }),
  };

  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(this.apiUrl + '/api/organizr-user')
    .pipe(retry(1), catchError(this.handleError));
  }

  
  createOrganizrUser(user: any): Observable<User> {
    console.log("vi er her")
    return this.http
    .post<User>(
      this.apiUrl + '/organizr-user',
      JSON.stringify(user),
      this.httpOptions)
      .pipe(retry(1), catchError(this.handleError));
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
