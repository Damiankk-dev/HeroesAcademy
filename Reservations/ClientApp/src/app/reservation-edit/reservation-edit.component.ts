import { formatDate } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ReservationService, ResponseResult } from '../reservation/reservation.service';
import { Reservation } from '../reservations-list/reservation.model';

@Component({
  selector: 'app-reservation-edit',
  templateUrl: './reservation-edit.component.html',
  styleUrls: ['./reservation-edit.component.css']
})
export class ReservationEditComponent implements OnInit {  
  heroes: string[] = ['1', '1001']
  rooms: string[] = ['1', '1001', '1002']
  reservation: Reservation = {
    roomId: 0,
    tenantId: 0,
    reservationStart: Date().toString(),
    reservationEnd: Date().toString()
  } as Reservation;

  constructor(
    private reservationService: ReservationService,
    private router: Router,
    private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.activatedRoute.snapshot.paramMap.get('id');
    if (id ) {
      this.reservationService
        .getReservation(id)
        .subscribe((response: ResponseResult<Reservation>) => {
          response.data.reservationStart = formatDate(response.data.reservationStart,"yyyy-MM-ddThh:mm","en-US");
          response.data.reservationEnd = formatDate(response.data.reservationEnd,"yyyy-MM-ddThh:mm","en-US");
          this.reservation = response.data;
        });
    }
  }
  onSubmit(form: NgForm): void{
    if (form.valid) {
      if (!this.reservation.id) {
        console.log("Reservation before date change: ", this.reservation);  
        this.reservation.reservationStart = formatDate(this.reservation.reservationStart, "yyyy-MM-ddThh:mm:ss.ss","en-US");
        this.reservation.reservationEnd = formatDate(this.reservation.reservationEnd, "yyyy-MM-ddThh:mm:ss.ss","en-US");
        console.log("Reservation after date change: ", this.reservation); 
        this.reservationService.createReservation(this.reservation).subscribe(() =>{    
          this.router.navigate(['/reservations']);
        });
        
      } else {
        this.router.navigate(['/reservations']);        
      }
    }
  }

}
