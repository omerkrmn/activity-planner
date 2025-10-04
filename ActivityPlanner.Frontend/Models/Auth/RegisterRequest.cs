using System.ComponentModel.DataAnnotations;

namespace ActivityPlanner.Frontend.Models.Auth
{
    public record RegisterRequest(string firstName,
        string lastName,
        string userName,
        string password,
        string email,
        string phoneNumber,
        ICollection<string> roles);
}
