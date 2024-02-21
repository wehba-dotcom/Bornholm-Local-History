using ProductApi.Models.Dto;
using SharedModels;

namespace ProductApi.Models
{
    public class ProductConverter : IConverter<Product, ProductDto>
    {
        public Product Convert(ProductDto sharedProduct)
        {
            return new Product
            {
                ID = sharedProduct.ID,
                Navn = sharedProduct.Navn,
                Price = sharedProduct.Price,
                ItemsReserved = sharedProduct.ItemsReserved
            };
        }

        public ProductDto Convert(Product hiddenProduct)
        {
            return new ProductDto
            {
                ID = hiddenProduct.ID,
                Navn = hiddenProduct.Navn,
                Price = hiddenProduct.Price,
                ItemsReserved = hiddenProduct.ItemsReserved
            };
        }
    }
}

