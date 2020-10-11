using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using Android.Content;
using Newtonsoft.Json;

namespace Kassza
{
    [Activity(Label = "@string/app_name", Theme = "@style/Theme.AppCompat.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private CashDesk cashInDesk;
        private Button countButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            cashInDesk = new CashDesk();
            countButton = FindViewById<Button>(Resource.Id.Count);
            countButton.Click += new EventHandler((sender, e) => Count_click(sender,e));
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void Count_click(object sender, EventArgs e)
        {
            if (Initializable())
            {
                InitializeUserInterfaceDatas();
                
                Intent intent = new Intent(this, typeof(ResultActivity));
                intent.PutExtra("Cash",JsonConvert.SerializeObject(cashInDesk));
                StartActivity(intent);
            }
            else
            {
                AlertTheUser();
            }            
        }

        private void InitializeUserInterfaceDatas()
        {
            cashInDesk.OpeningBalance = int.Parse(FindViewById<EditText>(Resource.Id.openingBalance).Text);
            cashInDesk.ClosingBalance = int.Parse(FindViewById<EditText>(Resource.Id.closingBalance).Text);
            cashInDesk.AmountOf5Ft = int.Parse(FindViewById<EditText>(Resource.Id.ft5).Text);
            cashInDesk.AmountOf10Ft = int.Parse(FindViewById<EditText>(Resource.Id.ft10).Text);
            cashInDesk.AmountOf20Ft = int.Parse(FindViewById<EditText>(Resource.Id.ft20).Text);
            cashInDesk.AmountOf50Ft = int.Parse(FindViewById<EditText>(Resource.Id.ft50).Text);
            cashInDesk. AmountOf100Ft = int.Parse(FindViewById<EditText>(Resource.Id.ft100).Text);
            cashInDesk.AmountOf200Ft = int.Parse(FindViewById<EditText>(Resource.Id.ft200).Text);
            cashInDesk.AmountOf500Ft = int.Parse(FindViewById<EditText>(Resource.Id.ft500).Text);
            cashInDesk.AmountOf1000Ft = int.Parse(FindViewById<EditText>(Resource.Id.ft1000).Text);
            cashInDesk.AmountOf2000Ft = int.Parse(FindViewById<EditText>(Resource.Id.ft2000).Text);
            cashInDesk.AmountOf5000Ft = int.Parse(FindViewById<EditText>(Resource.Id.ft5000).Text);
            cashInDesk.AmountOf10000Ft = int.Parse(FindViewById<EditText>(Resource.Id.ft10000).Text);
            cashInDesk.AmountOf20000Ft = int.Parse(FindViewById<EditText>(Resource.Id.ft20000).Text);
        }

        private bool Initializable()
        {
            if (FindViewById<EditText>(Resource.Id.openingBalance).Text != "" && FindViewById<EditText>(Resource.Id.closingBalance).Text != "" && FindViewById<EditText>(Resource.Id.ft5).Text != ""
                && FindViewById<EditText>(Resource.Id.ft10).Text != "" && FindViewById<EditText>(Resource.Id.ft20).Text != "" && FindViewById<EditText>(Resource.Id.ft50).Text != "" &&
                FindViewById<EditText>(Resource.Id.ft100).Text != "" && FindViewById<EditText>(Resource.Id.ft200).Text != "" && FindViewById<EditText>(Resource.Id.ft500).Text != "" &&
                FindViewById<EditText>(Resource.Id.ft1000).Text != "" && FindViewById<EditText>(Resource.Id.ft2000).Text != "" && FindViewById<EditText>(Resource.Id.ft5000).Text != "" &&
                FindViewById<EditText>(Resource.Id.ft10000).Text != "" && FindViewById<EditText>(Resource.Id.ft20000).Text != "")
            {
                return true;
            }
            else
            {
                return false;
            }            
        }

        private void AlertTheUser()
        {
            Toast.MakeText(ApplicationContext, "Tölts ki minden mezőt!", ToastLength.Long).Show();
        }
    }
}