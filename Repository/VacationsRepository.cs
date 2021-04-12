using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using vacay.Models;

namespace vacay.Repository
{
    public class VacationsRepository
    {

        public readonly IDbConnection _db;

        public VacationsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Vacation> GetAll()
        {
            string sql = @"SELECT
            cruises.destination,
            cruises.price,
            cruises.date,
            cruises.id FROM cruises 
            UNION SELECT 
            trips.destination,
            trips.price,
            trips.date,
            trips.id FROM trips;";
            return _db.Query<Vacation>(sql);
        }
    }
}