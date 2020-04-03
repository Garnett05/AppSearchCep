using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ConsultaCEP.Services;
using ConsultaCEP.Services.Model;

namespace ConsultaCEP
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Button.Clicked += SearchCep;
        }
        private void SearchCep(object sender, EventArgs args)
        {
            string cep = Entry.Text.Trim();
            Endereco end = ViaCEPService.BuscarEnderecoViaCEP(cep);

            Result.Text = string.Format("Endereço: {0}, de {1}, {2}, {3}", end.Bairro, end.Localidade, end.Uf, end.Logradouro);
        }
        
    }
}
