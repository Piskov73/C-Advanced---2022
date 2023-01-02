using System;
using System.Diagnostics;
using System.Text;

namespace StockMarket
{
    public class Stock
    {
        //•	CompanyName: string
        //•	Director: string
        //•	PricePerShare: decimal
        //•	TotalNumberOfShares: int
        //•	MarketCapitalization: decimal
        public Stock(string companyName,string director, decimal pricePerShare,int totalNumberOfShares)
        {
            CompanyName = companyName;
            Director = director;
            PricePerShare = pricePerShare;
            TotalNumberOfShares = totalNumberOfShares;
            MarketCapitalization = pricePerShare*totalNumberOfShares;

        }
        private string companyName;

        public string CompanyName
        {
            get { return companyName; }
            set { companyName = value; }
        }

        private string director;

        public string Director
        {
            get { return director; }
            set { director = value; }
        }

        private decimal pricePerShare;

        public decimal PricePerShare
        {
            get { return pricePerShare; }
            set { pricePerShare = value; }
        }

        private int totalNumberOfShares;

        public int TotalNumberOfShares
        {
            get { return totalNumberOfShares; }
            set { totalNumberOfShares = value; }
        }

        
        private decimal marketCapitalization;

        public decimal MarketCapitalization
        {
            get { return marketCapitalization; }
            set { marketCapitalization = value; }
        }

        public override string ToString()
        {
        StringBuilder sb= new StringBuilder();
            //Company: { CompanyName}
            //Director: { Director}
            //Price per share: ${ PricePerShare}
            //Market capitalization: ${ MarketCapitalization}
            sb.AppendLine($"Company: {CompanyName}");
            sb.AppendLine($"Director: {Director}");
            sb.AppendLine($"Price per share: ${PricePerShare}");
            sb.AppendLine($"Market capitalization: ${MarketCapitalization}");
            return sb.ToString().Trim();
        }


    }
}
