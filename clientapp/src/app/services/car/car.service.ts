import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CarQueryModel, FilteredAndPagedCarDTO } from '../../models/car.model';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class CarService {
  constructor(private http: HttpClient) { }

  getCars(queryModel: CarQueryModel): Observable<FilteredAndPagedCarDTO> {
    let params = new HttpParams();
    for (const key in queryModel) {
      if (queryModel.hasOwnProperty(key)) {
        // @ts-ignore
        params = params.set(key, queryModel[key]);
      }
    }

    return this.http.get<FilteredAndPagedCarDTO>(
      environment.apiUrl + '/api/Car/getCars',
      { params }
    );
  }
}
