using System.Management;

namespace ComputerInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            var task = new Tasks();

            try
            {
                task.Execute();
                task = null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Closing application...");
            }

            //ManagementObjectSearcher searcher = new("select * from Win32_OperatingSystem");
            //ManagementObjectCollection collection = searcher.Get();

            //foreach (ManagementObject info in collection) 
            //{
            //    Console.WriteLine("Name: {0}", info["Caption"]);
            //}
        }
    }
}