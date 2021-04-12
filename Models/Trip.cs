namespace vacay.Models
{
    public class Trip : Vacation
    {

        public int Id { get; set; }

        public int? PeopleComing { get; set; }

        public string Transportation { get; set; }

        public string Duration { get; set; }
    }
}