using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class Warehouse
    {
        [Key]
        public int WarehouseId { get; set; }

        [Required(ErrorMessage = "The  field  {0} is requiered ")]
        [Range(1,double.MaxValue, ErrorMessage = "You must select a {0}")]
        [Index("Warehouse_CompanyId_Name_Index", 1, IsUnique = true)]//con esto no permitimos que no se pueda duplicar
        [Display(Name = "Company")]
        public int CompanyId { get; set; }

        [Required(ErrorMessage = "The  field  {0} is requiered ")]
        [MaxLength(50, ErrorMessage = "The filed {0} must be maximun {1} characters length ")]
        [Display(Name = "Warehouse")]
        [Index("Warehouse_CompanyId_Name_Index",2, IsUnique = true)]//con esto no permitimos que no se pueda duplicar
        public string Name { get; set; }


        [Required(ErrorMessage = "The  field  {0} is requiered ")]
        [MaxLength(20, ErrorMessage = "The filed {0} must be maximun {1} characters length ")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }


        [Required(ErrorMessage = "The  field  {0} is requiered ")]
        [MaxLength(100, ErrorMessage = "The filed {0} must be maximun {1} characters length ")]
        public string Address { get; set; }

        

        [Required(ErrorMessage = "The  field  {0} is requiered ")]
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "The  field  {0} is requiered ")]
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        [Display(Name = "City")]
        public int CityId { get; set; }


        public virtual Deparment Deparment { get; set; }
        public virtual City City { get; set; }

        public virtual Company Company { get; set; }


        public virtual ICollection<Inventory> Inventories { get; set; }




    }
}