import { EventEmitter, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { LoginResponse } from '../../models/login.model';
import { TokenService } from '../token/token.service';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  isAdminEmitter: EventEmitter<boolean> = new EventEmitter();

  constructor(private http: HttpClient, private tokenService: TokenService) { }

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

  isAdmin(): Observable<boolean> {
    const username: string = this.tokenService.getUsernameFromToken();

    if (username) {
      return this.http.get<boolean>(
        environment.apiUrl + `/api/Authentication/isAdmin?username=${username}`
      );
    }

    return of(false);
  }
}
