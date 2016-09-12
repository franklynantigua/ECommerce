using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }

        [Required(ErrorMessage = "The  field  {0} is requiered ")]
        [MaxLength(50, ErrorMessage = "The filed {0} must be maximun {1} characters length ")]
        [Index("Company_Name_Index", IsUnique = true)]
        [Display(Name = "Department")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The  field  {0} is requiered ")]
        [MaxLength(20, ErrorMessage = "The filed {0} must be maximun {1} characters length ")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "The  field  {0} is requiered ")]
        [MaxLength(100, ErrorMessage = "The filed {0} must be maximun {1} characters length ")]
        public string Address { get; set; }

        
      
        [DataType(DataType.ImageUrl)]
        public string Logo { get; set; }


        [Required(ErrorMessage = "The  field  {0} is requiered ")]
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        public int DepartmentId { get; set; }

         public int CityId { get; set; }

        [NotMapped]// para no enviar este campo a la base de datos,es decir, solo temporal!
        public HttpPostedFileBase LogoFile { get; set; }


        public virtual Deparment Deparment { get; set; }
        public virtual City City { get; set; }

        public virtual ICollection<User> Users { get; set; }

    }
}