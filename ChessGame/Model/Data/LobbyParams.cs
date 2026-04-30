using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Model.Data
{
    public class LobbyParams
    {
        public bool IsHost { get; private set; }
        public string IpAdress {  get; private set; }

        public LobbyParams(bool isHost, string ipAdress = null)
        {
            IsHost = isHost;
            IpAdress = ipAdress;
        }
    }
}
