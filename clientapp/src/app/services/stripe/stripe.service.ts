import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { StripePaymentDTO, StripeResponse } from '../../models/stripe.model';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class StripeService {
  constructor(private http: HttpClient) { }

  createCheckout(stripePayment: StripePaymentDTO): Observable<StripeResponse> {
    return this.http.post<StripeResponse>(
      environment.apiUrl + '/api/Stripe/createCheckout',
      stripePayment
    );
  }
}
