﻿using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models.AccountViewModel
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Adres e-mail")]
        public string Email { get; set; }
    }
}