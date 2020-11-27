using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Ext.Net.Examples
{
    public class ExtNetVersion
    {
        private static System.Version ENRawVersion;

        private static string extNetVersion = null;

        /// <summary>
        /// Ext.NET version in Major.Minor.Revision format.
        /// </summary>
        public static string MajorMinorRevision
        {
            get
            {
                if (extNetVersion == null)
                {
                    if (ENRawVersion == null)
                    {
                        ENRawVersion = Assembly.GetAssembly(typeof(Component)).GetName().Version;
                    }

                    extNetVersion = ENRawVersion.Major + "." + ENRawVersion.Minor + "." + ENRawVersion.Revision;
                }

                return extNetVersion;
            }
        }

        private static string extNetVersionDisplay = null;

        /// <summary>
        /// Simplified version display, suppressing revision number when it is 0.
        /// </summary>
        public static string DisplayVersion
        {
            get
            {
                if (extNetVersionDisplay == null)
                {
                    if (ENRawVersion == null)
                    {
                        ENRawVersion = Assembly.GetAssembly(typeof(Component)).GetName().Version;
                    }

                    extNetVersionDisplay = "" + ENRawVersion.Major + "." + ENRawVersion.Minor;

                    if (ENRawVersion.Revision != 0)
                    {
                        extNetVersionDisplay += "." + ENRawVersion.Minor + "." + ENRawVersion.Revision;
                    }
                }

                return extNetVersionDisplay;
            }
        }

        private static string extNetVersionForCacheBuster = null;

        /// <summary>
        /// For cache buster, use in Major.Minor.Revision.Build number components of the version.
        /// </summary>
        public static string CacheBuster
        {
            get
            {
                if (extNetVersionForCacheBuster == null)
                {
                    if (ENRawVersion == null)
                    {
                        ENRawVersion = Assembly.GetAssembly(typeof(Component)).GetName().Version;
                    }

                    extNetVersionForCacheBuster = ENRawVersion.Major + "." + ENRawVersion.Minor + "." + ENRawVersion.Revision + "." + ENRawVersion.Build;
                }

                return extNetVersionForCacheBuster;
            }
        }
    }
}
