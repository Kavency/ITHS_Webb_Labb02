﻿namespace KayakCove.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public string Phonenumber { get; set; }
    public string Streetaddress { get; set; }
    public string Postalcode { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public int RoleId { get; set; }
    public Role Role { get; set; }
}
