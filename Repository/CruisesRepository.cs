using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using vacay.Models;

namespace vacay.Repository
{
    public class CruisesRepository
    {
        public readonly IDbConnection _db;

        public CruisesRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Cruise> GetAll()
        {
            string sql = "SELECT * FROM cruises;";
            return _db.Query<Cruise>(sql);
        }

        internal Cruise GetOneById(int id)
        {
            string sql = "SELECT * FROM cruises WHERE id = @id;";
            return _db.QueryFirstOrDefault<Cruise>(sql, new { id });
        }

        internal Cruise CreateOne(Cruise newCruise)
        {
            string sql = @"INSERT INTO cruises
            (boatSize, date, destination, length, name, peopleAboard, price)
            VALUES
            (@BoatSize, @Date, @Destination, @Length, @Name, @PeopleAboard, @Price);
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newCruise);
            newCruise.Id = id;
            return newCruise;
        }

        internal Cruise EditOne(Cruise current)
        {
            string sql = @"UPDATE cruises
            SET
                boatSize = @BoatSize,
                date = @Date,
                destination = @Destination,
                length = @Length,
                name = @Name,
                peopleAboard = @PeopleAboard,
                price = @Price
                WHERE id = @id;
            SELECT * FROM cruises WHERE id = @id;";
            return _db.QueryFirstOrDefault<Cruise>(sql, current);
        }

        internal void DeleteOne(int id)
        {
            string sql = "DELETE FROM cruises WHERE id = @id;";
            _db.Execute(sql, new { id });
            return;
        }
    }
}