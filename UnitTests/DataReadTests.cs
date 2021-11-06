using AssistWith.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace UnitTests
{ 
    class BaseMock
    {
        virtual public void Foo()
        {
            Console.WriteLine("BaseMock");
        }
        public event EventHandler<EventArgs> OnEvent;
        protected virtual void Event(EventArgs e)
        {
            string foo = "";
            OnEvent?.Invoke(this, e);
        }
    }
    class DeriveMock : BaseMock
    {
        public override void Foo()
        {
            Console.WriteLine("DeriveMock");
            Event(new EventArgs());
        }
    }
    [TestClass]
    public class DataReadTests
    { 
        [TestMethod]
        public void DataTableSelect_Selects()
        {
            var d = new DeriveMock();
            EventArgs e = new EventArgs();
            d.OnEvent += (o, e) => { string item = ""; };
            d.OnEvent += (o, e) => { string item = ""; };
            d.Foo();

            string[] cols = new string[] { "NAME", "AGE" };  
            Dictionary<int, DataRow> dups = new Dictionary<int, DataRow>();
            
            for (int i = 0; i < data.Rows.Count; i++)
            {
                var select = string.Join(" AND ", (from col in cols select $" {col} = '{data.Rows[i][col]}' ")); 
                if(!string.IsNullOrEmpty(select))
                    if (data.Select(select).Length > 1) 
                        dups.Add(i+1, data.Rows[i]);  
            } 
            Assert.IsNotNull(dups);
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
                return dt; 
            }
        }
    }
}
