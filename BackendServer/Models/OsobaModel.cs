namespace BackendServer.Models
{
    public class OsobaModel
    {
        public int ID { get; set; }
        public string Prezime {  get; set; }
        public string Ime { get; set; }
        public string PunoImeiPrezime { get => Prezime + " " + Ime; }
    }

}
