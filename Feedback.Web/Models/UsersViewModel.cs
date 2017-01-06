//using Feedback.Web.Infrastructure.Validators;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Feedback.Web.Models
{
    public class UsersViewModel
    {
        public string username { get; set; }
        public string subject { get; set; }
        public string email { get; set; }
        public string feedback { get; set; }
    }
}



