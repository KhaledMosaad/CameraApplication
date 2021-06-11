using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraProject.BusinessLayer
{
    public class Person
    {
       
        private string personName;
        private string processorID;
        private static int personID;
        private static Person instance=null;
        public string PersonName { get { return personName; } set { personName = value; } }
        public string ProcessID { get { return processorID; } set { processorID = value; } }
        public int PersonID{ get { return personID; } set { personID = value; } }
        public static Person Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Person();
                }
                return instance;
            }
        }
        private Person()
        {
        }
        
    }
}
