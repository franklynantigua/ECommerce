
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }


        [Required(ErrorMessage = "The  field  {0} is requiered ")]
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        [Index("Product_CompanyId_Description_Index", 1, IsUnique = true)]
        [Display(Name = "Company")]
        public int CompanyId { get; set; }


        [Required(ErrorMessage = "The  field  {0} is requiered ")]
        [MaxLength(50, ErrorMessage = "The filed {0} must be maximun {1} characters length ")]
        [Index("Product_CompanyId_Description_Index", 2, IsUnique = true)]
        [Index("Product_CompanyId_BarCode_Index", 1, IsUnique = true)]
        [Display(Name = "Product")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The  field  {0} is requiered ")]
        [MaxLength(50, ErrorMessage = "The filed {0} must be maximun {1} characters length ")]
        [Index("Product_CompanyId_BarCode_Index", 2, IsUnique = true)]
        [Display(Name = "Bar Code")]
        public string BarCode { get; set; }


        [Required(ErrorMessage = "The  field  {0} is requiered ")]
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }


        [Required(ErrorMessage = "The  field  {0} is requiered ")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        [Range(0, 1, ErrorMessage = "You must select a {0} between {1} and {2}")]
        public int TaxId { get; set; }


        [Required(ErrorMessage = "The  field  {0} is requiered ")]
        [DisplayFormat(DataFormatString = "{0:P2}", ApplyFormatInEditMode = false)]
        [Range(0, double.MaxValue, ErrorMessage = "You must select a {0} between {1} and {2}")]
        public decimal Price { get; set; }


        [DataType(DataType.ImageUrl)]
        public string Image { get; set; }
        [NotMapped]// para no enviar este campo a la base de datos,es decir, solo temporal!
        public HttpPostedFileBase ImageFile { get; set; }

        [DataType(DataType.MultilineText)]
        public int Remarks { get; set; }
        public virtual Company Company { get; set; }

        public virtual Category Category { get; set; }

        public virtual Tax Tax { get; set; }
    }
}