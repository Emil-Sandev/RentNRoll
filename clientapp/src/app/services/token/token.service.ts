import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class TokenService {
  constructor() { }

  getUsernameFromToken(): string {
    const payload = atob(localStorage.getItem('token')!.split('.')[1]);
    const decodedPayload = JSON.parse(payload);
    return decodedPayload.username;
  }
}
