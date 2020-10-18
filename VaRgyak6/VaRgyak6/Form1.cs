using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
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
            var xml = new XmlDocument();
            xml.LoadXml(result);

            foreach (XmlElement element in xml.DocumentElement)
            {
                var rate = new RateData1();
                Rates.Add(rate);

                rate.Date = DateTime.Parse(element.GetAttribute("date"));

                var childElement = (XmlElement)element.ChildNodes[0];
                rate.Currency = childElement.GetAttribute("curr");

                var unit = decimal.Parse(childElement.GetAttribute("unit"));
                var value = decimal.Parse(childElement.InnerText);
                if (unit != 0)
                    rate.Value = value / unit;
            }
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
