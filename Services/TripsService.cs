using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using vacay.Models;
using vacay.Repository;

namespace vacay.Services
{
    public class TripsService
    {
        private readonly TripsRepository _tripRepo;

        public TripsService(TripsRepository tripRepo)
        {
            _tripRepo = tripRepo;
        }

        internal IEnumerable<Trip> GetAll()
        {
            return _tripRepo.GetAll();
        }

        internal Trip GetOneById(int id)
        {
            return _tripRepo.GetOneById(id);
        }

        internal Trip CreateOne(Trip newTrip)
        {
            return _tripRepo.CreateOne(newTrip);
        }

        internal Trip EditOne(Trip editTrip)
        {
            Trip current = GetOneById(editTrip.Id);
            if (current == null)
            {
                throw new SystemException("INVALID ID");
            }
            else
            {
                current.Date = editTrip.Date != null ? editTrip.Date : current.Date;
                current.Destination = editTrip.Destination != null ? editTrip.Destination : current.Destination;
                current.PeopleComing = editTrip.PeopleComing != null ? editTrip.PeopleComing : current.PeopleComing;
                current.Price = editTrip.Price != null ? editTrip.Price : current.Price;
                current.Transportation = editTrip.Transportation != null ? editTrip.Transportation : current.Transportation;
                current.Duration = editTrip.Duration != null ? editTrip.Duration : current.Duration;
                return _tripRepo.EditOne(current);
            }
        }

        internal Trip DeleteOne(int id)
        {
            Trip tripToDelete = GetOneById(id);
            if (tripToDelete == null)
            {
                throw new SystemException("INVALID ID");
            }
            else
            {
                _tripRepo.DeleteOne(id);
                return tripToDelete;
            }
        }
    }
}