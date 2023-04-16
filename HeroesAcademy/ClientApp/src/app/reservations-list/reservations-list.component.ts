import { Component, OnInit } from '@angular/core';
import { Reservation } from '../reservation/reservation.model';
import { ActivatedRoute } from '@angular/router';
import { ReservationService, ResponseResult } from '../reservation/reservation.service';

@Component({
  selector: 'app-reservations-list',
  templateUrl: './reservations-list.component.html',
  styleUrls: ['./reservations-list.component.css']
})
export class ReservationsListComponent implements OnInit {
  reservations: Reservation[] = [];
  filteredReservations: Reservation[] = [];
  heroes: string[] = ['1', '1001']
  rooms: string[] = ['1', '1001', '1002']
  byHeroes: boolean = false;
  byRooms: boolean = false;

  private _listFilter: string = '';

  public get listFilter(): string {
    return this._listFilter;
  }
  public set listFilter(v: string){
    this._listFilter = v;
    this.filteredReservations = Number(this.listFilter) ? this.filterReservations(Number(this.listFilter)) : this.reservations
  }
  constructor(
    private activatedRoute: ActivatedRoute,
    private reservationService: ReservationService
  ) { }

  ngOnInit(): void {
    const id = this.activatedRoute.snapshot.paramMap.get('id');
    const subRoute = this.activatedRoute.snapshot.toString();
    if(subRoute.indexOf("byhero") !== -1){
      this.reservationService.getReservationsByHeroId(id).subscribe((reservations: ResponseResult<Reservation[]>) =>{ 
        this.reservations=reservations.data;
        this.filteredReservations = this.reservations;
      })      
      this.byHeroes = true;
      this.byRooms = false;
    }else if (subRoute.indexOf("byroom") !==-1){      
      this.reservationService.getReservationsByRoomId(id).subscribe((reservations: ResponseResult<Reservation[]>) =>{ 
        this.reservations=reservations.data;
        this.filteredReservations = this.reservations;
      })      
      this.byHeroes = false;
      this.byRooms = true;
    } else {      
      this.reservationService.getReservations().subscribe((reservations: ResponseResult<Reservation[]>) =>{ 
        this.reservations=reservations.data;
        this.filteredReservations = this.reservations;
      })   
    }
  }
  filterReservations(listFilter: number): Reservation[]{
    if (this.byRooms){
      return this.reservations.filter((reservation: Reservation) => {
        return reservation.tenantId == listFilter;
      })
    } else if (this.byHeroes){      
      return this.reservations.filter((reservation: Reservation) => {
        return reservation.roomId == listFilter;
      })
    } else throw new Error('not implemented');
  }

  deleteReservation(reservation: Reservation): void{
    if (reservation && reservation.id){
      if (confirm(`Czy chcesz usunąć rezerwację nr: ${reservation.id}?`)) {
        this.reservationService.deleteReservation(reservation.id).subscribe(() =>{
          const foundIndex = this.reservations.findIndex(
            (item) => item.id ===reservation.id
          );
          if (foundIndex >-1) {
            this.reservations.splice(foundIndex, 1);
          }
          this.filteredReservations = this.reservations;
        });
      }
    }
  }
}
