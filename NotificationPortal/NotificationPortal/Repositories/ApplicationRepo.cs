﻿using NotificationPortal.Models;
using NotificationPortal.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NotificationPortal.Repositories
{
    public class ApplicationRepo
    {
        const string APP_STATUS_TYPE_NAME = "Application";
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public IEnumerable<ApplicationListVM> Sort(IEnumerable<ApplicationListVM> list, string sortOrder, string searchString = null)
        {

            if (!String.IsNullOrEmpty(searchString))
            {
                list = list.Where(c => c.ApplicationName.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case ConstantsRepo.SORT_APP_BY_NAME_DESC:
                    list = list.OrderByDescending(c => c.ApplicationName);
                    break;

                case ConstantsRepo.SORT_STATUS_BY_NAME_DESC:
                    list = list.OrderByDescending(c => c.StatusName);
                    break;

                case ConstantsRepo.SORT_STATUS_BY_NAME_ASCE:
                    list = list.OrderBy(c => c.StatusName);
                    break;


                case ConstantsRepo.SORT_CLIENT_BY_NAME_ASCE:
                    list = list.OrderBy(c => c.ClientName);
                    break;

                case ConstantsRepo.SORT_CLIENT_BY_NAME_DESC:
                    list = list.OrderBy(c => c.ClientName);
                    break;


                case ConstantsRepo.SORT_APP_BY_DESCRIPTION_ASCE:
                    list = list.OrderBy(c => c.Description);
                    break;

                case ConstantsRepo.SORT_APP_BY_DESCRIPTION_DESC:
                    list = list.OrderByDescending(c => c.Description);
                    break;

                case ConstantsRepo.SORT_APP_BY_URL_ASCE:
                    list = list.OrderBy(c => c.URL);
                    break;

                case ConstantsRepo.SORT_APP_BY_URL_DESC:
                    list = list.OrderByDescending(c => c.URL);
                    break;



                default:
                    list = list.OrderBy(c => c.ApplicationName);
                    break;
            }
            return list;
        }

        public ApplicationIndexVM GetApplicationList(string sortOrder, string currentFilter, string searchString, int? page)
        {
            try
            {
                IEnumerable<ApplicationListVM> applicationList = _context.Application
                                                .Select(c => new ApplicationListVM
                                                {
                                                    ApplicationName = c.ApplicationName,
                                                    ReferenceID = c.ReferenceID,
                                                    Description = c.Description,
                                                    URL = c.URL,
                                                    StatusName = c.Status.StatusName,
                                                    ClientName = c.Client.ClientName,
                                                });

                page = searchString == null ? page : 1;
                searchString = searchString ?? currentFilter;
                int pageNumber = (page ?? 1);
                ApplicationIndexVM model = new ApplicationIndexVM
                {
                    Applications = Sort(applicationList, sortOrder, searchString).ToPagedList(pageNumber, ConstantsRepo.PAGE_SIZE),
                    CurrentFilter = searchString,
                    CurrentSort = sortOrder,
                    ApplicationSort = sortOrder == ConstantsRepo.SORT_APP_BY_NAME_DESC ? ConstantsRepo.SORT_APP_BY_NAME_ASCE : ConstantsRepo.SORT_APP_BY_NAME_DESC,
                    StatusSort = sortOrder == ConstantsRepo.SORT_STATUS_BY_NAME_DESC ? ConstantsRepo.SORT_STATUS_BY_NAME_ASCE : ConstantsRepo.SORT_STATUS_BY_NAME_DESC,
                    ClientSort = sortOrder == ConstantsRepo.SORT_APP_BY_CLIENT_DESC ? ConstantsRepo.SORT_APP_BY_CLIENT_ASCE : ConstantsRepo.SORT_APP_BY_CLIENT_DESC,
                    DescriptionSort = sortOrder == ConstantsRepo.SORT_APP_BY_DESCRIPTION_DESC ? ConstantsRepo.SORT_APP_BY_DESCRIPTION_ASCE : ConstantsRepo.SORT_APP_BY_DESCRIPTION_DESC,
                    URLSort = sortOrder == ConstantsRepo.SORT_APP_BY_URL_DESC ? ConstantsRepo.SORT_APP_BY_URL_ASCE : ConstantsRepo.SORT_APP_BY_URL_DESC,
                };
                return model;
            }
            catch (Exception)
            {
                return null;
            }
        }


        public IEnumerable<ApplicationServerVM> GetServerList()
        {
            var apps = _context.Server.Select(a => new ApplicationServerVM
            {
                ServerName = a.ServerName,
                ReferenceID = a.ReferenceID,
                Location = a.DataCenterLocation.Location,
                Description = a.Description,
                Status = a.Status.StatusName,

            });

            return apps;
        }


        public ApplicationDetailVM GetDetailApplication(string referenceID)
        {
            Application application = _context.Application
                            .Where(a => a.ReferenceID == referenceID).FirstOrDefault();


            IEnumerable<Server> allApplicationServers = application.Servers;
            IEnumerable<ApplicationServerVM> applicationServer = allApplicationServers
                //.GroupBy(n => n.ServerName)
                //.Select(t => t.OrderBy(i => i.ServerName))
                .Select(
                    t => new ApplicationServerVM()
                    {
                        ReferenceID = t.ReferenceID,
                        ServerName = t.ServerName,
                        Location = t.DataCenterLocation.Location,
                        ServerType = t.ServerName,
                        Status = t.Status.StatusName,

                    });
                //.GroupBy(n => n.ServerName)
                //.Select(t => t.OrderByDescending(i => i.ServerName).FirstOrDefault());

            IEnumerable<UserDetail> allApplicationUsers = application.UserDetails;
            IEnumerable<ApplicationUsersVM> applicationUser = allApplicationUsers
                //.GroupBy(n => n.ClientID)
                //.Select(t => t.OrderBy(i => i.FirstName))
                .Select(
                    t => new ApplicationUsersVM()
                    {
                        FirstName = t.FirstName,
                        LastName = t.LastName,
                        RoleName = t.BusinessTitle,
                        Email = t.User.Email,
                        StatusID = t.Status.StatusID,
                        BusinessPhone = t.BusinessPhone,
                        HomePhone = t.HomePhone,
                        MobilePhone = t.MobilePhone,
                        ReferenceID = t.ReferenceID,
                        ClientReferenceID = t.ReferenceID,
                        BusinessTitle = t.BusinessTitle

                    });
                //.GroupBy(n => n.RoleName)
                //.Select(t => t.OrderByDescending(i => i.ClientReferenceID).FirstOrDefault());

            IEnumerable<Notification> allApplicationNotifications = application.Notifications;
            IEnumerable<ApplicationNotificationsVM> applicationNotifications = allApplicationNotifications

                .Select(
                    t => new ApplicationNotificationsVM()
                    {
                        ReferenceID = t.ReferenceID,
                        Description = t.NotificationDescription,
                        Status = t.Status.StatusName,
                        IncidentNumber = t.IncidentNumber,




                    });
  

            ApplicationDetailVM model = new ApplicationDetailVM
            {
                ApplicationName = application.ApplicationName,
                ReferenceID = application.ReferenceID,
                Description = application.Description,
                URL = application.URL,
                Status = application.Status.StatusName,
                Client = application.Client.ClientName,
                StatusID = application.Status.StatusID,
                ClientID = application.Client.ClientID,
                Servers = applicationServer,
                Users = applicationUser,
                Notifications = applicationNotifications
            };
            return model;
        }


        public IEnumerable<ApplicationListVM> GetApplicationList()
        {
            IEnumerable<ApplicationListVM> applicationList = _context.Application
                                                .Select(c => new ApplicationListVM
                                                {
                                                    ApplicationName = c.ApplicationName,
                                                    ReferenceID = c.ReferenceID,
                                                    Description = c.Description,
                                                    URL = c.URL,
                                                    StatusName = c.Status.StatusName,
                                                    ClientName = c.Client.ClientName,

                                                });
            return applicationList;
        }

        public SelectList GetStatusList()
        {
            IEnumerable<SelectListItem> statusList = _context.Status
                                    .Where(a => a.StatusType.StatusTypeName == APP_STATUS_TYPE_NAME)
                                    .Select(sv => new SelectListItem()
                                    {
                                        Value = sv.StatusID.ToString(),
                                        Text = sv.StatusName
                                    });

            return new SelectList(statusList, "Value", "Text");
        }

        public SelectList GetClientList()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            IEnumerable<SelectListItem> clientList = _context.Client
                    .Select(app =>
                                new SelectListItem
                                {
                                    Value = app.ClientID.ToString(),
                                    Text = app.ClientName
                                });

            return new SelectList(clientList, "Value", "Text");
        }


        public bool AddApplication(ApplicationVM application, out string msg)
        {
            Application a = _context.Application.Where(e => e.ApplicationName == application.ApplicationName)
                            .FirstOrDefault();
            var clientID = _context.Client.Where(c => c.ReferenceID == application.ClientRefID)
                                .Select(client => client.ClientID).FirstOrDefault();
            if (a != null)
            {
                msg = "Application name already exist.";
                return false;
            }

         

            try
            {
                Application newApplication = new Application();
                newApplication.ApplicationName = application.ApplicationName;
                newApplication.StatusID = application.StatusID;
                newApplication.ClientID = clientID;
                newApplication.ReferenceID = application.ReferenceID;
                newApplication.Description = application.Description;
                newApplication.URL = application.URL;

                newApplication.ReferenceID = Guid.NewGuid().ToString();

                if (application.ServerReferenceIDs == null)
                {
                    application.ServerReferenceIDs = new string[0];
                }

                var servers = _context.Server.Where(b => application.ServerReferenceIDs.Contains(b.ReferenceID));
                newApplication.Servers = servers.ToList();

                _context.Application.Add(newApplication);
                _context.SaveChanges();
                msg = "Application successfully added";
                return true;
            }
            catch
            {
                msg = "Failed to add application.";
                return false;
            }
        }

        public ApplicationVM GetApplication(string referenceID)
        {
            ApplicationVM application = _context.Application
                            .Where(a => a.ReferenceID == referenceID)
                            .Select(b => new ApplicationVM
                            {
                                ApplicationName = b.ApplicationName,
                                ReferenceID = b.ReferenceID,
                                Description = b.Description,
                                URL = b.URL,
                                StatusName = b.Status.StatusName,
                                ClientName = b.Client.ClientName,
                                StatusID = b.StatusID,
                                ClientRefID = b.Client.ReferenceID,
                            }).FirstOrDefault();
            return application;
        }

        public ApplicationVM GetDeleteApplication(string referenceID)
        {
            ApplicationVM application = _context.Application
                            .Where(a => a.ReferenceID == referenceID)
                            .Select(b => new ApplicationVM
                            {
                                ApplicationName = b.ApplicationName,
                                ReferenceID = b.ReferenceID,
                                Description = b.Description,
                                URL = b.URL,
                                StatusName = b.Status.StatusName,
                                ClientName = b.Client.ClientName,
                                StatusID = b.StatusID,
                                ClientRefID = b.Client.ReferenceID,
                                
                            }).FirstOrDefault();
            return application;
        }

        public bool EditApplication(ApplicationVM application, out string msg)
        {
            Application a = _context.Application.Where(b => b.ApplicationName == application.ApplicationName).FirstOrDefault();
            var clientID = _context.Client.Where(c => c.ReferenceID == application.ClientRefID)
                               .Select(client => client.ClientID).FirstOrDefault();
            //if (a != null)
            //{
            //    msg = "Application name already exist.";
            //    return false;
            //}
            try
            {
                Application applicationUpdated = _context.Application
                                        .Where(d => d.ReferenceID == application.ReferenceID)
                                        .FirstOrDefault();
                applicationUpdated.ApplicationName = application.ApplicationName;
                applicationUpdated.ReferenceID = application.ReferenceID;
                applicationUpdated.StatusID = application.StatusID;
                applicationUpdated.Description = application.Description;
                applicationUpdated.URL = application.URL;
                applicationUpdated.ClientID = clientID;

                if (application.ServerReferenceIDs == null)
                {
                    application.ServerReferenceIDs = new string[0];
                }

                var servers = _context.Server.Where(b => application.ServerReferenceIDs.Contains(b.ReferenceID));

                applicationUpdated.Servers.Clear();
                applicationUpdated.Servers = servers.ToList();

                _context.SaveChanges();
                msg = "Application information succesfully updated.";
                return true;
            }
            catch
            {
                msg = "Failed to update application.";
                return false;
            }
        }

        public bool DeleteApplication(string referenceID, out string msg)
        {
            // check if applications exists
            Application applicationToBeDeleted = _context.Application
                                    .Where(a => a.ReferenceID == referenceID)
                                    .FirstOrDefault();
            // check applications associated with Server
            var applicationServers = _context.Server
                                       .Where(a => a.ReferenceID == referenceID)
                                       .FirstOrDefault();

            // check applications associated with Client
            var applicationUsers = _context.UserDetail
                                       .Where(a => a.ReferenceID == referenceID)
                                       .FirstOrDefault();

            var applicationNotifications = _context.Notification
                                     .Where(a => a.ReferenceID == referenceID)
                                     .FirstOrDefault();
            if (applicationToBeDeleted == null)
            {
                msg = "application could not be deleted.";
                return false;
            }
            if (applicationServers != null)
            {
                msg = "Application has server(s) associated, cannot be deleted";
                return false;
            }

            if (applicationUsers != null)
            {
                msg = "Application has a users associated, cannot be deleted";
                return false;
            }

            if (applicationNotifications != null)
            {
                msg = "Application has a Notifications associated, cannot be deleted";
                return false;
            }

            try
            {
                _context.Application.Remove(applicationToBeDeleted);
                _context.SaveChanges();
                msg = "Application Successfully Deleted";
                return true;
            }
            catch
            {
                msg = "Failed to update application.";
                return false;
            }

        }
    }
}
    

