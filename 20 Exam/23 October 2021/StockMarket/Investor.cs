using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        private List<Stock> portfolio;
        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
            portfolio = new List<Stock>();
        }

        // •FullName: string
        //•	EmailAddress: string
        //•	MoneyToInvest: decimal
        //•	BrokerName: string
        private string fullName;

        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }
        private string emailAddress;

        public string EmailAddress
        {
            get { return emailAddress; }
            set { emailAddress = value; }
        }

        private decimal moneyToInvest;

        public decimal MoneyToInvest
        {
            get { return moneyToInvest; }
            set { moneyToInvest = value; }
        }
        private string brokerName;

        public string BrokerName
        {
            get { return brokerName; }
            set { brokerName = value; }
        }

        public int Count { get { return portfolio.Count; } }

        public void BuyStock(Stock stock)
        {
            if (MoneyToInvest >= stock.PricePerShare && stock.MarketCapitalization > 10000m)
            {
                portfolio.Add(stock);
                MoneyToInvest -= stock.PricePerShare;
            }
        }
        public string SellStock(string companyName, decimal sellPrice)
        {
            Stock filter = portfolio.FirstOrDefault(x => x.CompanyName == companyName);
            if (portfolio != null)
            {
                if (sellPrice < filter.PricePerShare)
                {
                    return $"Cannot sell {companyName}.";
                }
                else
                {
                    MoneyToInvest += sellPrice;
                    portfolio.Remove(filter);
                    return $"{companyName} was sold.";

                }
            }

            return $"{companyName} does not exist.";
        }

        public Stock FindStock(string companyName)
        {
            return portfolio.FirstOrDefault(x => x.CompanyName == companyName);
        }

        public Stock FindBiggestCompany()
        {
            int count = 0;
            Stock filter=null;
            foreach (var item in portfolio.OrderByDescending(x=>x.MarketCapitalization))
            {
                if (count == 0)
                {
                    filter = item;
                }
                count++;
            }
            return filter;
        }

        public string InvestorInformation()
        {
            StringBuilder sb= new StringBuilder();
            sb.AppendLine($"The investor {fullName} with a broker {brokerName} has stocks:");
            foreach (var item in portfolio)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().Trim();
        }



    }
}
