using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
        public static List<City> GetCities()
        {
            var cities = db.Cities.ToList();
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
    }
}