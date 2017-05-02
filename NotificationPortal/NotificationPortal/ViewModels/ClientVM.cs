﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NotificationPortal.ViewModels
{
    public class ClientVM
    {
        public int ClientID { get; set; }

        [Required]
        [DisplayName("Client Name")]
        public string ClientName { get; set; }

        [Required]
        public int StatusID { get; set; }

        [DisplayName("Status Name")]
        public string StatusName { get; set; }

        public SelectList StatusList { get; set; }
    }

}