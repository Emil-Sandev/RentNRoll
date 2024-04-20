import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UsersAdminDTO } from '../../models/user.model';
import { environment } from '../../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  constructor(private http: HttpClient) { }

  getUsers(page: number = 1): Observable<UsersAdminDTO> {
    return this.http.get<UsersAdminDTO>(
      environment.apiUrl + `/api/User/getUsers/${page}`
    );
  }

  deleteUser(username: string) {
    return this.http.delete(
      environment.apiUrl + `/api/User/deleteUser/${username}`
    );
  }
}
