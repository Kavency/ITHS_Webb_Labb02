using KayakCove.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace KayakCove.Application.DTOs;

public class UserDto
{
    public int Id { get; set; }

    [Required]
    public string Username { get; set; }
    
    [Required]
    public string Password { get; set; }
    
    [Required]
    public string Firstname { get; set; }

    [Required]
    public string Lastname { get; set; }

    [Required]
    public string Email { get; set; }
    
    public string Phonenumber { get; set; }
    
    public string Streetaddress { get; set; }
    
    public string Postalcode { get; set; }
    
    public string City { get; set; }
    
    public string Country { get; set; }
    public DateTime AccountCreated { get; set; }
    public DateTime LastLogin { get; set; }
    public DateTime LastPasswordChange { get; set; }

    [Required]
    public int RoleId { get; set; }

    public Role Role { get; set; }
}
