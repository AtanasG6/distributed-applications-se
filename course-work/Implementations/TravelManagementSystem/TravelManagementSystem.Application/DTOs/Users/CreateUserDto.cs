﻿namespace TravelManagementSystem.Application.DTOs.Users
{
    public class CreateUserDto
    {
        public string Username { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty; 

        public string Role { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; }

        public string PhoneNumber { get; set; } = string.Empty;
    }
}
