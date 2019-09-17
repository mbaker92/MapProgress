using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MapProgress
{
    class GeoJSON
    {
        public string StIDSecID { get; set; }
        public string StreetName { get; set; }
        public string BegLocatio { get; set; }
        public string EndLocatio { get; set; }
        public string coordinates { get; set; }
        public List<string> Coor;

        public GeoJSON()
        {
            Coor = new List<string>();
            StIDSecID = StreetName = BegLocatio = EndLocatio = coordinates = "";

        }
        public void ConvertCoordinates()
        {

            // Replace all Non-useful characters with nothing
            string temp = coordinates.Replace("[", "");
            temp = temp.Replace("]", "");
            temp = temp.Replace(" ", "");
            temp = temp.Replace("\r", "");
            temp = temp.Replace("\n", "");

            // Split Coordinates into separate coordinates
            List<string> TempList = new List<string>(temp.Split(','));

            for (int i = 0; i < TempList.Count; i++)
            {
                if (TempList[i] != "0.0")
                {
                    Coor.Add(TempList[i]);
                }
            }
        }
    }
    }
