using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMauiApp.Models
{
    public class MenuModel
    {
        public string Text { get; set; }
        public string Url { get; set; }
        public object Icon { get; set; }
        public List<MenuModel> Items { get; set; }
    }
}
