using System.ComponentModel.DataAnnotations;

 namespace ShoppingApp.Models.AdminModel
{
    public class AdminPoco
    {
        [Key]
        public string ad_id { get; set; }

        [Required(ErrorMessage = "{0} cannot be null")]
        [StringLength(20, ErrorMessage = "Invalid {0}")]
        public string ad_name { get; set; }

        [Required(ErrorMessage = "{0} cannot be null")]
        [StringLength(20, ErrorMessage = "Invalid {0}")]
        public string ad_password { get; set; }
    }
}
