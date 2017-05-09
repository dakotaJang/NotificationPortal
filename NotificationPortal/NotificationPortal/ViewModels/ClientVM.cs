﻿using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NotificationPortal.ViewModels
{
    public class ClientIndexVM {
        public IPagedList<ClientVM> Clients { get; set; }

        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public string ClientHeadingSort { get; set; }
        public string StatusSort { get; set; }
    }

    public class ClientCreateVM
    {
        [Required]
        [DisplayName("Client Name*")]
        public string ClientName { get; set; }

        [Required]
        public int StatusID { get; set; }

        [DisplayName("Status")]
        public string StatusName { get; set; }

        [DisplayName("Select Status*")]
        public SelectList StatusList { get; set; }
    }

    public class ClientVM
    {
        [Required]
        public string ReferenceID { get; set; }

        public int ClientID { get; set; }

        [Required]
        [DisplayName("Client")]
        public string ClientName { get; set; }

        [Required]
        public int StatusID { get; set; }

        [DisplayName("Status")]
        public string StatusName { get; set; }

        public SelectList StatusList { get; set; }

        [DisplayName("Number of Applications")]
        public int NumOfApps { get; set; }

        public IEnumerable<ClientApplicationVM> Applications { get; set; }
    }

    public class ClientApplicationVM
    {
        public string ReferenceID { get; set; }

        [DisplayName("Application Name")]
        public string ApplicationName { get; set; }

        public string Description { get; set; }

        [DisplayName("Web Link")]
        public string URL { get; set; }
    }
}