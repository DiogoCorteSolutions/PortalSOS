using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalSos.Infra.CrossCutting.Common.Helpers
{
    public class AlertHelper
    {
        public class Alert
        {
            public const string TempDataKey = "TempDataAlerts";

            public string AlertStyle { get; set; }
            public string Message { get; set; }
            public string Title { get; set; }
            public bool Dismissable { get; set; }
        }

        public static class AlertStyles
        {
            public const string Success = "success";
            public const string Information = "info";
            public const string Warning = "warning";
            public const string Danger = "error";

            public const string SuccessOne = "alert alert-success";
            public const string InformationOne = "alert alert-info";
            public const string WarningOne = "alert alert-warning";
            public const string DangerOne = "alert alert-danger";
        }
    }
}