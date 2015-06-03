using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Data.Odbc;
using System.Collections;

namespace ZebraBarPrintApp
{
    public partial class FormMysql : Form
    {
        // GLOBAL VARIABLE INITIALIZATION
        OdbcConnection ocon = new OdbcConnection(); // for ODBC connections 
        string tableName = "";//"hollins.stock"; // for table displayed at "dataGridView1"
        int currentIndex = -1;
        string lastSelectTableStatement = "";
        ServerConnection1 connectionInfo = new ServerConnection1();
        int BarcodeTypeIndexDefault = 4;  // default barcode type 
                                          // 1. Aztec Code
                                          // 2. Code 39 
                                          // 3. Code 128
                                          // 4. Code 128 | 1/2" x 2-1/4"
                                          // 5. Codabar
                                          // 6. U.P.C
                                          // (remember to update this comment when altering)
        public FormMysql()
        {
            InitializeComponent();
        }
        private void AreaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AreaComboBox.SelectedIndex == 0)
            {
                dataGridView1.DataSource = null;
                BarcodeTypeComboBox.SelectedIndex = BarcodeTypeIndexDefault;
            }
            else
            {
                tableName = connectionInfo.SchoolCode + "." + connectionInfo.Descript2DatasetsHash[AreaComboBox.Text];
                lastSelectTableStatement = "select item, retail, stock, bar_code from " + tableName;
                LoadTableOdbc(lastSelectTableStatement);
            }
            ItemTextBox.Text = "";
            RetailTextBox.Text = "";
            StockTextBox.Text = "";
            BarcodeTextBox.Text = "";
            CopiesComboBox.Text = "";
        }
        private void FormMysql_Load(object sender, EventArgs e)
        {
            //Find the "Data Source Name"
            // 1. Locate file 'workstn.cfg' at 'C:\Odin'
            // 2. Look for switch "Shared" in workstn.cfg, and use OdinPath
            // 3. With OdinPath, look for Odin.cfg
            // 4. Read Odin.cfg and get Driver, DriverName (DSN), ServerType
            // 5. Connect to ODBC
           
            connectionInfo.readOdinCfg();
            // Attention:
            // ODBC Database administrator has both 32bit and 64bit installed
            // but This app only recognize ODBC 64, *not* 32
            // 
            // connectionInfo.DriverName is parsed from ServerConnection1>readOdinCfg function
            // essentially, it is the line "DriverName=MySQL_ODBC_hollins"
            // from [Misc] section from K:\Schools\Hollins\20141015 for test\odin.cfg (case is insensitive)
            // 
            // MySQL_ODBC_hollins was registered as 32bit System DSN
            // MySQL_ODBC_hollins_64 was mannually registered as 64bit System DSN
            //
            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // to achieve 32-bit System DSN please use:
            //ocon.ConnectionString = "DSN="+connectionInfo.DriverName.ToString();
            // to achieve 64-bit System DSN please use:
            ocon.ConnectionString = "DSN=MySQL_ODBC_hollins_64";
            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            //
            // work still needs to be done to automatically prepare both 32 and 64 bit DSNs at ODBC
            // And the current app is only designed to take 64 DSNs. 


            //

            List<object> tmp = new List<object>();
            tmp.Add("--Choose An Area--");
            tmp.AddRange(connectionInfo.Descript2DatasetsHash.Keys.Cast<object>());
            this.AreaComboBox.Items.AddRange(tmp.Cast<object>().ToArray());
            AreaComboBox.SelectedIndex = 0;
            //
        }

        private void LoadTableOdbc(string tableQueryCommandText)
        {
            if (ocon.State == ConnectionState.Open)
            {
                ocon.Close();
            }
            Debug.WriteLine(ocon.ConnectionString);
            ocon.Open();
            try
            {
                OdbcDataAdapter oda = new OdbcDataAdapter(tableQueryCommandText + " order by item", ocon);
                DataSet ds = new DataSet();
                oda.Fill(ds, "stock");
                dataGridView1.DataSource = ds.Tables["stock"];
                // get rid of the row header at the table
                dataGridView1.RowHeadersVisible = false;
                // fill up data grid view with data base,
                // leaving no grey margin on the right of last columns
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                BarcodeTypeComboBox.SelectedIndex = BarcodeTypeIndexDefault;
                CopiesComboBox.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CopiesComboBox.Text = "";

            try
            {
                string item = dataGridView1.Rows[e.RowIndex].Cells["item"].Value.ToString();
                string barcode = dataGridView1.Rows[e.RowIndex].Cells["bar_code"].Value.ToString();
                OdbcCommand ocmd = ocon.CreateCommand();
                ocmd.CommandType = CommandType.Text;
                ocmd.CommandText = "select item, retail, stock, bar_code from " + 
                    tableName + " where (item='" + item + "' and bar_code='"+barcode+ "');";
                ocmd.ExecuteNonQuery();
                //MySqlCommand mcmd = mcon.CreateCommand();
                //mcmd.CommandType = CommandType.Text;
                //mcmd.CommandText = "select item, retail, stock, bar_code from " + tableName + " where item='" + item + "';";
                //mcmd.ExecuteNonQuery();

                DataTable dt = new DataTable();
                OdbcDataAdapter oda = new OdbcDataAdapter(ocmd);
                oda.Fill(dt);
                //MySqlDataAdapter mda = new MySqlDataAdapter(mcmd);
                //mda.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["item"].ToString().Trim() == "")
                    {
                        ItemTextBox.Text = "N/A";
                    }
                    else
                    {
                        ItemTextBox.Text = dr["item"].ToString();
                    }
                    RetailTextBox.Text = dr["retail"].ToString();
                    StockTextBox.Text = dr["stock"].ToString();
                    BarcodeTextBox.Text = dr["bar_code"].ToString();
                }
                //
                currentIndex = dataGridView1.CurrentRow.Index;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }



        private void label3_Click(object sender, EventArgs e)
        {

        }


        private void ItemTextBox_TextChanged(object sender, EventArgs e)
        {

        }


        public void PrintBarcode(string pProductName, string pRetail, string pBarcode, string pNoOfCopies, string BarcodeType)
        {
            string PrinterName = "ZDesigner GK420d";
            UpcLabel upcLabel = new UpcLabel();
            //Printer name
            upcLabel.PrintBarcode(PrinterName, pProductName, pRetail, pBarcode, pNoOfCopies, BarcodeType);

        }




        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BarCodeTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void stockBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void ItemTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            string soughtItem = ItemTextBox.Text;
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    OdbcCommand ocmd = ocon.CreateCommand();
                    ocmd.CommandType = CommandType.Text;
                    ocmd.CommandText = "select item, retail, stock, bar_code from " + tableName + " where lower(item) like lower('%" +
                        ItemTextBox.Text + "%')";
                    ocmd.ExecuteNonQuery();
                    //MySqlCommand mcmd = mcon.CreateCommand();
                    //mcmd.CommandType = CommandType.Text;
                    //mcmd.CommandText = "select item, retail, stock, bar_code from " + tableName + " where lower(item) like lower('%" +
                    //    ItemTextBox.Text + "%')";
                    //mcmd.ExecuteNonQuery();



                    // update the subtable
                    LoadTableOdbc(ocmd.CommandText);
                    lastSelectTableStatement = ocmd.CommandText;
                    //LoadTable(mcmd.CommandText);
                    //lastSelectTableStatement = mcmd.CommandText;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void BarCodeTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter & currentIndex != -1)
            {
                try
                {
                    OdbcCommand ocmd = ocon.CreateCommand();
                    ocmd.CommandType = CommandType.Text;
                    ocmd.CommandText = "update " + tableName + " set bar_code = '" + BarcodeTextBox.Text.ToString() + "' where item= '" + ItemTextBox.Text.ToString() + "'";
                    ocmd.ExecuteNonQuery();
                    //MySqlCommand mcmd = mcon.CreateCommand();
                    //mcmd.CommandType = CommandType.Text;
                    //mcmd.CommandText = "update " + tableName + " set bar_code = '" + BarcodeTextBox.Text.ToString() + "' where item= '" + ItemTextBox.Text.ToString() + "'";
                    //mcmd.ExecuteNonQuery();
                    LoadTableOdbc(lastSelectTableStatement);
                    dataGridView1.FirstDisplayedScrollingRowIndex = currentIndex;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void PrintReviewButton_Click(object sender, EventArgs e)
        {
            UpdateBarcodeReview();
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            bool readyToPrint = UpdateBarcodeReview();
            if (readyToPrint)
            {
                PrintBarcode(ItemTextBox.Text, RetailTextBox.Text, BarcodeTextBox.Text, CopiesComboBox.Text, BarcodeTypeComboBox.Text);
            }
        }
        private bool UpdateBarcodeReview()
        {
            bool readyToPrint = false;
            int numCopies;
            if (ItemTextBox.Text == "")
            {
                ItemTextBox.Text ="N/A";
                //MessageBox.Show("Error: Item name doesn't exist");
            }
            else if (BarcodeTextBox.Text == "")
            {
                MessageBox.Show("Error: Bar code is missing");
                BarcodeTextBox.Focus();
            }
            else if (CopiesComboBox.Text == "")
            {
                MessageBox.Show("Error: Number of copies is missing");
            }
            else if (!int.TryParse(CopiesComboBox.Text, out numCopies))
            {
                MessageBox.Show("Error: Number of copies is invalid");
            }
            else
            {
                try
                {
                    UpcLabel upclabel = new UpcLabel();
                    StringBuilder strBldr = upclabel.ReviewBarcode(ItemTextBox.Text, RetailTextBox.Text, 
                        BarcodeTextBox.Text, CopiesComboBox.Text, BarcodeTypeComboBox.Text);
                    ZplCodeTextBox.Text = strBldr.ToString();
                    readyToPrint = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Test Error: " + ex.Message);
                }
            }
            return readyToPrint;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void BarCodeTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ItemTextBoxToolTip_Popup(object sender, PopupEventArgs e)
        {

        }
    }
}
