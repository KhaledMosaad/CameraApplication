using CameraProject.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Management;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CameraApplication
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string processorid = GetProcessorId();
            string AccountName = GetAccountName();
            Business bs = new Business();
            Person person;
            if (bs.SelectPersonID(processorid).Rows.Count == 0)
            {
                person = Person.Instance;
                person.PersonName = AccountName;
                person.ProcessID = processorid;
                bs.AddPerson(AccountName, processorid);
                DataTable dt = new DataTable();
                dt = bs.SelectPersonID(processorid);
                person.PersonID = (int)dt.Rows[0][0];
            }
            else
            {
                person = Person.Instance;
                person.PersonName = AccountName;
                person.ProcessID = processorid;
                DataTable dt = new DataTable();
                dt = bs.SelectPersonID(processorid);
                person.PersonID = (int)dt.Rows[0][0];
            }
            Application.Run(new MainForm());
        }
        public static String GetProcessorId()
        {
            ManagementClass mc = new ManagementClass("win32_processor");
            ManagementObjectCollection moc = mc.GetInstances();
            String Id = String.Empty;
            foreach (ManagementObject mo in moc)
            {
                Id = mo.Properties["processorID"].Value.ToString();
                break;
            }
            return Id;
        }
        /// <summary>
        /// Function Give you The Account Name this device work on it
        /// </summary>
        /// <returns> Acount Name as string </returns>
        public static string GetAccountName()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_UserAccount");
            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return wmi.GetPropertyValue("Name").ToString();
                }
                catch { }
            }
            return "Unknown";
        }
    }
}
