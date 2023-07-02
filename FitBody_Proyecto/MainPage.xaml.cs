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

        private const string Url = "http://192.168.1.6:8080/proyecto_fitbody/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<FitBody_Proyecto.Ws.Datos> _post;
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnGet_Clicked(object sender, EventArgs e)
        {
            var content = await client.GetStringAsync(Url);
            List<FitBody_Proyecto.Ws.Datos> posts = JsonConvert.DeserializeObject<List<FitBody_Proyecto.Ws.Datos>>(content);
            _post = new ObservableCollection<FitBody_Proyecto.Ws.Datos>(posts);

            MyListView.ItemsSource = posts;
        }
    }
}
