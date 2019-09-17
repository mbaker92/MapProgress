using GMap.NET;
using GMap.NET.WindowsForms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapProgress
{
    public partial class Form1 : Form
    {
        private List<GeoJSON> Roads = new List<GeoJSON>();
        private List<Color> colors = new List<Color>();
        private List<InspectedFileInfo> CompletedRoads = new List<InspectedFileInfo>();
        
        public Form1()
        {
            InitializeComponent();
            gMapControl1.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gMapControl1.ShowCenter = false;
            gMapControl1.DragButton = MouseButtons.Left;
        }

        private void KMLFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Console.WriteLine(openFileDialog1.FileName);
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
                foreach (var r in Roads)
                {

                    r.ConvertCoordinates();
                }
           //     for (int i = 0; i < R.SphereicalCoor.Count - 1; i = i + 2)
             //   {
               // }
            }
        }
        private void InitColors()
        {
            //  Colors.Add(Color.Red);
            colors.Add(Color.Blue);
            colors.Add(Color.Orange);
            colors.Add(Color.Yellow);
            colors.Add(Color.Indigo);
            colors.Add(Color.Violet);
            colors.Add(Color.Gray);
            colors.Add(Color.Cyan);
        }

        private void InspectedFile_Click(object sender, EventArgs e)
        {
            if(openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                using (var reader = new StreamReader(openFileDialog2.FileName))
                {
                    using (var csv = new CsvHelper.CsvReader(reader))
                    {
                        var records = csv.GetRecords<InspectedFileInfo>();
                        foreach (var t in records)
                        {
                            CompletedRoads.Add(t);
                            Console.Write(t.StIDSecID);
                        }
                    }
                    

                }
            }
     //       GMapOverlay routes = new GMapOverlay("routes");
       //     List<PointLatLng> points = new List<PointLatLng>();
         //   points.Add(new PointLatLng(48.866383, 2.323575));
        //    points.Add(new PointLatLng(48.863868, 2.321554));
          //  points.Add(new PointLatLng(48.861017, 2.330030));
        //    GMapRoute route = new GMapRoute(points, "A walk in the park");
          //  route.Stroke = new Pen(Color.Red, 3);
          //  routes.Routes.Add(route);
           // gMapControl1.Overlays.Add(routes);
        }

        private void Check_Click(object sender, EventArgs e)
        {
            GMapOverlay routes = new GMapOverlay("Routes");
            foreach (var t in Roads) {
                List<PointLatLng> points = new List<PointLatLng>();


                for (int i = 0; i < t.SphereicalCoor.Count - 1; i = i + 2)
                {
                    points.Add(new PointLatLng(double.Parse(t.SphereicalCoor[i+1]),double.Parse( t.SphereicalCoor[i])));

                }
                GMapRoute route = new GMapRoute(points, t.StIDSecID);
                foreach(var y in CompletedRoads)
                {
                    if (y.StIDSecID.Contains(t.StIDSecID))
                    {
                        route.Stroke = new Pen(Color.Green, 3);
                        break;
                    }
                    else
                    {
                        route.Stroke = new Pen(Color.Red, 3);
                    }
                }
                routes.Routes.Add(route);
                gMapControl1.Overlays.Add(routes);
            }
            gMapControl1.ZoomAndCenterRoutes("Routes");
        }

        private void ZoomIn_Click(object sender, EventArgs e)
        {
      //      gMapControl1.
        }
    }
}
