

using ProductApi.Models.Dto;

namespace ProductApi.Models
{
    public class ProductConverter : IConverter<Product, ProductDto>
    {
        public Product Convert(ProductDto sharedProduct)
        {
            return new Product
            {
                ID = sharedProduct.Id,
                Navn = sharedProduct.Name,
                Price = sharedProduct.Price,
                ItemsInStock = sharedProduct.ItemsInStock,
                ItemsReserved = sharedProduct.ItemsReserved
            };
        }

        public ProductDto Convert(Product hiddenProduct)
        {
            return new ProductDto
            {
                Id = hiddenProduct.ID,
                Name = hiddenProduct.Navn,
                Price = hiddenProduct.Price,
                ItemsInStock = hiddenProduct.ItemsInStock,
                ItemsReserved = hiddenProduct.ItemsReserved
            };
        }
    }
}

