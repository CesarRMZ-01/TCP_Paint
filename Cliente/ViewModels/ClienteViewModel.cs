using Cliente.Services;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using Prism.Commands;
using Servidor.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Cliente.ViewModels
{
    internal class ClienteViewModel: INotifyPropertyChanged
    {
        public ClienteService clienteS;

        public DibuRec Dibu { get; set; } = new();
        private string ip;
        public string IP
        {
            get { return ip; }
            set
            {
                ip = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IP)));
            }
        }
        private bool desconectado;
        public bool Desconectado
        {
            get { return desconectado; }
            set { desconectado = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Desconectado)));
            }
        }

        private bool si;
        public bool Si
        {
            get { return si; }
            set
            {
                si = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Si)));
            }
        }

        private string enviarBTNState;
        public string EnviarBTNState
        {
            get { return enviarBTNState; }
            set { enviarBTNState = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EnviarBTNState)));
            }
        }

        private string enviarIPState;
        public string EnviarIPState
        {
            get { return enviarIPState; }
            set
            {
                enviarIPState = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EnviarIPState)));
            }
        }

        private string color;
        public string Color
        {
            get { return color; }
            set
            {
                color = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Color)));
            }
        }

        public ICommand EnviarCommand { get; set; }
        public ICommand EnviarIPCommand { get; set; }


        private string error;
        public string Error
        {
            get { return error; }
            set
            {
                error = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Error)));
            }
        }

        public ClienteViewModel()
        {
            EnviarCommand = new RelayCommand(Enviar);
            EnviarIPCommand = new RelayCommand(EnviarIP);

            Color = "#db2334";
            Desconectado = true;
            EnviarBTNState = "hidden";
            EnviarIPState = "visible";
            Si = true;


            IP = "127.0.0.1";

            Error = "¡No olvides colocar una IP correcta \n para poder enviar tu figura!";
            //IPEndPoint ipe = new IPEndPoint(IPAddress.Parse(IP), 6009);
            //tcpClient.Connect(ipe);
        }



        private double? posX = 0;

        public double? PosX
        {
            get { return posX; }
            set 
            { 
                posX = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));

            }
        }
        private double? posY = 0;

        public double? PosY
        {
            get { return posY; }
            set
            {
                posY = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));

            }
        }

        private double? maxX = 0;

        public double? MaxX
        {
            get { return maxX; }
            set
            {
                maxX = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));

            }
        }
        private double? maxY = 0;

        public double? MaxY
        {
            get { return maxY; }
            set
            {
                maxY = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));

            }
        }

        private string myVar;

        public string MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }


        private void Enviar()
        {
            //if (Si)
            //{
            //    clienteS = new(IP);
            //    Si = false;
            //}
            //else
            //{
                clienteS.Enviar(Dibu);
            //}
        }
        private void EnviarIP()
        {
            if (!IPAddress.TryParse(IP, out IPAddress? direccion))
            {
                Error = "Escriba la direccion Ip del servidor al cual enviar la informacion";
            }

            if (Desconectado)
            {
                clienteS = new(IP);
                Desconectado = false;

                EnviarIPState = "hidden";
                EnviarBTNState = "visible";

                Error = "Todo en orden. \n ¡Ya puedes enviar tu figura!";
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

    }
}
