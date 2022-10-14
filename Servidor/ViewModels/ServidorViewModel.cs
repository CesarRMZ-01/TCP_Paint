using GalaSoft.MvvmLight.Command;
using Servidor.Models;
using Servidor.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace Servidor.ViewModels
{
    internal class ServidorViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<DibuRec> recList;

        public ObservableCollection<DibuRec> RecList
        {
            get { return recList; }
            set { recList = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RecList)));
                        
                 }
        }

        

        ServerService Servidor;


        public ICommand IniciarCommand { get; set; }
        public ICommand DetenerCommand { get; set; }

        Dispatcher dispatcher;
        public ServidorViewModel()
        {
            dispatcher = Dispatcher.CurrentDispatcher;   
            IniciarCommand = new RelayCommand(Iniciar);
            DetenerCommand = new RelayCommand(Detener);

            RecList = new ObservableCollection<DibuRec>();

            Servidor = new();
            Servidor.Conectado += server_RectanguloRecibido;
            Servidor.Iniciar();
        }

  

        public void server_RectanguloRecibido(DibuRec obj)
        {
            dispatcher.Invoke(() =>
            {
                if (obj != null)
                    RecList.Add(obj);
            });
            
        }


        private void Iniciar()
        {
            if (Servidor != null)
                Servidor.Iniciar();
        }
        private void Detener()
        {
            if (Servidor != null)
                Servidor.Detener();
        }
        public event PropertyChangedEventHandler? PropertyChanged;

    }
}
