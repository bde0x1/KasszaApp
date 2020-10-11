using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

namespace Kassza
{
    [Activity(Label = "ResultActivity", Theme = "@style/Theme.AppCompat.NoActionBar")]
    public class ResultActivity : Activity
    {
        private CashDesk CashInDesk;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Result);

            CashInDesk = JsonConvert.DeserializeObject<CashDesk>(Intent.GetStringExtra("Cash"));

            int[] bankNotes = new int[] { 20000, 10000, 5000, 2000, 1000, 500, 200, 100, 50, 20, 10, 5 };
            int[] bankNotesInCashDesk = new int[] { CashInDesk.AmountOf20000Ft, CashInDesk.AmountOf10000Ft, CashInDesk.AmountOf5000Ft, CashInDesk.AmountOf2000Ft, CashInDesk.AmountOf1000Ft, CashInDesk.AmountOf500Ft, CashInDesk.AmountOf200Ft, CashInDesk.AmountOf100Ft, CashInDesk.AmountOf50Ft, CashInDesk.AmountOf20Ft, CashInDesk.AmountOf10Ft, CashInDesk.AmountOf5Ft };

            int overAll = Counter(bankNotes, bankNotesInCashDesk);

            int[] removedCash = IShouldRemoveXCashFromDesk(GetIncome(), bankNotes, bankNotesInCashDesk);
            int[] bankNotesInCashDeskAfterRemoveCash = new int[] { CashInDesk.AmountOf20000Ft, CashInDesk.AmountOf10000Ft, CashInDesk.AmountOf5000Ft, CashInDesk.AmountOf2000Ft, CashInDesk.AmountOf1000Ft, CashInDesk.AmountOf500Ft, CashInDesk.AmountOf200Ft, CashInDesk.AmountOf100Ft, CashInDesk.AmountOf50Ft, CashInDesk.AmountOf20Ft, CashInDesk.AmountOf10Ft, CashInDesk.AmountOf5Ft };

            int removedCashFromDesk = Counter(bankNotes, removedCash);
            int finalBalance = Counter(bankNotes, bankNotesInCashDeskAfterRemoveCash);

            int tip = finalBalance - CashInDesk.OpeningBalance;
            int[] tips = new int[bankNotes.Length];
            if (tip > 0)
            {
                tips = IShouldRemoveXCashFromDesk(tip, bankNotes, bankNotesInCashDeskAfterRemoveCash);
            }
            int[] bankNotesInCashDeskAfterRemovetip = new int[] { CashInDesk.AmountOf20000Ft, CashInDesk.AmountOf10000Ft, CashInDesk.AmountOf5000Ft, CashInDesk.AmountOf2000Ft, CashInDesk.AmountOf1000Ft, CashInDesk.AmountOf500Ft, CashInDesk.AmountOf200Ft, CashInDesk.AmountOf100Ft, CashInDesk.AmountOf50Ft, CashInDesk.AmountOf20Ft, CashInDesk.AmountOf10Ft, CashInDesk.AmountOf5Ft };

            int changingCash = Counter(bankNotes, bankNotesInCashDeskAfterRemovetip);

            FindViewById<TextView>(Resource.Id.billBalance).Text = CashInDesk.ClosingBalance + " Ft";
            FindViewById<TextView>(Resource.Id.finallyBalance).Text = overAll + " Ft";
            FindViewById<TextView>(Resource.Id.income).Text = removedCashFromDesk + " Ft";
            if (tip >= 0)
            {
                FindViewById<TextView>(Resource.Id.tip).Text = tip + " Ft";
            }
            else
            {
                FindViewById<TextView>(Resource.Id.miss).Text = (tip * -1) + " Ft";
            }

            FindViewById<TextView>(Resource.Id.changingCash).Text = changingCash + " Ft";

            FindViewById<TextView>(Resource.Id.out20000).Text = removedCash[0] + " db";
            FindViewById<TextView>(Resource.Id.out10000).Text = removedCash[1] + " db";
            FindViewById<TextView>(Resource.Id.out5000).Text = removedCash[2] + " db";
            FindViewById<TextView>(Resource.Id.out2000).Text = removedCash[3] + " db";
            FindViewById<TextView>(Resource.Id.out1000).Text = removedCash[4] + " db";
            FindViewById<TextView>(Resource.Id.out500).Text = removedCash[5] + " db";
            FindViewById<TextView>(Resource.Id.out200).Text = removedCash[6] + " db";
            FindViewById<TextView>(Resource.Id.out100).Text = removedCash[7] + " db";
            FindViewById<TextView>(Resource.Id.out50).Text = removedCash[8] + " db";
            FindViewById<TextView>(Resource.Id.out20).Text = removedCash[9] + " db";
            FindViewById<TextView>(Resource.Id.out10).Text = removedCash[10] + " db";
            FindViewById<TextView>(Resource.Id.out5).Text = removedCash[11] + " db";

            if (tip > 0)
            {
                FindViewById<TextView>(Resource.Id.out20000tip).Text = tips[0] + " db";
                FindViewById<TextView>(Resource.Id.out10000tip).Text = tips[1] + " db";
                FindViewById<TextView>(Resource.Id.out5000tip).Text = tips[2] + " db";
                FindViewById<TextView>(Resource.Id.out2000tip).Text = tips[3] + " db";
                FindViewById<TextView>(Resource.Id.out1000tip).Text = tips[4] + " db";
                FindViewById<TextView>(Resource.Id.out500tip).Text = tips[5] + " db";
                FindViewById<TextView>(Resource.Id.out200tip).Text = tips[6] + " db";
                FindViewById<TextView>(Resource.Id.out100tip).Text = tips[7] + " db";
                FindViewById<TextView>(Resource.Id.out50tip).Text = tips[8] + " db";
                FindViewById<TextView>(Resource.Id.out20tip).Text = tips[9] + " db";
                FindViewById<TextView>(Resource.Id.out10tip).Text = tips[10] + " db";
                FindViewById<TextView>(Resource.Id.out5tip).Text = tips[11] + " db";
            }

            FindViewById<TextView>(Resource.Id.in20000).Text = bankNotesInCashDeskAfterRemovetip[0] + " db";
            FindViewById<TextView>(Resource.Id.in10000).Text = bankNotesInCashDeskAfterRemovetip[1] + " db";
            FindViewById<TextView>(Resource.Id.in5000).Text = bankNotesInCashDeskAfterRemovetip[2] + " db";
            FindViewById<TextView>(Resource.Id.in2000).Text = bankNotesInCashDeskAfterRemovetip[3] + " db";
            FindViewById<TextView>(Resource.Id.in1000).Text = bankNotesInCashDeskAfterRemovetip[4] + " db";
            FindViewById<TextView>(Resource.Id.in500).Text = bankNotesInCashDeskAfterRemovetip[5] + " db";
            FindViewById<TextView>(Resource.Id.in200).Text = bankNotesInCashDeskAfterRemovetip[6] + " db";
            FindViewById<TextView>(Resource.Id.in100).Text = bankNotesInCashDeskAfterRemovetip[7] + " db";
            FindViewById<TextView>(Resource.Id.in50).Text = bankNotesInCashDeskAfterRemovetip[8] + " db";
            FindViewById<TextView>(Resource.Id.in20).Text = bankNotesInCashDeskAfterRemovetip[9] + " db";
            FindViewById<TextView>(Resource.Id.in10).Text = bankNotesInCashDeskAfterRemovetip[10] + " db";
            FindViewById<TextView>(Resource.Id.in5).Text = bankNotesInCashDeskAfterRemovetip[11] + " db";

            FindViewById<TextView>(Resource.Id.ic20000).Text = (bankNotesInCashDeskAfterRemovetip[0] + removedCash[0]) + " db";
            FindViewById<TextView>(Resource.Id.ic10000).Text = (bankNotesInCashDeskAfterRemovetip[1] + removedCash[1]) + " db";
            FindViewById<TextView>(Resource.Id.ic5000).Text = (bankNotesInCashDeskAfterRemovetip[2] + removedCash[2]) + " db";
            FindViewById<TextView>(Resource.Id.ic2000).Text = (bankNotesInCashDeskAfterRemovetip[3] + removedCash[3]) + " db";
            FindViewById<TextView>(Resource.Id.ic1000).Text = (bankNotesInCashDeskAfterRemovetip[4] + removedCash[4]) + " db";
            FindViewById<TextView>(Resource.Id.ic500).Text = (bankNotesInCashDeskAfterRemovetip[5] + removedCash[5]) + " db";
            FindViewById<TextView>(Resource.Id.ic200).Text = (bankNotesInCashDeskAfterRemovetip[6] + removedCash[6]) + " db";
            FindViewById<TextView>(Resource.Id.ic100).Text = (bankNotesInCashDeskAfterRemovetip[7] + removedCash[7]) + " db";
            FindViewById<TextView>(Resource.Id.ic50).Text = (bankNotesInCashDeskAfterRemovetip[8] + removedCash[8]) + " db";
            FindViewById<TextView>(Resource.Id.ic20).Text = (bankNotesInCashDeskAfterRemovetip[9] + removedCash[9]) + " db";
            FindViewById<TextView>(Resource.Id.ic10).Text = (bankNotesInCashDeskAfterRemovetip[10] + removedCash[10]) + " db";
            FindViewById<TextView>(Resource.Id.ic5).Text = (bankNotesInCashDeskAfterRemovetip[11] + removedCash[11]) + " db";
        }

        public int[] IShouldRemoveXCashFromDesk(int income, int[] bankNotes, int[] bankNotesInCashDesk)
        {
            int[] removedCash = new int[bankNotes.Length];

            while (income > 0)
            {
                for (int i = 0; i < bankNotes.Length; i++)
                {
                    while (income - bankNotes[i] >= 0 && bankNotesInCashDesk[i] > 0)
                    {
                        income -= bankNotes[i];
                        bankNotesInCashDesk[i]--;
                        removedCash[i]++;
                        RemoveCash(bankNotes, i);
                    }
                }
            }

            return removedCash;
        }

        private int GetIncome()
        {
            return CashInDesk.ClosingBalance - CashInDesk.OpeningBalance;
        }

        private int Counter(int[] bankNotes, int[] bankNotesInCashDesk)
        {
            int value = 0;
            for (int i = 0; i < bankNotes.Length; i++)
            {
                value += bankNotes[i] * bankNotesInCashDesk[i];
            }

            return value;
        }

        private void RemoveCash(int[] bankNotes, int i)
        {
            if (bankNotes[i] == 20000)
            {
                CashInDesk.AmountOf20000Ft--;
            }
            else if (bankNotes[i] == 10000)
            {
                CashInDesk.AmountOf10000Ft--;
            }
            else if (bankNotes[i] == 5000)
            {
                CashInDesk.AmountOf5000Ft--;
            }
            else if (bankNotes[i] == 2000)
            {
                CashInDesk.AmountOf2000Ft--;
            }
            else if (bankNotes[i] == 1000)
            {
                CashInDesk.AmountOf1000Ft--;
            }
            else if (bankNotes[i] == 500)
            {
                CashInDesk.AmountOf500Ft--;
            }
            else if (bankNotes[i] == 200)
            {
                CashInDesk.AmountOf200Ft--;
            }
            else if (bankNotes[i] == 100)
            {
                CashInDesk.AmountOf100Ft--;
            }
            else if (bankNotes[i] == 50)
            {
                CashInDesk.AmountOf50Ft--;
            }
            else if (bankNotes[i] == 20)
            {
                CashInDesk.AmountOf20Ft--;
            }
            else if (bankNotes[i] == 10)
            {
                CashInDesk.AmountOf10Ft--;
            }
            else if (bankNotes[i] == 5)
            {
                CashInDesk.AmountOf5Ft--;
            }
        }
    }
}