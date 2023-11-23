using System.ComponentModel.DataAnnotations;

namespace EmpMgmtUI.Models
{
    public class LoginData
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [MinLength(4)]
        public string Password { get; set; }
    }
}
