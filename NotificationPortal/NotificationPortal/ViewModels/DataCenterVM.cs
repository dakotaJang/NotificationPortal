﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NotificationPortal.ViewModels
{
    public class DataCenterVM
    {

        public int LocationID { get; set; }

        [Required]
        public string Location { get; set; }


        public int ServerID { get; set; }

        public virtual SelectList Servers { get; set; }
    }
}
