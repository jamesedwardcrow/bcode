namespace WXBC
{

    public partial class MainPage : ContentPage

    {

        public MainPage()
        {
            {
                InitializeComponent();
                List<string> listImfs = new List<string>();
                for (int i = 260; i < 320; i++)
                {

                    bool keyExist = Preferences.ContainsKey(i.ToString());
                    if (keyExist)
                    {
                        listImfs.Add(Preferences.Get(i.ToString(), "279"));
                    }
                }
                //picker.Items.Clear();
                //Preferences.Clear();
                picker.ItemsSource = listImfs;
            }
        }

        private void ButtonBC_Clicked(object sender, EventArgs e)
        {

            string bcStart;
            string wardNum;

            wardNum = entryWard.Text;

            bcStart = "*IE";
            string imfNum = entryIMF.Text + "*";
            BarCode.Text = bcStart + wardNum + " " + imfNum;
            BCode.Text = bcStart + wardNum + " " + imfNum;

        }

        private void ButtonAdd_Clicked(object sender, EventArgs e)
        {


            string wardNum = entryWard.Text.Trim();

            for (int i = 260; i < 320; i++)
            {
                bool keyExist = Preferences.ContainsKey(i.ToString());
                if (!keyExist)
                {
                    //listImfs.Add(Preferences.Get(i.ToString(), "279"));

                    Preferences.Set(wardNum, wardNum);

                    break;
                }
            }
            picker.ItemsSource.Clear();
            List<string> listImfs = new List<string>();
            for (int i = 260; i < 320; i++)
            {
                bool keyExist = Preferences.ContainsKey(i.ToString());
                if (keyExist)
                {
                    //listImfs.Add(Preferences.Get(i.ToString(), "279"));
                    //Preferences.Set(i.ToString(), wardNum);
                    listImfs.Add(Preferences.Get(i.ToString(), "279"));
                }
            }

            picker.ItemsSource = listImfs;
            DisplayAlert("Success", "Ward: " + wardNum + " added to your list.", "OK");
        }


        private void ButtonDel_Clicked(object sender, EventArgs e)

        {

            string selPick = entryWard.Text;
            if (selPick != null)
            {

                //string selItem = Preferences.Get(selPick, "279");
                Preferences.Remove(selPick);

                picker.ItemsSource.Clear();
                List<string> listImfs = new List<string>();
                for (int i = 260; i < 320; i++)
                {

                    bool keyExist = Preferences.ContainsKey(i.ToString());
                    if (keyExist)
                    {
                        //listImfs.Add(Preferences.Get(i.ToString(), "279"));
                        //Preferences.Set(i.ToString(), wardNum);
                        listImfs.Add(Preferences.Get(i.ToString(), "279"));
                    }
                }

                picker.ItemsSource = listImfs;

                entryWard.Text = "";

                DisplayAlert("Success", "Ward: " + selPick + " removed from your list.", "OK");
                //Preferences.Default.
            }
        }

        private void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                entryWard.Text = picker.SelectedItem.ToString();
            }
        }


    }
}
