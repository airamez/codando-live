using System;
using System.Collections.Generic;

namespace OurStore;

public class Products {

    private List<Product> products;

    public Products () {
        products = new();
    }

    public void Add(Product product) {
        products.Add(product);
    }

    public Product Add(int id, string description, decimal price) {
        Product product = new(id, description, price);
        Add(product);
        return product;
    }

    public Product FindById (int id) {
        foreach (Product product in products) {
            if (product.ID == id) {
                return product;
            }
        }
        return null;
    }

    public void Print() {
        Console.WriteLine("".PadLeft(60, '-'));
        Console.WriteLine("Products:");
        foreach (Product product in products)
        {
            Console.Write("\t");
            Console.WriteLine(product);
        }
        Console.WriteLine("".PadLeft(60, '-'));
    }
}