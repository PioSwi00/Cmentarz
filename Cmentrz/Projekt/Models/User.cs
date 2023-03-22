using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt.Models
{
    public class User
    {
       [Key]
       public int Id { get; set; }
       
        [Column("Login", TypeName="nvarchar(50)")]
        public string? Login { get; set; }

        [Column("Password", TypeName = "nvarchar(50)")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "min 3, max 50 ")]
        public string? Password { get; set; }

       

      


    }
}
