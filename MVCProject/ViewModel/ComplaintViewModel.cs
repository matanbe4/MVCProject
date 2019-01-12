using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCProject.Models;

namespace MVCProject.ViewModel
{
    //A View Model for Reports.
    public class ComplaintViewModel
    {
        public List<Complaint> complaints { get; set; }
    }
}