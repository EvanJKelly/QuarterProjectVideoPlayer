﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuatorProjectVIdeoPlayer.Models
{
    public class Account
    {
        public int AccountId { get; set; }

        [Required]
        [StringLength(30)]
        public string Username { get; set; }

        [Required]
        [StringLength(100)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Email address")]
        [EmailAddress(ErrorMessage = "That doesn't look like an email")]
        public string Email { get; set; }

        /// <summary>
        /// The theme the website is displayed in
        /// </summary>
        public bool DarkMode { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
