import { formatDate } from '@angular/common';
import { HttpClient, HttpHandler, HttpHeaders } from '@angular/common/http';
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

  getReservation(id:string | null): Observable<ResponseResult<Reservation>>{
    return this.httpClient.get<ResponseResult<Reservation>>(this.reservationsApi + `/${id}`);
  }

  createReservation(reservation: Reservation): Observable<ResponseResult<Reservation>>{
    const headers = new HttpHeaders({'Content-Type': 'application/json'})
    const newReservation = {...reservation, id: 0};
    return this.httpClient.post<ResponseResult<Reservation>>(this.reservationsApi, newReservation,{
      headers,
    });
  }

  updateReservation(reservation: Reservation): Observable<ResponseResult<Reservation>>{
    const headers = new HttpHeaders({'Content-Type': 'application/json'})
    const url = `${this.reservationsApi}/${reservation.id}`;
    console.log("Reservaion: ",reservation);
    return this.httpClient.put<ResponseResult<Reservation>>(url, reservation, {headers});
  }
}

export interface ResponseResult<T> {
  data: T;
  errorType: number;
  httpError: number;
  message: string;
}
