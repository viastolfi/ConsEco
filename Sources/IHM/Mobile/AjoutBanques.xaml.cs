using Model;
using System.Diagnostics;
using System.Numerics;

namespace IHM.Mobile;

public partial class AjoutBanques : ContentPage
{
    public Manager Mgr => (App.Current as App).Manager;
    public AjoutBanques()
	{
		InitializeComponent();
        BindingContext = Mgr;
        Mgr.LoadBanqueDispo();
        if (OperatingSystem.IsIOS())
        {
            boutonRetour.IsVisible = true;
        }
    }

    private async void ImportOFX_Clicked(object sender, EventArgs e)
    {
        PickOptions options = new PickOptions();
        options.PickerTitle = "Choisir un fichier OFX";

        try{
            var result = await FilePicker.Default.PickAsync(options);
            if (result != null)
            {
                if (result.FileName.EndsWith("ofx", StringComparison.OrdinalIgnoreCase))
                {
                    IList<Compte> lesComptes = Mgr.Pers.GetDataFromOFX(result.FullPath);
                    Debug.WriteLine(lesComptes.Count);
                    foreach(Compte compte in lesComptes)
                    {
                        if(Mgr.User.LesBanques.Count != 0)
                        {
                            Mgr.User.LesBanques.First().AjouterCompte(compte);
                        }
                        
                    }

                }
            }
            else
            {
                throw new FileLoadException("Imposible de charger le fichier");
            }

            
        }
        catch(Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }
    private async void returnbutton(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }

    private async void AddBanque_Clicked(object sender, EventArgs e)
    {
        ImageButton imageButton = (ImageButton)sender;
        Grid grid = (Grid)imageButton.Parent;
        foreach(IView iw in grid.Children)
        {
            if (iw.GetType() == typeof(Label))
            {
                await Mgr.Pers.AjouterBanque((Banque)(iw as Label).BindingContext, Mgr.User);
            }
        }

        //Mgr.User.LesBanques = await Mgr.Pers.RecupererBanques(Mgr.User);
        await Navigation.PopModalAsync();
    }
}

