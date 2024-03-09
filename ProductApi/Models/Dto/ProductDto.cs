using System.ComponentModel.DataAnnotations;

namespace ProductApi.Models.Dto
{
    public class ProductDto
    {
        public ProductDto(string Navn, string FaesterTilNavn, string ForrigeFaesterNavn, string Kommentarer, string Gaard, string Sogn, string FaestebrevUdstedt, string Side, int Price, int ItemsInStock, int ItemsReserved)
        {
            this.Navn = Navn;
            this.FaesterTilNavn = FaesterTilNavn;
            this.ForrigeFaesterNavn = ForrigeFaesterNavn;
            this.Kommentarer = Kommentarer;
            this.Gaard = Gaard;
            this.Sogn = Sogn;
            this.FaestebrevUdstedt = FaestebrevUdstedt;
            this.Side = Side;
            this.Price = Price;
            this.ItemsInStock = ItemsInStock;
            this.ItemsReserved = ItemsReserved;
        }

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
        public int ItemsReserved { get; internal set; }
    }
}
