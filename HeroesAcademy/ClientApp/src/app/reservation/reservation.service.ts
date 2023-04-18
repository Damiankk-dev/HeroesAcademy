import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Reservation } from './reservation.model';

@Injectable({
  providedIn: 'root'
})
export class ReservationService {
  private reservationsApi: string = 'https://localhost:7128/Reservations'

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
    console.log("INSIDE SERVICE header: ", headers);
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

  deleteReservation(id: number): Observable<ResponseResult<number>> {
    const url = `${this.reservationsApi}/${id}`;
    return this.httpClient.delete<ResponseResult<number>>(url);
  }
}

export interface ResponseResult<T> {
  data: T;
  errorType: number;
  httpError: number;
  message: string;
}

