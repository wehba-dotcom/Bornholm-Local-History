using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductApi.Models
{
    public class Product
    {
        [Key]
        public int ID { get; set; }
        public string? Navn { get; set; }
        public string? FaesterTilNavn { get; set; }
        public string? ForrigeFaesterNavn { get; set; }
        public string? Kommentarer { get; set; }
        public string? Gaard { get; set; }
        public string? Sogn { get; set; }
        public string? FaestebrevUdstedt { get; set; }
        public string? Side { get; set; }
        public decimal Price { get; set; }
        public int ItemsInStock { get; set; }
        public int ItemsReserved { get;  set; }

        // Constructor
        public Product( string? navn, string? faesterTilNavn, string? forrigeFaesterNavn, string? kommentarer,
            string? gaard, string? sogn, string? faestebrevUdstedt, string? side, decimal price, int itemsInStock, int itemsReserved)
        {
            
            Navn = navn;
            FaesterTilNavn = faesterTilNavn;
            ForrigeFaesterNavn = forrigeFaesterNavn;
            Kommentarer = kommentarer;
            Gaard = gaard;
            Sogn = sogn;
            FaestebrevUdstedt = faestebrevUdstedt;
            Side = side;
            Price = price;
            ItemsInStock = itemsInStock;
            ItemsReserved = itemsReserved;
        }
    }
}
