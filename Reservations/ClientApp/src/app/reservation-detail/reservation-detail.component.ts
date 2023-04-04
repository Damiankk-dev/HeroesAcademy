import { formatDate } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ReservationService, ResponseResult } from '../reservation/reservation.service';
import { Reservation } from '../reservations-list/reservation.model';

@Component({
  selector: 'app-reservation-detail',
  templateUrl: './reservation-detail.component.html',
  styleUrls: ['./reservation-detail.component.css']
})
export class ReservationDetailComponent implements OnInit {
  pageTitle = "Szczegóły rezerwacji nr: "
  reservation: any = {};

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
  onClick(): void {
    this.router.navigate(['/reservations']);
  }

}
