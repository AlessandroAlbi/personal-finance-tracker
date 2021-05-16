﻿using System.ComponentModel.DataAnnotations;

namespace PersonalFinanceTracker.Login.Api.Dto
{
    public class LoginModelDto
    {
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
