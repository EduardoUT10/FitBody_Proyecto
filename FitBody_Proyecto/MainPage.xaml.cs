using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FitBody_Proyecto
{
    public partial class MainPage : ContentPage
    {

        private string Url = "http://192.168.1.6:8080/proyecto_fitbody/post.php";
        private readonly HttpClient cliente = new HttpClient();
        private ObservableCollection<Datos> post;
        public MainPage()
        {
            InitializeComponent();
        }
        private async void btnMostrar_Clicked(object sender, EventArgs e)
        {
            var contenido = await cliente.GetStringAsync(Url);
            List<Datos> listaPost = JsonConvert.DeserializeObject<List<Datos>>(contenido);
            post = new ObservableCollection<Datos>(listaPost);
            MyListView.ItemsSource = post;
        }
    }
}
