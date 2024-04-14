

//using ProductApi.Models.Dto;
//using Stripe;

//namespace ProductApi.Models
//{
//    public class ProductConverter : IConverter<Product, ProductDto>
//    {
//        public Product Convert(ProductDto sharedProduct)
//        {
//            return new Product
//            {
//                ID = sharedProduct.ID,
//                Navn = sharedProduct.Navn,
//                FaesterTilNavn = sharedProduct.FaesterTilNavn,
//                ForrigeFaesterNavn=sharedProduct.ForrigeFaesterNavn,
//                Kommentarer=sharedProduct.Kommentarer,
//                Gaard=sharedProduct.Gaard,
//                Sogn=sharedProduct.Sogn,
//                FaestebrevUdstedt=sharedProduct.FaestebrevUdstedt,
//                Side = sharedProduct.Side,
//                Price=sharedProduct.Price,
//                ItemsInStock = sharedProduct.ItemsInStock,
//                ItemsReserved = sharedProduct.ItemsReserved
//            };
//        }

//        public ProductDto Convert(Product hiddenProduct)
//        {
//            return new ProductDto
//            {
//                ID = hiddenProduct.ID,
//                Navn = hiddenProduct.Navn,
//                FaesterTilNavn = hiddenProduct.FaesterTilNavn,
//                ForrigeFaesterNavn = hiddenProduct.ForrigeFaesterNavn,
//                Kommentarer = hiddenProduct.Kommentarer,
//                Gaard = hiddenProduct.Gaard,
//                Sogn = hiddenProduct.Sogn,
//                FaestebrevUdstedt = hiddenProduct.FaestebrevUdstedt,
//                Side = hiddenProduct.Side,
//                Price = hiddenProduct.Price,
//                ItemsInStock = hiddenProduct.ItemsInStock,
//                ItemsReserved = hiddenProduct.ItemsReserved
//            };
//        }
//    }
//}

