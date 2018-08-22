using System.ComponentModel.DataAnnotations;


namespace AspnetNote.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "You are ID Enter")]
        public string UserId { get; set; }

        [Required(ErrorMessage ="You are Password Enter")]
        public string UserPassword { get; set; }
    }
}
