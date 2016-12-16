﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Views;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
    public class ListagemViewModel
    {
        public List<Veiculo> Veiculos { get; set; }

        Veiculo veiculoSelecionado;
        public Veiculo VeiculoSelecionado
        {
            get
            {
                return veiculoSelecionado;
            }
            set
            {
                veiculoSelecionado = value;
                if (veiculoSelecionado != null)
                    Navigation.PushAsync(new DetalheView(veiculoSelecionado));
            }
        }

        public ListagemViewModel()
        {
            Veiculos = new List<Veiculo>()
            {
                new Veiculo { nome = "Azera V6", preco = 85000 },
                new Veiculo { nome = "Onix 1.6", preco = 35000 },
                new Veiculo { nome = "Fiesta 2.0", preco = 52000 },
                new Veiculo { nome = "C3 1.0", preco = 22000 },
                new Veiculo { nome = "Uno Fire", preco = 11000 },
                new Veiculo { nome = "Sentra 2.0", preco = 53000 },
                new Veiculo { nome = "Astra Sedan", preco = 39000 },
                new Veiculo { nome = "Vectra 2.0 Turbo", preco = 37000 },
                new Veiculo { nome = "Hilux 4x4", preco = 90000 },
                new Veiculo { nome = "Montana Cabine dupla", preco = 57000 },
                new Veiculo { nome = "Outlander 2.4", preco = 99000 },
                new Veiculo { nome = "Brasilia Amarela", preco = 9500 },
                new Veiculo { nome = "Omega Hatch", preco = 8000 }
            };

        }
    }
}
