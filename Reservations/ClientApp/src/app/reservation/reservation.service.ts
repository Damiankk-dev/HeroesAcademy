import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Reservation } from '../reservations-list/reservation.model';

@Injectable({
  providedIn: 'root'
})
export class ReservationService {
  private reservationsApi: string = 'https://localhost:7196/api/Reservations'

  constructor(private httpClient:HttpClient) { }

  getReservationsByRoomId(id:string |null): Observable<ResponseResult<Reservation[]>>{
    return this.httpClient.get<ResponseResult<Reservation[]>>(this.reservationsApi + `/ByRoom/${id}`);
  }

  getReservationsByHeroId(id:string | null): Observable<ResponseResult<Reservation[]>>{
    return this.httpClient.get<ResponseResult<Reservation[]>>(this.reservationsApi + `/ByHero/${id}`);
  }

  getReservations(): Observable<ResponseResult<Reservation[]>>{
    return this.httpClient.get<ResponseResult<Reservation[]>>(this.reservationsApi);
  }
}

export interface ResponseResult<T> {
  data: T;
  errorType: number;
  httpError: number;
  message: string;
}
