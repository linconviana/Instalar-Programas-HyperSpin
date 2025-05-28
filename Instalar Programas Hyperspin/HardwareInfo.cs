using System;
using System.Management;

namespace Instalar_Programas_Hyperspin
{
    public static class HardwareInfo
    {
        /// Retrieving System MAC Address.
        public static string GetMACAddress()
        {
            try
            {
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc = mc.GetInstances();
                string MACAddress = String.Empty;
                foreach (ManagementObject mo in moc)
                {
                    if (MACAddress == String.Empty)
                    {
                        if ((bool)mo["IPEnabled"] == true) MACAddress = mo["MacAddress"].ToString();
                    }
                    mo.Dispose();
                }

                /// :: MACAddress = MACAddress.Replace(":", "");
                return MACAddress;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// Retrieving Motherboard Manufacturer.
        public static string GetBoardMaker()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BaseBoard");

                foreach (ManagementObject wmi in searcher.Get())
                {
                    try
                    {
                        return wmi.GetPropertyValue("Manufacturer").ToString();
                    }
                    catch { }
                }
                return "Board Maker: Unknown";
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// Retrieving Current Language.
        public static string GetOSInformation()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
                foreach (ManagementObject wmi in searcher.Get())
                {
                    try
                    {
                        return ((string)wmi["Caption"]).Trim() + ", " + (string)wmi["Version"] + ", " + (string)wmi["OSArchitecture"];
                    }
                    catch { }
                }
                return "BIOS Maker: Unknown";
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// Retrieving Processor Information.
        public static String GetProcessorInformation()
        {
            try
            {
                ManagementClass mc = new ManagementClass("win32_processor");
                ManagementObjectCollection moc = mc.GetInstances();
                String info = String.Empty;
                foreach (ManagementObject mo in moc)
                {
                    string name = (string)mo["Name"];
                    name = name.Replace("(TM)", "™").Replace("(tm)", "™").Replace("(R)", "®").Replace("(r)", "®").Replace("(C)", "©").Replace("(c)", "©").Replace("    ", " ").Replace("  ", " ");

                    info = name + ", " + (string)mo["Caption"] + ", " + (string)mo["SocketDesignation"];
                    //mo.Properties["Name"].Value.ToString();
                    //break;
                }
                return info;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// Retrieving Computer Name.
        public static String GetComputerName()
        {
            try
            {
                ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
                ManagementObjectCollection moc = mc.GetInstances();
                String info = String.Empty;
                foreach (ManagementObject mo in moc)
                {
                    info = (string)mo["Name"];
                    //mo.Properties["Name"].Value.ToString();
                    //break;
                }
                return info;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
