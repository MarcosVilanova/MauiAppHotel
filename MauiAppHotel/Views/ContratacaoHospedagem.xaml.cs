namespace MauiAppHotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{
    App PropriedasApp;


	public ContratacaoHospedagem()
	{
		InitializeComponent();

        PropriedasApp = (App)Application.Current;

        pck_quarto.ItemsSource = PropriedasApp.lista_quartos;

        dtpck_checkin.MinimumDate = DateTime.Now;
        dtpck_checkin.MaximumDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, DateTime.Now.Day);

        dtcpk_checkout.MinimumDate = dtpck_checkin.Date.AddDays(1);
        dtcpk_checkout.MaximumDate = dtpck_checkin.Date.AddMonths(6);
    }

    public void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        App.Current.MainPage = new Sobre();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            Navigation.PushAsync(new HospedagemContratada());
        }
        catch (Exception ex) 
        {
            DisplayAlert("ops", ex.Message, "OK");
        }
    }

    private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
    {
        DatePicker elemento = sender as DatePicker;

        DateTime data_selecionada_checkin = elemento.Date;

        dtcpk_checkout.MinimumDate = data_selecionada_checkin.AddDays(1);
        dtcpk_checkout.MaximumDate = data_selecionada_checkin.AddMonths(6);
    }
}