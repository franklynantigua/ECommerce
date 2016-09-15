using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ECommerce.Classes
{
    public class CombosHelper :IDisposable
    {
        private static ECommerceContext db = new ECommerceContext();
        public static List<Deparment> GetDepatment()
        {
            var department = db.Deparments.ToList();
            department.Add(new Deparment
            {
                DepartmentId = 0,
                Name = "[Select a department...]",
            });
            return department.OrderBy(d => d.Name).ToList();
        }


        public static List<Product> GetProducts(int companyId, bool sw)
        {
            var products = db.Products.Where(p => p.CompanyId == companyId).ToList();
            return products.OrderBy(p => p.Description).ToList();
        }





        public static List<Product> GetProducts(int companyId)
        {
            var products = db.Products.Where(p => p.CompanyId == companyId).ToList();
            products.Add(new Product
            {
                ProductId = 0,
                Description = "[Select a product...]",
            });
            return products.OrderBy(p => p.Description).ToList();
        }

        public static List<City> GetCities(int deparmentId)
        {
            var cities = db.Cities.Where(c => c.DepartmentId==deparmentId).ToList();
            cities.Add(new City
            {
              CityId = 0,
                Name = "[Select a City...]",
            });
            return cities.OrderBy(d => d.Name).ToList();
        }

        public static List<Company> GetCompanies()
        {
            var cities = db.Companies.ToList();
            cities.Add(new Company
            {
                CompanyId = 0,
                Name = "[Select a company...]",
            });
            return cities.OrderBy(d => d.Name).ToList();
        }



        public void Dispose()
        {
           db.Dispose();
        }

        public static List<Category> GetCategories(int companyId)
        {

            var cities = db.Categories.Where(c => c.CompanyId== companyId).ToList();
            cities.Add(new Category
            {
                CategoryId = 0,
                Description = "[Select a category...]",
            });
            return cities.OrderBy(d => d.Description).ToList();
        }

        public static List<Customer> GetCustomers(int companyId)
        {
         //   var user = db.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
            var qry = (from cu in db.Customers
                       join cc in db.CompanyCustomers on cu.CustomerId equals cc.CustomerId
                       join co in db.Companies on cc.CompanyId equals co.CompanyId
                       where co.CompanyId == companyId
                       select new { cu }).ToList();


            var customer = new List<Customer>();
            {
                foreach (var item in qry)
                {
                    customer.Add(item.cu);
                }
            }

            customer.Add(new Customer
            {
                CustomerId = 0,
                FirstName= "[Select a customer...]",
            });
            return customer.OrderBy(c => c.FirstName).ThenBy(c => c.LastName).ToList();

        }

        public static List<Tax> GetTaxxes(int companyId)
        {

            var cities = db.Taxes.Where(c => c.CompanyId == companyId).ToList();
            cities.Add(new Tax
            {
                TaxId = 0,
                Description = "[Select a Tax...]",
            });
            return cities.OrderBy(d => d.Description).ToList();
        }


    }
}