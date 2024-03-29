﻿using HeroesAcademy.Domain.Models.Reservations;
using Shared.Models;

namespace HeroesAcademy.Application.Repository.Reservations
{
    public interface IReservationRepository
    {
        Task<ResponseResult<Reservation>> Add(Reservation reservation);
        Task<bool> Delete(int reservationId);
        Task<ResponseResult<List<Reservation>>> GetReservationByHeroId(int id);
        ValueTask<ResponseResult<Reservation?>> GetReservationById(int id);
        Task<ResponseResult<List<Reservation>>> GetReservationByRoomId(int id);
        Task<ResponseResult<List<Reservation>>> GetReservations();
        Task<ResponseResult<Reservation>> Update(int reservationId, Reservation reservation);
        //Task<ResponseResult<List<Reservation>>> GetByUserId(int id);
        //Task<ResponseResult<Reservation>> Add(Reservation reservation);
        //Task<bool> Delete(int id);
        //Task<ResponseResult<Reservation>> Update(int id, Reservation reservation);
    }
}
