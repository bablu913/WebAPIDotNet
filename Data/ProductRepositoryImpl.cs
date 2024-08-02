using Microsoft.AspNetCore.Mvc;
using WebAPIDemo.Data;
using WebAPIDemo.Models;
namespace WebAPIDemo.Data
{
    public class ProductRepositoryImpl : IProductRepository
    {
        List<Product> productList = new List<Product>
        {
            new Product{ ProductId=1,ProductName="Soccer Ball" , ProductCode ="SOB-BAL1",Price=2000, Category="Soccer" ,ImageUrl=@"assets/images/socccerball.jpeg", Description="There are many variations of passages of Lorem Ipsum available",StarRating=4.5},
            new Product{ ProductId=2,ProductName="Kayak" , Price=10000,ProductCode ="SOB-BAL1" ,Category="WaterSports" ,ImageUrl=@"assets/images/kayak.jpeg", Description="There are many variations of passages of Lorem Ipsum available",StarRating=3.7},
            new Product{ ProductId=3,ProductName="Life Jacket" , Price=800,ProductCode ="SOB-BAL1" ,Category="Water Sports", ImageUrl=@"assets/images/lifeJacket.jpeg", Description="There are many variations of passages of Lorem Ipsum available",StarRating=2.5},
            new Product{ ProductId=4,ProductName="Chess Board" , Price=200,ProductCode ="SOB-BAL1", Category="Indoor Games",ImageUrl=@"assets/images/chessboard.jpeg", Description="There are many variations of passages of Lorem Ipsum available",StarRating=4.3},
            new Product{ ProductId=5,ProductName="Carrom Coins" ,ProductCode ="SOB-BAL1" ,Price=700, Category="Soccer",ImageUrl=@"assets/images/socccerball.jpeg", Description="There are many variations of passages of Lorem Ipsum available",StarRating=3.5},
        };
        public Task<List<Product>> GetProducts()
        {
            return Task.Run(()=> productList);
        }

        public Task<Product>? GetProductById(int id)
        {
            Task<Product>? pdtFound = Task.Run(()=> productList.SingleOrDefault(x=>x.ProductId == id));
            if(pdtFound != null)
            {
                return pdtFound;
            }
            else
            {
                return null;
            }
        }
        public async Task<Product?> UpdateProductPrice(int id, double newPrice)
        {
            Product product = await GetProductById(id);
            if (product != null)
            {
                product.Price = newPrice;
                
            }
            return product;
        }
        public async Task<bool> CreateProduct(Product product)
        {
            Product p = null;
            p = await GetProductById(product.ProductId);
            if (p != null || product == null)
            {
                return await Task.FromResult(true);
            }
            else
            {
                productList.Add(product);

                return await Task.FromResult(true);
            }
        }

        public async Task<bool> DeleteProduct(int id)
        {
            bool isRemoved = false;
            Product? pdt = await GetProductById(id);
            if (pdt != null)
            {
                isRemoved = productList.Remove(pdt);
            }

            return isRemoved;

        }
    }
}
