using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Login.Models
{
    [Table("UserModel",Schema ="dbo")]
    public partial class User
    {
        [Key]
        public int UserID { get; set; }
        [Required(ErrorMessage = "Lütfen kullanıcı adını giriniz.")]
        [StringLength(50, ErrorMessage = "Lütfen kullanıcı adını en fazla 50 karakter giriniz.")]
        public string? UserName { get; set; }
        
        public string Ad { get; set; }
        public int Password { get; set; }

        public string Soyad { get; set; }
        public int Yas { get; set; }

    }
}