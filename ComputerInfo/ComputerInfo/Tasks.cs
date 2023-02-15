using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace ComputerInfo
{
    class Tasks
    {
        const string WELCOME = "Welcome to ComputerInfo v0.01\n" +
                               "This application will print out info of your computer.\n" +
                               "Please type the number of task you need to execute.";

        const string MENU =  " - 1. All info (advanced users)\n" +
                             " - 2. Basic Info (normal users)\n" +
                             " - 3. Not available yet\n" +
                             " - Q/q Close the application";

        const string WIN_OPERATING_SYS = "select * from Win32_OperatingSystem";
        //const string WIN_PROCESSOR = "select * from Win32_Processor";

        public Tasks() { }
        public void Execute()
        {
            // Processor
            //ManagementObjectSearcher searcherProc = new(WIN_PROCESSOR);
            //ManagementObjectCollection collectionProc = searcherProc.Get();

            //OS
            ManagementObjectSearcher searcherOS = new(WIN_OPERATING_SYS);
            ManagementObjectCollection collectionOS = searcherOS.Get();

            Console.WriteLine("{0}\n{1}", WELCOME, MENU);
            char choice = Convert.ToChar(Console.ReadLine());

            switch (choice)
            {
                case '1':
                    ShowAllInfoComputer(collectionOS);
                    break;
                case '2':
                    ShowBasicInfoComputer(collectionOS);
                    break;
                case 'q':
                case 'Q':
                    return;
                default:
                    Console.WriteLine("Choice invalid");
                    break;
            }
        }

        void ShowBasicInfoComputer(ManagementObjectCollection collectionOS)
        {
            foreach (ManagementObject obj in collectionOS)
            {
                //ulong freeMemoryKB = (ulong)obj["FreePhysicalMemory"];
                //double freeMemoryGB = (double)freeMemoryKB / 1024 / 1024;

                //Console.WriteLine("{0:F2}",freeMemoryGB);

                Console.WriteLine($"Nome OS: {obj["Caption"]}\n" +
                                  $"Nome computer: {obj["CSName"]}\n" +
                                  $"Produttore Computer: {obj["Manufacturer"]}\n" +
                                  $"Architettura OS: {obj["OSArchitecture"]}\n" +
                                  $"Numero di utenti: {obj["NumberOfUsers"]}\n" +
                                  $"Utente registrato: {obj["NumberOfUsers"]}\n" +
                                  $"Numero Seriale: {obj["SerialNumber"]}\n" +
                                  $"Directory di sistema: {obj["SystemDirectory"]}\n" +
                                  $"Unità di sistema: {obj["SystemDrive"]}\n" +
                                  $"Versione: {obj["Version"]}\n");
            }
        }

        void ShowAllInfoComputer(ManagementObjectCollection collection)
        {
            foreach (ManagementObject obj in collection)
            {
                PropertyDataCollection props = obj.Properties;
                foreach (PropertyData prop in props)
                {
                    Console.WriteLine("{0}: {1}", prop.Name, prop.Value);
                }
            }
        }
    }
}
