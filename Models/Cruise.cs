namespace vacay.Models
{
    public class Cruise : Vacation
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public string BoatSize { get; set; }

        public int? Length { get; set; }

        public int? PeopleAboard { get; set; }
    }
}