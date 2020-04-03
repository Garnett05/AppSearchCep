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
            if (IsValidCep(cep))
                try
                {
                    {
                        Endereco end = ViaCEPService.BuscarEnderecoViaCEP(cep);
                        if (end == null)
                        {
                            DisplayAlert("Erro", "O endereço não foi encontrado para o CEP informado: " + cep, "Ok");
                        }
                        Result.Text = string.Format("Endereço: {0}, de {1}, {2}, {3}", end.Bairro, end.Localidade, end.Uf, end.Logradouro);
                    }
                }
                catch(Exception e)
                {
                    DisplayAlert("Erro!", e.Message, "Ok");
                }
            
        }

        private bool IsValidCep(string cep)
        {
            int novoCep;
            if (!int.TryParse(cep, out novoCep))
            {
                DisplayAlert("Erro", "CEP inválido", "O CEP deve conter apenas caracteres numéricos", "OK");
                return false;
            }
            if (cep.Length != 8)
            {
                DisplayAlert("Erro", "CEP inválido", "O CEP deve conter 8 caracteres numéricos", "OK");
                return false;
            }           
            return true;
        }
        
    }
}
