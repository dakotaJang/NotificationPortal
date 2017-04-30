﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NotificationPortal.ViewModels
{
    public class UserVM
    {
        public string UserID { get; set; }

        public int? ClientID { get; set; }

        [Required]
        public int StatusID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Business Title")]
        public string BusinessTitle { get; set; }

        [Required]
        [Display(Name = "Business Phone")]
        public string BusinessPhone { get; set; }

        [Required]
        [Display(Name = "Mobile Phone")]
        public string MobilePhone { get; set; }

        [Required]
        [Display(Name = "Home Phone")]
        public string HomePhone { get; set; }

        [Display(Name = "Status")]
        public string StatusName { get; set; }

        public SelectListItem StatusList { get; set; }
    }

    public class AddUserVM
    {
        public string UserID { get; set; }

        [Required]
        public int StatusID { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Business Title")]
        public string BusinessTitle { get; set; }

        [Display(Name = "Status")]
        public IEnumerable<SelectListItem> StatusList { get; set; }
    }
}