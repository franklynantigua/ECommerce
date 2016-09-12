using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class Deparment
    {
        [Key]
        public int  DepartmentId { get; set; }

        [Required (ErrorMessage = "The  field  {0} is requiered ")]
        [MaxLength(50, ErrorMessage = "The filed {0} must be maximun {1} characters length ")]
        [Index("Department_Name_Index", IsUnique = true)]
        [Display(Name = "Department")]
        public string Name  { get; set; }

        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<Company> Companies { get; set; }

        public virtual ICollection<User> Users { get; set; }

    }
}