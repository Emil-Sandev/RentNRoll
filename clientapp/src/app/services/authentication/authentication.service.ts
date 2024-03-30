import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  constructor(private http: HttpClient) { }

  register(userData: any): Observable<any> {
    return this.http.post(
      environment.apiUrl + '/api/Authentication/register',
      userData
    );
  }
}
