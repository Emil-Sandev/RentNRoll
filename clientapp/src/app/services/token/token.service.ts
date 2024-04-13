import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class TokenService {
  constructor() { }

  getUsernameFromToken(): string {
    const token = localStorage.getItem('token');

    if (token) {
      const payload = atob(token.split('.')[1]);
      const decodedPayload = JSON.parse(payload);
      return decodedPayload.username;
    }

    return '';
  }
}
