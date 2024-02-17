using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductApi.Models
{
    public class Product
    {
        [Key]
        public int ID { get; set; }
        public string? Navn { get; set; }
        public string? FaesterTilNavn {  get; set; }
        public string? ForrigeFaesterNavn { get; set; }
        public string? Kommentarer {  get; set; }
        public string? Gaard {  get; set; }
        public string? Sogn { get; set; }
        public string? FaestebrevUdstedt { get; set; }
        public string? Side {  get; set; }
        public decimal Price { get; set; }
        public int ItemsReserved { get; internal set; }
    }
}
