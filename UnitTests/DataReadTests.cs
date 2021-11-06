using AssistWith.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace UnitTests
{

    [TestClass]
    public class DataReadTests
    { 
        [TestMethod]
        public void DataTAbleSelect_Selects()
        { 
            Dictionary<int, DataRow> dupRows = new Dictionary<int, DataRow>();
            string[] cols = new string[] { };   //"NAME", "ADDR", "AGE" 
            for (int iRow = 0; iRow < data.Rows.Count; iRow++)
            {
                var select = string.Join(" AND ", (from col in cols select $" {col} = '{data.Rows[0][col]}' ")); 
                if(!string.IsNullOrEmpty(select))
                    if (data.Select(select).Length > 1) 
                        dupRows.Add(iRow, data.Rows[iRow]);  
            } 
            Assert.IsNotNull(dupRows);
        }

        private DataTable data {

            get { 
                DataTable dt = new DataTable();
                dt.Columns.Add("SSN", typeof(string));
                dt.Columns.Add("NAME", typeof(string));
                dt.Columns.Add("ADDR", typeof(string));
                dt.Columns.Add("AGE", typeof(int));
                dt.Rows.Add("203456876", "John", "12 Main Street, Newyork, NY", 15);
                dt.Rows.Add("203456877", "SAM", "13 Main Ct, Newyork, NY", 25);
                dt.Rows.Add("203456878", "Elan", "14 Main Street, Newyork, NY", 35);
                dt.Rows.Add("203456878", "Elan", "14 Main Street, Newyork, NY", 35);
                dt.Rows.Add("203456879", "Smith", "12 Main Street, Newyork, NY", 45);
                dt.Rows.Add("203456880", "SAM", "345 Main Ave, Dayton, OH", 55);
                dt.Rows.Add("203456881", "Sue", "32 Cranbrook Rd, Newyork, NY", 65);
                dt.Rows.Add("203456882", "Winston", "1208 Alex St, Newyork, NY", 65);
                dt.Rows.Add("203456883", "Mac", "126 Province Ave, Baltimore, NY", 85);
                dt.Rows.Add("203456884", "SAM", "126 Province Ave, Baltimore, NY", 95);
                return dt; 
            }
        }
    }
}
