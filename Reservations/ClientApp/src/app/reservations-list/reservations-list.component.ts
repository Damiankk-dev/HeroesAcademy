import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ReservationService, ResponseResult } from '../reservation/reservation.service';
import { Reservation } from './reservation.model';

@Component({
  selector: 'app-reservations-list',
  templateUrl: './reservations-list.component.html',
  styleUrls: ['./reservations-list.component.css']
})
export class ReservationsListComponent implements OnInit {
  reservations: Reservation[] = [];
  filteredReservations: Reservation[] = [];
  heroes: number[] = [1, 1001]
  rooms: string[] = ['1', '1001'] 

  private _listFilter: number = this.heroes[0];

  public get listFilter(): number {
    return this._listFilter;
  }
  public set listFilter(v: number){
    this._listFilter = v;
    this.filteredReservations = this.listFilter ? this.filterReservations(this.listFilter) : this.reservations
  }

  constructor(
    private activatedRoute: ActivatedRoute,
    private reservationService: ReservationService
    ) { }

  ngOnInit(): void {
    const id = this.activatedRoute.snapshot.paramMap.get('id');
    this.reservationService.getReservationsByRoomId(id).subscribe((reservations: ResponseResult<Reservation[]>) =>{ 
      this.reservations=reservations.data;
      this.filteredReservations = this.reservations;
    })
  }
  filterReservations(listFilter: number): Reservation[]{
    return this.reservations.filter((reservation: Reservation) => {
      return reservation.tenantId == listFilter;
    })
  }

}
