namespace Testowanie.Cmenatrz.MVC.Models
{
    public record LoginRequest
    {
        public string Login { get; set; }
        public string Haslo { get; set; }
    }
}