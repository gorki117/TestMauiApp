using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Blazor.Components;
using Telerik.Pivot.Core.Totals;
using TestMauiApp.Models;

namespace TestMauiApp.Services
{
    public class MarkerService
    {
        public string[] Subdomains { get;  } = new string[] { "a", "b", "c" };
        public string UrlTemplate { get; } = "https://#= subdomain #.tile.openstreetmap.org/#= zoom #/#= x #/#= y #.png";
        public string Attribution { get;} = "&copy; <a href='https://osm.org/copyright'>OpenStreetMap contributors</a>";
        public double[] Center { get; set; } = new double[] { 47.464207, 19.043320 };
        public double Zoom { get; set; } = 10;  
        public string SelectedPoint { get; set; }

        public string ActalLocation { get; set; }

        public List<MarkerModel> MarkerData1 { get; set; }


        public MarkerService() => MarkerData1 = new List<MarkerModel>()
    {
        new MarkerModel()
        {
            LatLng = new double[] { 47.4683304, 19.0486865},
            Title = "Nádor patika"
        },

        new MarkerModel()
        {
            LatLng = new double[] { 47.464207, 19.043320 },
            Title = "PharmaCloud"
        },
         new MarkerModel()
        {
            LatLng = new double[] { 47.4982212, 19.0563805  },
            Title = "HungaroPhrarma"
        }
        };

        public  void OnMarkerClick(MapMarkerClickEventArgs args)
        {
            var dataItem = args.DataItem as MarkerModel;
            var eventArgs = args.EventArgs as MouseEventArgs;
            Center = dataItem.LatLng;
            Zoom = 18;
            SelectedPoint = dataItem.Title;
            //LogToConsole(
            //    $"marker click: title = {dataItem.Title}, location = [{string.Join(",", dataItem.LatLng)}]," +
            //    $"clientX = {eventArgs.ClientX}, clientY = {eventArgs.ClientY}");
        }
        public async Task<string> GetCachedLocation()
        {
            try
            {
                Location location = await Geolocation.Default.GetLastKnownLocationAsync();

                if (location != null)
                    ActalLocation = $"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}";
                return ActalLocation;
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                ActalLocation= fnsEx.Message;
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
                ActalLocation = fneEx.Message;
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
                ActalLocation = pEx.Message;
            }
            catch (Exception ex)
            {
                // Unable to get location
                ActalLocation = ex.Message;
            }

            return "None";
        }
    }
}
