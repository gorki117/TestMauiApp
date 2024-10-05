using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.FontIcons;
using TestMauiApp.Models;

namespace TestMauiApp.Services
{
    public class MenuService
    {
        public List<MenuModel> MenuData { get; set; }
        public void GenerateMenuData()
        {
            MenuData = new List<MenuModel>()
        {
            new MenuModel()
            {
                Text = "Fő oldal",
                Url = "/",
                Icon =  FontIcon.Home
            },
            new MenuModel()
            {
                Text = "Akció",
                 Url = "/product",
                Icon =  FontIcon.FileReport
            },
                new MenuModel()
                {
                Text = "Kupon",
                Url = "/couppon",
                Icon =  FontIcon.AggregateFields,
                },
                new MenuModel()
                {
                Text = "Patika",
                Url = "/patika",
                Icon =  FontIcon.MapMarker
                }
        };

        }
    }
}
