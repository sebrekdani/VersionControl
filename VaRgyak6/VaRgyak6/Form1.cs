using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VaRgyak6.Entities1;
using VaRgyak6.MnbServiceReference;

namespace VaRgyak6
{
    public partial class Form1 : Form
    {
        public BindingList<RateData1> Rates = new BindingList<RateData1>();
        
        public Form1()
        {
            InitializeComponent();
            RefreshData();

        }

        private void xmlFeldolgozas(string result)
        {
            
        }

        private void RefreshData() 
        {
            this.Rates.Clear();
            var mnbService = new MNBArfolyamServiceSoapClient();

            var request = new GetExchangeRatesRequestBody()
            {
                currencyNames = "EUR",
                startDate = "2020-01-01",
                endDate = "2020-06-30"
            };
            var response = mnbService.GetExchangeRates(request);
            dataGridView1.DataSource = Rates;
            var result = response.GetExchangeRatesResult;
            
            xmlFeldolgozas(result);
        }
    }
}
