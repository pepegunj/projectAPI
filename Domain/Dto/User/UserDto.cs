﻿namespace Domain.Dto.User;

public class UserDto
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string? ProfileImageURL { get; set; }
}