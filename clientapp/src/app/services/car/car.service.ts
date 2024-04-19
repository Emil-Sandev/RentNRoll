import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AdminCarsDTO, CarDetailsDTO, CarQueryModel, FilteredAndPagedCarDTO } from '../../models/car.model';
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

  getCarDetails(id: number): Observable<CarDetailsDTO> {
    return this.http.get<CarDetailsDTO>(
      environment.apiUrl + `/api/Car/getCarDetails/${id}`
    );
  }

  getAdminCars(queryModel: CarQueryModel): Observable<AdminCarsDTO> {
    let params = new HttpParams();
    for (const key in queryModel) {
      if (queryModel.hasOwnProperty(key)) {
        // @ts-ignore
        params = params.set(key, queryModel[key]);
      }
    }

    return this.http.get<AdminCarsDTO>(
      environment.apiUrl + '/api/Car/getAdminCars',
      { params }
    );
  }

  createCar(createCarDTO: any, image: File) {
    const formData = new FormData();
    for (const key in createCarDTO) {
      if (createCarDTO.hasOwnProperty(key)) {
        // @ts-ignore
        formData.append(key, createCarDTO[key]);
      }
    }
    formData.append('image', image);

    return this.http.post(
      environment.apiUrl + '/api/Car/createCar',
      formData,
    );
  }

  deleteCar(id: number) {
    return this.http.delete(
      environment.apiUrl + `/api/Car/deleteCar/${id}`,
    );
  }
}
