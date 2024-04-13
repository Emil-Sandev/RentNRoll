import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { LoginResponse } from '../../models/login.model';

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

  login(userData: any): Observable<LoginResponse> {
    return this.http.post<LoginResponse>(
      environment.apiUrl + '/api/Authentication/login',
      userData
    );
  }

  isAuthenticated(): boolean {
    if (localStorage.getItem('token')) {
      return true;
    }
    return false;
  }
}
