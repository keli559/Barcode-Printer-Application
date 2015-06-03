using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections;

namespace ZebraBarPrintApp
{
    public class ServerConnection1
    {
        public string Driver = "";
        public string DriverName = "";
        public string ServerType = "";
        public string SchoolCode = "";
        public Hashtable Descript2DatasetsHash = new Hashtable();



        //public void ConnectToData()
        //{
        //    System.Data.Odbc.OdbcConnection conn =
        //    new System.Data.Odbc.OdbcConnection();
        //    // TODO: Modify the connection string and include any
        //    // additional required properties for your database.
        //    conn.ConnectionString = "DSN=MySQL_ODBC_hollins_test";
        //    try
        //    {
        //        conn.Open();
        //        Debug.WriteLine("Hooray!");
        //        // Process data here.
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Failed to connect to data source\n" + ex.Message);
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //}
        public void readOdinCfg()
        {
            
            string odinPath = "";
            odinPath = FindOdinPath();
            // for testing purpose,
            // odinPath should be 
            // "K:\\Schools\\Hollins\\20141015 for test"
            if (odinPath == "")
            {

            }
            else
            {

                string OdinCfgLocation = odinPath + "\\odin.cfg";

                // Display the file contents by using a foreach loop.
                try
                {
                    string[] lines = System.IO.File.ReadAllLines(@OdinCfgLocation);
                    bool passAreaDescriptions = false;
                    bool passAreaDatasets = false;
                    string[] AreaDatasetsVector = new string[10];
                    string[] AreaDescriptionsVector = new string[10];
                    foreach (string line in lines)
                    {
                        // Use a tab to indent each line of the file.
                        if (line.Contains("Driver=") & (!line.Contains("//Driver=")))
                        {
                            this.Driver = line.Split('=')[1];
                        }
                        else if (line.Contains("DriverName=") & (!line.Contains("//DriverName=")))
                        {
                            this.DriverName = line.Split('=')[1];
                        }
                        else if (line.Contains("ServerType=") & (!line.Contains("//ServerType=")))
                        {
                            this.ServerType = line.Split('=')[1];
                        }
                        else if (line.Contains("SchoolCode=") & (!line.Contains("//SchoolCode=")))
                        {
                            this.SchoolCode = line.Split('=')[1].ToLower();
                        }
                        else if (line.Contains("[Area Descriptions]"))
                        {
                            passAreaDescriptions = true;
                        }
                        else if (line.Contains("[Area Datasets]"))
                        {
                            passAreaDatasets = true;
                        }
                        else if ((line.Contains('=')) & (passAreaDescriptions == true))
                        {
                            string contentAfterEqualSign = line.Split('=')[1].ToLower().ToString().Trim();
                            int NumberBeforeEqualSign = int.Parse(line.Split('=')[0].ToLower().ToString().Trim());
                            AreaDescriptionsVector[NumberBeforeEqualSign - 1] = contentAfterEqualSign;
                            if (NumberBeforeEqualSign == 10)
                            {
                                passAreaDescriptions = false;
                            }

                        }
                        else if ((line.Contains('=')) & (passAreaDatasets == true))
                        {
                            string contentAfterEqualSign = line.Split('=')[1].ToLower().ToString().Trim();
                            int NumberBeforeEqualSign = int.Parse(line.Split('=')[0].ToLower().ToString().Trim());
                            AreaDatasetsVector[NumberBeforeEqualSign - 1] = contentAfterEqualSign;
                            if (NumberBeforeEqualSign == 10)
                            {
                                passAreaDatasets = false;
                            }
                        }
                        else
                        {

                        }
                        
                    }
                    // hastable connects: Area Descriptions:Area Datasets
                    
                    for (int i = 0; i < 10; i++)
                    {
                        if (AreaDescriptionsVector[i] != "")
                        {
                            Descript2DatasetsHash.Add(AreaDescriptionsVector[i], AreaDatasetsVector[i]);
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }

            }
        }

        public string FindOdinPath()
        {
            string resultOdinPath = "";
            // Read each line of the file into a string array. Each element 
            // of the array is one line of the file. 
            string[] lines = System.IO.File.ReadAllLines(@"C:\Odin\workstn.cfg");

            // Display the file contents by using a foreach loop.
            try
            {
                foreach (string line in lines)
                {
                    // Use a tab to indent each line of the file.
                    if (line.Contains("OdinPath") & (!line.Contains("//OdinPath")))
                    {
                        resultOdinPath = line.Split('=')[1];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return resultOdinPath;
        }
        public object[] GetAreaDescription()
        {
            object[] result = new object[] { "--Choose An Area--" };

            return result;
        }
    }
}
