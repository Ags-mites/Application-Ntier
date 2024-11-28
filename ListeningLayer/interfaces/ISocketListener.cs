using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListeningLayer.interfaces
{
    public interface ISocketListener
    {
        void StartListening();
        void SendData(string data);
        event Action<string> DataProcessed;
    }
}
