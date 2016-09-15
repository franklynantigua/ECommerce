using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace ECommerce.Models
{
    public class User
    {

        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "The  field  {0} is requiered ")]
        [MaxLength(256, ErrorMessage = "The filed {0} must be maximun {1} characters length ")]
        [Display(Name = "E-Email")]
        [Index("User_UserName_Index", IsUnique = true)]//con esto no permitimos que no se pueda duplicar un Email en este caso!
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }


        [Required(ErrorMessage = "The  field  {0} is requiered ")]
        [MaxLength(50, ErrorMessage = "The filed {0} must be maximun {1} characters length ")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }



        [Required(ErrorMessage = "The  field  {0} is requiered ")]
        [MaxLength(50, ErrorMessage = "The filed {0} must be maximun {1} characters length ")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "The  field  {0} is requiered ")]
        [MaxLength(20, ErrorMessage = "The filed {0} must be maximun {1} characters length ")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }


        [Required(ErrorMessage = "The  field  {0} is requiered ")]
        [MaxLength(100, ErrorMessage = "The filed {0} must be maximun {1} characters length ")]
        public string Address { get; set; }



        [DataType(DataType.ImageUrl)]
        public string Photo { get; set; }

        [Required(ErrorMessage = "The  field  {0} is requiered ")]
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "The  field  {0} is requiered ")]
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        [Display(Name = "City")]
        public int CityId { get; set; }
        [Display(Name = "Company")]
        public int CompanyId { get; set; }


        [Display(Name = "User")]
        public string FullName//este es una propiedad de solo lectura y por lo tanto no ira a la base de datos porque no tiene un SET
        {
            get { return  string.Format("{0} {1}",FirstName, LastName); }
        }


        [NotMapped]// para no enviar este campo a la base de datos,es decir, solo temporal!
        public HttpPostedFileBase PhotoFile { get; set; }


        public virtual Deparment Deparment { get; set; }
        public virtual City City { get; set; }

        public virtual Company Company { get; set; }

    }
}