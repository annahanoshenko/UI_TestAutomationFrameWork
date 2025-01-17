
namespace DemoblazeUiTAF.AutoTestsDemoblazePOM.Entities
{
    internal class OrderEntity
    {
        public string Name {  get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string CreditCard { get; set; }
        public string Month { get; set; }
        public string Year {  get; set; }

        public OrderEntity(string name, string country, string city, string creditCard, string month, string year) 
        {
            Name = name;
            Country = country;
            City = city;
            CreditCard = creditCard;
            Month = month;
            Year = year;
        }

    }
}
