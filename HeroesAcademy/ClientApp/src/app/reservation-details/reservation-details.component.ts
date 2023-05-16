import { Component, OnInit } from '@angular/core';
import { ReservationService, ResponseResult } from '../reservation/reservation.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Reservation } from '../reservation/reservation.model';
import { formatDate } from '@angular/common';

@Component({
  selector: 'app-reservation-details',
  templateUrl: './reservation-details.component.html',
  styleUrls: ['./reservation-details.component.css']
})
export class ReservationDetailsComponent implements OnInit {
  pageTitle = "Szczegóły rezerwacji nr: "
  reservation: any = {};

  constructor(
    private reservationService: ReservationService,
    private router: Router,
    private activatedRoute: ActivatedRoute
  ) { }

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
  onClick(): void {
    this.router.navigate(['/reservations']);
  }
}
