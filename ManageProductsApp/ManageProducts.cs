using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace ManageProductsApp
{
    public record Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
    }

    public class ManageProducts
    {
        private string fileName = "ProductList.json";
        private List<Product> products = new List<Product>();

        public List<Product> GetProducts()
        {
            GetDataFromFile();
            return products;
        }

        public void StoreToFile()
        {
            try
            {
                string json = JsonSerializer.Serialize(products, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(fileName, json);
            }
            catch (Exception ex)
            {
                throw new Exception("Error storing data to file: " + ex.Message);
            }
        }

        public void GetDataFromFile()
        {
            try
            {
                if (File.Exists(fileName))
                {
                    string jsonData = File.ReadAllText(fileName);
                    products = JsonSerializer.Deserialize<List<Product>>(jsonData) ?? new List<Product>();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error reading data from file: " + ex.Message);
            }
        }

        public void InsertProduct(Product product)
        {
            if (products.Any(p => p.ProductId == product.ProductId))
                throw new Exception("Product already exists.");

            products.Add(product);
            StoreToFile();
        }

        public void UpdateProduct(Product product)
        {
            var existingProduct = products.SingleOrDefault(p => p.ProductId == product.ProductId);
            if (existingProduct == null)
                throw new Exception("Product does not exist.");

            existingProduct.ProductName = product.ProductName;
            StoreToFile();
        }

        public void DeleteProduct(Product product)
        {
            var existingProduct = products.SingleOrDefault(p => p.ProductId == product.ProductId);
            if (existingProduct == null)
                throw new Exception("Product does not exist.");

            products.Remove(existingProduct);
            StoreToFile();
        }
    }

}
