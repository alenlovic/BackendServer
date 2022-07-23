using System.Diagnostics;

namespace BackendServer.Models
{
    public class LogiranjeUDatoteku : ILog
    {
        public void Informacija()
        {
            Debug.WriteLine("Upisujem log u datoteku");
        }
    }
}
