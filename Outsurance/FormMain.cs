using Outsurance;
using Outsurance.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Outsurance
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btn_SelectFile_Click(object sender, EventArgs e)
        {
            Stream myStream = null;

            //Manage File Dialog options
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFileDialog1.Filter = "csv files (*.csv)|";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //New list for CSV record data
                List<CSVData> contactlist = new List<CSVData>();
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {

                        //Open stream to file
                        using (StreamReader sr = new StreamReader(openFileDialog1.FileName))
                        {
                            string data = sr.ReadLine();
                            char[] seperators = { ',' };

                            //while loop for each line read. Exit once no more lines available.
                            while ((data = sr.ReadLine()) != null)
                            {
                                //Create string array and split by comma delimeter
                                string[] read = data.Split(seperators, StringSplitOptions.RemoveEmptyEntries);

                                //Initiate a new instance of CSVData
                                CSVData contact = new CSVData();

                                //Populate new instance with data from line read
                                contact.FullName = read[0] + " " + read[1];
                                contact.FirstName = read[0];
                                contact.LastName = read[1];
                                contact.Address = read[2];
                                contact.PhoneNumber = read[3];

                                // Add to list
                                contactlist.Add(contact);
                            }

                            DataManager sendData = new DataManager();
                            sendData.FileData(contactlist);
                            MessageBox.Show("Export to files completed. Path to files c:\\Outsurance\\", "Important Message");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }
    }
}

