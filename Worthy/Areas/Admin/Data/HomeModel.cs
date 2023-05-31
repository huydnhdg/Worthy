using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Worthy.Areas.Admin.Data
{
    public class HomeModel
    {

        public int Customer { get; set; }
        public int Code { get; set; }

        public List<Homepage> Homepages { get; set; }
    }
    public class Homepage
    {

    }
}