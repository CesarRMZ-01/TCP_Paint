using Newtonsoft.Json;
using Servidor.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Servidor.Services
{
    internal class ServerService : INotifyPropertyChanged
    {
        TcpListener servidor;

        List<TcpClient> tcpClients = new();
        
        public ServerService()
        {
            IPEndPoint ipe = new(IPAddress.Any, 6009);
            servidor = new(ipe);
        }

        public void Iniciar()
        {
            if (!servidor.Server.Connected)
            {
                Thread Hilo = new(new ThreadStart(Escuchar));
                Hilo.Start();
            }
        }

        public void Detener()
        {
            if (servidor != null)
            {
                servidor.Stop();
                servidor = null;
            }
        }

        public void Escuchar()
        {
            if (servidor != null)
            {
                try
                {
                    servidor.Start();

                    while (servidor.Server.IsBound)
                    {
                            var ClienteNuevo = servidor.AcceptTcpClient();
                            tcpClients.Add(ClienteNuevo);

                            Thread Hilo = new(new ParameterizedThreadStart(Recibir));
                            Hilo.Start(ClienteNuevo);

                    }
                    
                }
                catch (Exception)
                {

                    
                }
            }
            
        }

        public event Action<DibuRec>? Conectado;

        private void Recibir(object? tcpcliente)
        {
            if (tcpcliente != null)
            {
                TcpClient cliente = (TcpClient)tcpcliente;
                var stream = cliente.GetStream();

                while (cliente.Connected)
                {
                    if (cliente.Available > 0)
                    {
                        byte[] buffer = new byte[cliente.Available];
                        stream.Read(buffer, 0, buffer.Length);

                        //tcpClients.ForEach(x =>
                        //{
                        //    if (x != null)
                        //    {
                        //        Enviar(x, buffer);
                        //    }
                        //});

                        var dibuRec = JsonConvert.DeserializeObject<DibuRec>(Encoding.UTF8.GetString(buffer));


                        if (dibuRec !=null)
                            Conectado?.Invoke(dibuRec);

                    }

                    Thread.Sleep(1000);
                }
            }
        }

        //private void Enviar(TcpClient x, byte[] buffer)
        //{
        //    try
        //    {

        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //}

        

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
