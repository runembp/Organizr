﻿namespace Organizr.Infrastructure.DTO;

public class LoginUserResponse
{
    public string Username { get; set; }
    public string Token { get; set; }
    public bool Succeeded { get; set; }
}