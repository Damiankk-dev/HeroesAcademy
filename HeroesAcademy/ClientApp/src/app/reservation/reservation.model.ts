export interface Reservation{
    id: number;
    roomId: number;
    tenantId: number;
    reservationStart: string;
    reservationEnd: string;
}