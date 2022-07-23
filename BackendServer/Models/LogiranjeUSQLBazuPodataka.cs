using System.Diagnostics;

namespace BackendServer.Models
{
    public class LogiranjeUSQLBazuPodataka : ILog
    {
        public void Informacija()
        {
            Debug.WriteLine("Upisujem log u SQL bazu podataka");
        }
    }
}
