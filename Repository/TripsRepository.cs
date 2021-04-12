using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using vacay.Models;

namespace vacay.Repository
{
    public class TripsRepository
    {
        public readonly IDbConnection _db;

        public TripsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Trip> GetAll()
        {
            string sql = "SELECT * FROM trips;";
            return _db.Query<Trip>(sql);
        }

        internal Trip GetOneById(int id)
        {
            string sql = "SELECT * FROM trips WHERE id = @id;";
            return _db.QueryFirstOrDefault<Trip>(sql, new { id });
        }

        internal Trip CreateOne(Trip newTrip)
        {
            string sql = @"INSERT INTO trips
            (date, destination, peopleComing, price, transportation, duration)
            VALUES
            (@Date, @Destination, @PeopleComing, @Price, @Transportation, @Duration);
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newTrip);
            newTrip.Id = id;
            return newTrip;
        }

        internal Trip EditOne(Trip current)
        {
            string sql = @"UPDATE trips
                SET
                date = @Date,
                destination = @Destination,
                peopleComing = @PeopleComing,
                price = @Price,
                transportation = @Transportation,
                duration = @Duration
                WHERE id = @id;
                SELECT * FROM trips WHERE id = @id;";
                return _db.QueryFirstOrDefault<Trip>(sql, current);
        }

        internal void DeleteOne(int id)
        {
            string sql = "DELETE FROM trips WHERE id = @id;";
            _db.Execute(sql, new { id });
            return;
            
        }
    }
}