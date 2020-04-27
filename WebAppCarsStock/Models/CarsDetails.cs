using System.Globalization;

namespace WebAppCarsStock.Models
{
    public class CarsDetails
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Comments { get; set; }
        public string CarName { get; set; }
        public string CarDetails { get; set; }
        public string CarPrice { get; set; }
        public ListOfAgents ListAgent { get; set; }

    }
}
