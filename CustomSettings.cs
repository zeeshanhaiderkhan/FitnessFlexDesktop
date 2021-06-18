using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FitnessFlex
{
    static class CustomSettings
    {
        private static string fileName = "AppSettings.xml";
        private static XmlDocument file = new XmlDocument();
        //private static string defaultTheme;


        public static bool LoadFile()
        {
            try
            {
                file.Load(fileName);
                return true;
            }
            catch (System.IO.FileNotFoundException)
            {
                return false;
            }
        }



        public static Dictionary<string, string> GetPackages()
        {
            Dictionary<string, string> packages = new Dictionary<string, string>();
            XmlNodeList list = file.SelectNodes("AppSettings/memberform/memberpackages//memberpackage");
            foreach (XmlNode node in list)
            {
                packages.Add(node.InnerText, node.Attributes[0].Value);
            }
            /* foreach(XmlNode n in file.ChildNodes)
             {

                 foreach (XmlNode n2 in n.ChildNodes)
                 {



                    foreach(XmlNode n3 in n2.ChildNodes)
                     {
                        foreach(XmlNode n4 in n3.ChildNodes)
                         {
                             packages.Add(n4.InnerText, n4.Attributes[0].Value);
                         }
                         return packages;
                     }


                 }

             }*/
            return packages;
        }

        public static Dictionary<string, string> GetFeePlans()
        {
            Dictionary<string, string> packages = new Dictionary<string, string>();
            XmlNodeList list = file.SelectNodes("AppSettings/feesummaryform/feeplans//feeplan");
            foreach (XmlNode node in list)
            {
                packages.Add(node.InnerText, node.Attributes[0].Value);
            }
            return packages;
        }
        public static string GetAdmissionFee()
        {
            return file.SelectSingleNode("AppSettings/admission/admissionfees//admissionfee").InnerText;
        }
      /*  public static string GetAddress()
        {
            return  file.SelectSingleNode("AppSettings/invoice/gymdetails//address").InnerText;
        }*/
        public static void GetDefaultTheme()
        {

        }
        public static void GetDefaultDataView()
        {

        }
        public static void GetVoucherTemplate()
        {

        }
        public static void GetPersonalTrainerFee()
        {

        }


    }
}
