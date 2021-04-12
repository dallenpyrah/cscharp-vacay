using System;
using System.Collections.Generic;
using vacay.Models;
using vacay.Repository;

namespace vacay.Services
{
    public class VacationsService
    {
        private readonly VacationsRepository _vacaRepo;

        public VacationsService(VacationsRepository vacaRepo)
        {
            _vacaRepo = vacaRepo;
        }

        internal IEnumerable<Vacation> GetAll()
        {
            return _vacaRepo.GetAll();
        }
    }
}