using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models_TGDD
{
    public class AuthenticateModel
    {
        [Required]
        public string UserID { get; set; }

        [Required]
        public string Pass { get; set; }
    }

    public class AppSettings
    {
        public string Secret { get; set; }

    }
}
