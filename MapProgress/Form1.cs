/* Author: Matthew Baker
 * Project: Map Progress
 * Description: Will take a GeoJSON file that contains sections of road
 *              that need to be rated by someone in the field and take a CSV file that
 *              contains the ratings. It then outputs a map that shows sections that are
 *              currently done.
 * TODO: Check if CSV has valid data, check if GeoJSON has valid data, check if file types are correct,
 *       check if program has both files before creating lines on map, organize elements on screen better
 */

using GMap.NET;
using GMap.NET.WindowsForms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MapProgress
{
    public partial class Form1 : Form
    {
        private List<GeoJSON> Roads = new List<GeoJSON>();
        private List<InspectedFileInfo> CompletedRoads = new List<InspectedFileInfo>();
        
        public Form1()
        {
            InitializeComponent();

            // Set Google Maps as the map layer
            gMapControl1.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;

            // Remove Red Cross in Center of Map Control and set the Left Mouse Button for panning map.
            gMapControl1.ShowCenter = false;
            gMapControl1.DragButton = MouseButtons.Left;
        }
        // Gets the GeoJSON information
        private void KMLFile_Click(object sender, EventArgs e)
        {
            // Show File Dialog for GeoJSON file
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Clear Roads in case there is previous data from another file.
                Roads.Clear();

                // copy contents from inputfile into a string
                System.IO.StreamReader file = new System.IO.StreamReader(openFileDialog1.FileName);
                string content = file.ReadToEnd();
                file.Close();

                // Deserialize the string and place the information into the correct variable
                dynamic deserialized = JsonConvert.DeserializeObject(content);
                foreach (var item in deserialized.features)
                {
                    Roads.Add(new GeoJSON()
                    {

                        // Info from the GeoJson file under the features type. Add this info to the Roads list

                        StIDSecID = item.properties.StIDSecID,
                        StreetName = item.properties.StreetName,
                        BegLocatio = item.properties.BegLocatio,
                        EndLocatio = item.properties.EndLocatio,
                        coordinates = item.geometry.coordinates.ToString()

                    });
                }
                //iterate though Roads and call ConvertCoordinates to remove any chars we dont need.
                foreach (var r in Roads)
                {

                    r.ConvertCoordinates();
                }
            }
        }

        // Open CSV file and get the StIDSecID of completed samples.
        private void InspectedFile_Click(object sender, EventArgs e)
        {
            // Show File Browser for CSV file
            if(openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                // Clear CompletedRoads in case there is info from previous file
                CompletedRoads.Clear();

               // Open the CSV
                using (var reader = new StreamReader(openFileDialog2.FileName))
                {
                    // Read the CSV
                    using (var csv = new CsvHelper.CsvReader(reader))
                    {
                        // Store the information we want in records
                        var records = csv.GetRecords<InspectedFileInfo>();
                        
                        // Iterate through records and add them to CompletedRoads variable.
                        foreach (var t in records)
                        {
                            CompletedRoads.Add(t);
                        }
                    }                   
                }
            }
        }

        private void Check_Click(object sender, EventArgs e)
        {
            // Declare a new overlay that will contain the all sections of road
            GMapOverlay routes = new GMapOverlay("Routes");

            // Iterate through the GeoJSON roads
            foreach (var t in Roads) {
                
                // Declare points variable that will store the points displayed for the current Road.
                List<PointLatLng> points = new List<PointLatLng>();

                /* Get the Coordinates from the GeoJSON object for current road section and add them to points variable.
                 * Lat and Long for each point are stored in pairs of elements in the array. 
                 * First element is Lat and Second element is Long */
                for (int i = 0; i < t.Coor.Count - 1; i = i + 2)
                {
                    points.Add(new PointLatLng(double.Parse(t.Coor[i+1]),double.Parse( t.Coor[i])));
                }

                // create the route variable with the road's points and the StIDSecID as the identifier for the road
                GMapRoute route = new GMapRoute(points, t.StIDSecID);

                // Iterate through the completed roads from the CSV file
                foreach(var y in CompletedRoads)
                {
                    // If the StIDSecID match, then set the line on Map to Green to show Done. 
                    // Contains used in case there are spaces in CSV Output
                    if (y.StIDSecID.Contains(t.StIDSecID))
                    {
                        route.Stroke = new Pen(Color.Green, 2);
                        break;
                    }
                    else
                    {
                        // If not completed then color the line red to show not completed
                        route.Stroke = new Pen(Color.Red, 2);
                    }
                }
                // Add route to  the overlay
                routes.Routes.Add(route);
            }
            // Add overlay to Map control and change mapcontrol's position to show roads.
            gMapControl1.Overlays.Add(routes);
            gMapControl1.ZoomAndCenterRoutes("Routes");
        }

        private void ZoomIn_Click(object sender, EventArgs e)
        {
            // 18 is the Max zoom level
            if (gMapControl1.Zoom < 18) {
                // zoom in 1 zoom level
                gMapControl1.Zoom += 1;

            }
        }
        
        // Handles the Zoom Out "-" button on the map. 
        private void ZoomOut_Click(object sender, EventArgs e)
        {
            // 2 is the Min zoom level 
            if(gMapControl1.Zoom > 2)
            {
                // zoom out 1 zoom level
                gMapControl1.Zoom -= 1;
            }
        }
    }
}
