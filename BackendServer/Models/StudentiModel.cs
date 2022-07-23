using System.ComponentModel.DataAnnotations;

namespace BackendServer.Models
{
    public class StudentiModel
    {
        [Key]
        public int ID { get; set; }

        public string Prezime { get; set; }
        public string Ime { get; set; }
        public int GodinaStudija { get; set; }
        public int BrojIndeksa { get; set; }
        public int GodinaRodjenja { get; set; }
        public string Smjer { get; set; }
        public double ProsjekOcjena { get; set; }
    }
}
