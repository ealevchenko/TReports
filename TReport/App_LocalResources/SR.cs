using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace TReport.App_LocalResources
{
    public static class SR
    {
        static ResourceManager rEnergy;
        static ResourceManager rResource;

        static SR() {
            rEnergy = new ResourceManager(typeof(EnergyResource));
            rResource = new ResourceManager(typeof(Resources));
        }

        public static string GetResources(this string key)
        {
            return rResource.GetString(key, CultureInfo.CurrentCulture);
        }

        public static string GetREnergy(this string key)
        {
            return rEnergy.GetString(key, CultureInfo.CurrentCulture);
        }

    }
}
