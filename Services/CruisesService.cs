using System;
using System.Collections.Generic;
using vacay.Models;
using vacay.Repository;

namespace vacay.Services
{
    public class CruisesService
    {
        private readonly CruisesRepository _cruiseRepo;

        public CruisesService(CruisesRepository cruiseRepo)
        {
            _cruiseRepo = cruiseRepo;
        }

        internal IEnumerable<Cruise> GetAll()
        {
            return _cruiseRepo.GetAll();
        }

        internal Cruise GetOneById(int id)
        {
            return _cruiseRepo.GetOneById(id);
        }

        internal Cruise CreateOne(Cruise newCruise)
        {
            return _cruiseRepo.CreateOne(newCruise);
        }

        internal Cruise EditOne(Cruise edititedCruise)
        {
            Cruise current = GetOneById(edititedCruise.Id);
            if (current == null)
            {
                throw new SystemException("INVALID ID");
            }
            else
            {
                current.BoatSize = edititedCruise.BoatSize != null ? edititedCruise.BoatSize : current.BoatSize;
                current.Date = edititedCruise.Date != null ? edititedCruise.Date : current.Date;
                current.Destination = edititedCruise.Destination != null ? edititedCruise.Destination : current.Destination;
                current.Length = edititedCruise.Length != null ? edititedCruise.Length : current.Length;
                current.Name = edititedCruise.Name != null ? edititedCruise.Name : current.Name;
                current.PeopleAboard = edititedCruise.PeopleAboard != null ? edititedCruise.PeopleAboard : current.PeopleAboard;
                current.Price = edititedCruise.Price != null ? edititedCruise.Price : current.Price;
                return _cruiseRepo.EditOne(current);
            }
        }

        internal Cruise DeleteOne(int id)
        {
            Cruise cruiseToDelete = GetOneById(id);
            if (cruiseToDelete == null)
            {
                throw new SystemException("INVALID ID");
            }
            else
            {
                _cruiseRepo.DeleteOne(id);
                return cruiseToDelete;
            }
        }
    }
}