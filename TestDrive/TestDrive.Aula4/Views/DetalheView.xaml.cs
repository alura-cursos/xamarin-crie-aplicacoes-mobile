using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace TestDrive.Views
{
    public partial class DetalheView : ContentPage
    {
        public Veiculo Veiculo { get; set; }

        private const int VALOR_FREIO_ABS = 800;
        private const int VALOR_AR_CONDICIONADO = 1000;
        private const int VALOR_MP3_PLAYER = 500;

        public string TextoFreioABS
        {
            get
            {
                return string.Format("Freio ABS - R$ {0}", VALOR_FREIO_ABS);
            }
        }

        public string TextoArCondicionado
        {
            get
            {
                return string.Format("Ar Condicionado - R$ {0}", VALOR_AR_CONDICIONADO);
            }
        }

        public string TextoMP3Player
        {
            get
            {
                return string.Format("MP3 Player - R$ {0}", VALOR_MP3_PLAYER);
            }
        }

        bool temFreioABS;
        public bool TemFreioABS
        {
            get
            {
                return temFreioABS;
            }
            set
            {
                temFreioABS = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(PrecoTotalFormatado));
            }
        }

        bool temArCondicionado;
        public bool TemArCondicionado
        {
            get
            {
                return temArCondicionado;
            }
            set
            {
                temArCondicionado = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(PrecoTotalFormatado));
            }
        }

        bool temMP3Player;
        public bool TemMP3Player
        {
            get
            {
                return temMP3Player;
            }
            set
            {
                temMP3Player = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(PrecoTotalFormatado));
            }
        }

        public decimal PrecoTotal
        {
            get
            {
                return Veiculo.preco
                    + (TemFreioABS ? VALOR_FREIO_ABS : 0)
                    + (TemArCondicionado ? VALOR_AR_CONDICIONADO : 0)
                    + (TemMP3Player ? VALOR_MP3_PLAYER : 0);
            }
        }

        public string PrecoTotalFormatado
        {
            get
            {
                return string.Format("Total: R$ {0}", PrecoTotal);
            }
        }

        public DetalheView(Veiculo veiculo)
        {
            this.Veiculo = veiculo;
            InitializeComponent();
            this.BindingContext = this;
        }

        private void botaoProximo_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AgendamentoView());
        }
    }
}


