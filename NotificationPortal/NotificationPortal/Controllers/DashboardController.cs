﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NotificationPortal.Repositories;
using NotificationPortal.ViewModels;
using NotificationPortal.Models;

namespace NotificationPortal.Controllers
{
    public class DashboardController : AppBaseController
    {
        private readonly DashboardRepo _dRepo = new DashboardRepo();
        // GET: Dashboard
        [Authorize]
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            DashboardIndexVM dashboard = _dRepo.GetDashboard(User, sortOrder, currentFilter, searchString, page);
            return View(dashboard);
        }

    }
}