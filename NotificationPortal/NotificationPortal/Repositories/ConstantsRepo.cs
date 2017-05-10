using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotificationPortal.Repositories
{
    public static class ConstantsRepo
    {
        public const int PAGE_SIZE = 10;
        public const string SORT_CLIENT_BY_NAME_ASCE = "client_name_asce";
        public const string SORT_CLIENT_BY_NAME_DESC = "client_name_desc";

        public const string SORT_LEVEL_OF_IMPACT_ASCE = "level_of_impact_asce";
        public const string SORT_LEVEL_OF_IMPACT_DESC = "level_of_impact_desc";

        public const string SORT_NOTIFICATION_BY_HEADING_ASCE = "notification_heading_asce";
        public const string SORT_NOTIFICATION_BY_HEADING_DESC = "notification_heading_desc";

        public const string SORT_NOTIFICATION_BY_TYPE_ASCE = "notification_type_asce";
        public const string SORT_NOTIFICATION_BY_TYPE_DESC = "notification_type_desc";

        public const string SORT_STATUS_BY_NAME_ASCE = "status_name_asce";
        public const string SORT_STATUS_BY_NAME_DESC = "status_name_desc";

        public const string SORT_APP_BY_NAME_ASCE = "application_name_asce";
        public const string SORT_APP_BY_NAME_DESC = "application_name_desc";

        public const string SORT_APP_BY_URL_ASCE = "application_url_asce";
        public const string SORT_APP_BY_URL_DESC = "application_url_desc";

        public const string SORT_APP_BY_CLIENT_ASCE = "application_client_asce";
        public const string SORT_APP_BY_CLIENT_DESC = "application_client_desc";

        public const string SORT_APP_BY_DESCRIPTION_ASCE = "application_description_asce";
        public const string SORT_APP_BY_DESCRIPTION_DESC = "application_description_desc";

        public const string SORT_NOTIFICATION_BY_PRIORITY_ASCE = "priority_value_asce";
        public const string SORT_NOTIFICATION_BY_PRIORITY_DESC = "priority_value_desc";

        public const string SORT_SERVER_BY_NAME_ASCE = "server_name_asce";
        public const string SORT_SERVER_BY_NAME_DESC = "server_name_desc";

        public const string SORT_SERVER_BY_DESCRIPTION_ASCE = "server_description_asce";
        public const string SORT_SERVER_BY_DESCRIPTION_DESC = "server_description_desc";

        public const string SORT_SERVER_BY_STATUS_NAME_ASCE = "server_status_name_asce";
        public const string SORT_SERVER_BY_STATUS_NAME_DESC = "server_status_name_desc";

        public const string SORT_SERVER_BY_LOCATION_NAME_ASCE = "server_location_name_asce";
        public const string SORT_SERVER_BY_LOCATION_NAME_DESC = "server_location_name_desc";

        // User Repository Constants
        public const string SORT_FIRST_NAME_BY_ASCE = "first_name_asce";
        public const string SORT_FIRST_NAME_BY_DESC = "first_name_desc";

        public const string SORT_LAST_NAME_BY_ASCE = "last_name_asce";
        public const string SORT_LAST_NAME_BY_DESC = "last_name_desc";

        public const string SORT_ROLE_NAME_BY_ASCE = "role_name_asce";
        public const string SORT_ROLE_NAME_BY_DESC = "role_name_desc";

        public const string SORT_EMAIL_BY_ASCE = "email_asce";
        public const string SORT_EMAIL_BY_DESC = "email_desc";
    }
}
