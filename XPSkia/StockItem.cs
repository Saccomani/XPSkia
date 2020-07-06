using System;
namespace XPSkia
{
    public class StockItem
    {
        public string symbol { get; set; }
        public string timestamp { get; set; }
        public string tradingDay { get; set; }
        public double open { get; set; }
        public double high { get; set; }
        public double low { get; set; }
        public double close { get; set; }
        public double volume { get; set; }
    }
}
