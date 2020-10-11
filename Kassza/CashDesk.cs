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

namespace Kassza
{
    public class CashDesk
    {
        public int OpeningBalance { get; set; }
        public int ClosingBalance { get; set; }

        public int AmountOf5Ft { get; set; }
        public int AmountOf10Ft { get; set; }
        public int AmountOf20Ft { get; set; }
        public int AmountOf50Ft { get; set; }
        public int AmountOf100Ft { get; set; }
        public int AmountOf200Ft { get; set; }
        public int AmountOf500Ft { get; set; }
        public int AmountOf1000Ft { get; set; }
        public int AmountOf2000Ft { get; set; }
        public int AmountOf5000Ft { get; set; }
        public int AmountOf10000Ft { get; set; }
        public int AmountOf20000Ft { get; set; }
    }
}