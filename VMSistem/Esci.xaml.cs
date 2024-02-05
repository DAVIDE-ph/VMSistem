using Microsoft.AspNetCore.Components;
using Microsoft.Data.SqlClient;
using VMSistem.Class;
using ZXing.Net.Maui;

namespace VMSistem;

public partial class Esci : ContentPage
{
    protected override void OnAppearing()
    {
        
        base.OnAppearing();
    }
    public Esci()
	{
		InitializeComponent();
        cameraBarcodeReaderView.Options = new BarcodeReaderOptions
        {
            Formats = BarcodeFormats.All,
            AutoRotate = true,
            Multiple = true,
        };
    }

    protected void BarcodesDetected(object sender, BarcodeDetectionEventArgs e)
    {
        foreach (var barcode in e.Results)
        {
            Console.WriteLine($"Barcodes: {barcode.Format} -> {barcode.Value}");
            if (!string.IsNullOrEmpty(barcode.Value))
            {
                    string a = (string)barcode.Value;
                ReadQr(a);
            }
        }
        return;
    }

    private   void ReadQr( string value)
    {
        string SQLconn1 = "Server=13.0.0.95;Database=VMSystem;TrustServerCertificate=True;User Id=VMS;Password=DPH.OVH@13;Encrypt=False;";
        SqlConnection conn = new SqlConnection(SQLconn1);

        try
        {
           int a = Convert.ToInt32(value);
            conn.Open();
            string s1 = "UPDATE Visitors set Uscita=@Uscita where id =@id";
            SqlCommand cmd = new SqlCommand(s1, conn);
            cmd.Parameters.AddWithValue("@Uscita", DateTime.Now);
            cmd.Parameters.AddWithValue("@id", a);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Gval.Messaggio = ex.Message;
            
        }
        finally { 
            conn.Close();

            BackHomeAsync();

            //Application.Current.MainPage = new MainPage();
            //Application.Current.MainPage = new MainPage();
            //await App.Current.MainPage.Navigation.PushAsync(new Esci());
        }   
       
    }
    private async Task BackHomeAsync()
    {
        await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
    }

}