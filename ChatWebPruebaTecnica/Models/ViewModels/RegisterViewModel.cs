namespace ChatWebPruebaTecnica.Models.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterViewModel
    {
        [Required]
        public string NickName { get; set; }
    }
}