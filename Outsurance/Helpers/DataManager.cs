using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outsurance.Helpers
{
    class DataManager
    {
        /// <summary>
        /// Dat a list of imported records from csv
        /// </summary>
        /// <param name="dataList"> List of type CSVData</param>
        public void FileData(List<CSVData> dataList)
        {
            string description = "";

            #region Output Data Text File 1

            // Frequency of Firstname ordered by Frequency Descending
            description = "Frequency of Firstname ordered by Frequency Descending";
            var result = dataList.GroupBy(a => a.FirstName).Select(g => new CSVData { FirstName = g.Key, Count = g.Count() }).OrderByDescending(o => o.Count).ToList();
            FIleIO.SaveFileTo(result, description, 0, "File1.txt");

            //Frequency of Lastname ordered desc by frequency
            description = "Frequency of LastName ordered by Frequency Descending";
            var result1 = dataList.GroupBy(a => a.LastName).Select(g => new CSVData { LastName = g.Key, Count = g.Count() }).OrderByDescending(o => o.Count).ToList();
            FIleIO.SaveFileTo(result1, description, 1, "File1.txt");

            //Frequency of Firstname ordered by Firstname alphabetically
            description = "Frequency of Firstname ordered by Firstname alphabetically";
            var result2 = dataList.GroupBy(a => a.FirstName).Select(g => new CSVData { FirstName = g.Key, Count = g.Count() }).OrderBy(o => o.FirstName).ToList();
            FIleIO.SaveFileTo(result2, description, 0, "File1.txt");

            //Frequency of Lastname ordered by Lastname alphabetically
            description = "Frequency of Lastname ordered by Lastname alphabetically";
            var result3 = dataList.GroupBy(a => a.LastName).Select(g => new CSVData { LastName = g.Key, Count = g.Count() }).OrderBy(o => o.LastName).ToList();
            FIleIO.SaveFileTo(result3, description, 1, "File1.txt");
            #endregion
                   
            #region Output Data Text File 2

            //List of names and surnames on one list ordered descending by frequency
            description = "List of names and surnames on one list ordered descending by frequency";
            result.AddRange(result1);
            FIleIO.SaveFileTo(result.OrderByDescending(o => o.Count).ToList(), description, 2, "File2.txt");

            // List of names and surnames on one list ordered by first column
            description = "List of full names";
            var result4 = dataList.OrderBy(o => o.LastName).ToList();
            FIleIO.SaveFileTo(result4, description, 3, "File2.txt");

            #endregion
        }
    }
}


