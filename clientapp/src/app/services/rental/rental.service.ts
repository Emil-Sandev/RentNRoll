import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TokenService } from '../token/token.service';
import { Observable } from 'rxjs';
import { RentalDetailsUserDTO, RentalsAdminDTO } from '../../models/rental.model';
import { environment } from '../../../environments/environment.development';

@Injectable({
  providedIn: 'root',
})
export class RentalService {
  constructor(private http: HttpClient, private tokenService: TokenService) { }

  getUserRentals(): Observable<RentalDetailsUserDTO[]> {
    const userName: string = this.tokenService.getUsernameFromToken();
    return this.http.get<RentalDetailsUserDTO[]>(
      environment.apiUrl + `/api/Rental/getUserRentals?username=${userName}`
    );
  }

  getRentals(page: number = 1): Observable<RentalsAdminDTO> {
    return this.http.get<RentalsAdminDTO>(
      environment.apiUrl + `/api/Rental/getRentals/${page}`
    );
  }
}
