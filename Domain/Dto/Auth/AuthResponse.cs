﻿namespace Domain.Dto.Auth;

public class AuthResponse
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Role { get; set; }
    public string Token { get; set; }
}