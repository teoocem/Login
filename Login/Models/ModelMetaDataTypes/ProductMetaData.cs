using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using System.ComponentModel.DataAnnotations;

namespace Login.Models.ModelMetaDataTypes
{
    public class ProductMetaData
    {
        [Key]
        public int UserID { get; set; }
        [Required(ErrorMessage = "Lütfen kullanıcı adını giriniz.")]
        [StringLength(50, ErrorMessage = "Lütfen kullanıcı adını en fazla 50 karakter giriniz.")]
        public string? UserName { get; set; }

        public int Password { get; set; }
    }
}
