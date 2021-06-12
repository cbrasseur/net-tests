using System;
using System.Collections.Generic;
using System.Text;

namespace unit_test
{
    public class MenuModel
    {
        public int Id { get; set; }
        public string LinkText{ get; set; }
        public string ActionName { get; set; }
        public string Controller { get; set; }
        public bool IsPublic { get; set; }
    }
}
