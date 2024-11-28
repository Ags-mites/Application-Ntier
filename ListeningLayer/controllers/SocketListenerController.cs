using ListeningLayer.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListeningLayer.controllers
{
    public class SocketListenerController
    {
        public ISocketListener Listener { get; private set; }

        public SocketListenerController()
        {
            Listener = new SocketListener();
            Task.Run(() => Listener.StartListening());
        }
    }
}
