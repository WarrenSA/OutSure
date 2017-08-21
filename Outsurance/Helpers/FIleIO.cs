using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Outsurance
{
    public static class FIleIO
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="contactList"> List of Class CSVData</param>
        /// <param name="description">Description sent to text file of what type of order the data is in </param>
        /// <param name="results">The results to manage whicg if statement must be executed</param>
        /// <param name="outputFile">The file name and externsion of the out put file</param>
        public static void SaveFileTo(List<CSVData> contactList, string description, int results, string outputFile)
        {
            bool exists = System.IO.Directory.Exists("c:\\Outsurance");
            if (!exists)
            {
                System.IO.Directory.CreateDirectory("c:\\Outsurance");
            }

            using (StreamWriter sw = new StreamWriter(@"c:\\Outsurance\" + outputFile, true))
            {
                sw.WriteLine(Environment.NewLine);
                sw.WriteLine(description);

                foreach (var item in contactList)
                {
                    switch (results)
                    {
                        case 0:
                            if (item.FirstName != null && item.LastName == null)
                            {
                                sw.WriteLine(item.FirstName + "," + item.Count);
                            }
                            break;

                        case 1:
                            if (item.LastName != null && item.FirstName == null)
                            {

                                sw.WriteLine(item.LastName + "," + item.Count);
                            }
                            break;

                        case 2:

                            if (item.FirstName != null)
                            {
                                sw.WriteLine(item.FirstName + "," + item.Count);
                            }
                            else if (item.LastName != null)
                            {
                                sw.WriteLine(item.LastName + "," + item.Count);
                            }
                            break;

                        case 3:
                            if (item.FullName != null)
                            {
                                sw.WriteLine(item.FullName);
                            }
                            break;
                    }
                }
                sw.Close();
            }
        }

    }
}


