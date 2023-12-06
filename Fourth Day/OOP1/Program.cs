﻿using OOP1;
using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product product1 = new Product();   
            product1.Id = 1;
            product1.CategoryId = 2;
            product1.ProductName= "Masa";
            product1.UnitPrice = 500;
            product1.UnitsInStock = 3;


            Product product2 = new Product { Id = 2, CategoryId = 3, ProductName = "Kalem", UnitPrice = 5,UnitsInStock=100  };  
        
            ProductManager productManager = new ProductManager();
            productManager.Add(product1);
            productManager.Add(product2);

            productManager.topla2(9, 5);



            int toplamaSonucu = productManager.topla(9,5);
            Console.WriteLine(toplamaSonucu);
            

        
        
        
        }


    }
}