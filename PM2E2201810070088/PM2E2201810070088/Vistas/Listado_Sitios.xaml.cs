using PM2E2201810070088.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2E2201810070088.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Listado_Sitios : ContentPage
    {
        public Listado_Sitios()
        {
            InitializeComponent();
        }

        public async void Mostrar()
        {
            //List<Sitios_ID> listaSitios = new List<Sitios_ID>();
            //listaSitios = await ControladorSitios.GetSitios();

            var lista = await App.BaseDatos.ObtenerListaSitios();
            listas.ItemsSource = lista;
        }



        protected override void OnAppearing()
        {
            base.OnAppearing();
            Mostrar();
        }

        private async void VerDetalles(object sender, EventArgs e)
        {
            SwipeItem item = sender as SwipeItem;
            Sitios model = item.BindingContext as Sitios;
            await Navigation.PushAsync(new Modificar(model));
        }

        private void listas_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            listas.SelectedItem = null;

        }

        private void SwipeItem_Invoked(object sender, EventArgs e)
        {

            SwipeItem item = sender as SwipeItem;
            Sitios model = item.BindingContext as Sitios;
            Eliminar(model);
            //await DisplayAlert("Sitios", model.descripcion  , "ok");
            // await Navigation.PushAsync(new DetallesFirmas(model));
        }

        private async void SwipeItem_Invoked_1(object sender, EventArgs e)
        {
            SwipeItem item = sender as SwipeItem;
            Sitios model = item.BindingContext as Sitios;
            //await DisplayAlert("Sitios", model.descripcion  , "ok");

            double lat = Convert.ToDouble(model.latitud);
            double lon = Convert.ToDouble(model.longitud);

            await Navigation.PushAsync(new FourSquareVista(lat, lon));
        }

        public async void Eliminar(Sitios a)
        {


            Sitios siti = new Sitios
            {
                id = a.id,
                descripcion = a.descripcion,
                latitud = a.latitud,
                longitud = a.longitud,
                fotografia = a.fotografia

            };

            var resultado = await App.BaseDatos.EliminarSitios(siti);

            if (resultado == 1)
            {
                await DisplayAlert("Mensaje", "Eliminado exitoso!!!", "ok");
                Mostrar();
            }
            else
            {
                await DisplayAlert("Error", "No se pudo Eliminado", "ok");
            }


        }

        private async void SwipeItem_Invoked_2(object sender, EventArgs e)
        {
            SwipeItem item = sender as SwipeItem;
            Sitios model = item.BindingContext as Sitios;

            Double lat = Convert.ToDouble(model.latitud);
            Double longi = Convert.ToDouble(model.longitud);

            var location = new Location(lat, longi);
            var options = new MapLaunchOptions { NavigationMode = NavigationMode.Driving };
            await Map.OpenAsync(location, options);
        }
    }
}