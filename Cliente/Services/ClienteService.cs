using Newtonsoft.Json;
using Servidor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Cliente.Services
{
    internal class ClienteService
    {

        public TcpClient cliente = new();

        public ClienteService(string IP)
        {

            IPEndPoint ipe = new(IPAddress.Parse(IP),6009);
            cliente.Connect(ipe);

        }   

       public void Enviar(object? obj)
        {
            try
            {
                    var Json = JsonConvert.SerializeObject(obj);
                    byte[] buffer = Encoding.UTF8.GetBytes(Json);

                    var stream = cliente.GetStream();
                    stream.Write(buffer, 0, buffer.Length);

            }
            catch (Exception)
            {
                cliente.Close();
            }
            
        }
    }
}
