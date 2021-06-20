using System;
using System.Collections.Generic;
using Microsoft.Azure.Cosmos.Table;
namespace azure_table_Storage
{
    class Program
    {
        private static string connection_string ="<Add_your_connection_string>";
        private static string table_name ="archivedata";

        private static string partition_key ="Nellore";
        private static string row_key ="NR";
        
        static void Main(string[] args)
        {
            try{
                Console.WriteLine("Started Table Storage demo");
                CloudStorageAccount _account = CloudStorageAccount.Parse(connection_string);
                CloudTableClient _tableClient = _account.CreateCloudTableClient();
                CloudTable _table = _tableClient.GetTableReference(table_name);
                _table.CreateIfNotExists();
                
                Console.WriteLine("Table created succecssfully");
            
                // #region Insert
                // Console.WriteLine("Single Table Insert entity.");

                // Employee _employee = new Employee("Potti", "Kakinada", "SN");
                // TableOperation _tableOperation = TableOperation.Insert(_employee);
                // TableResult _result = _table.Execute(_tableOperation);

                // Console.WriteLine("Ended Single Table Insert entity.");
                // #endregion Insert
               
                // #region BulkOperation
                // Console.WriteLine("Bulk Insert entities.");

                // List<Employee> employees = new List<Employee>()
                // {
                //     new Employee("Nani", "Nellore", "NS"),
                //     new Employee("Ramya", "Nellore", "NR"),
                // };

                // TableBatchOperation _tableBatchOperation = new TableBatchOperation();
                // foreach(Employee emp in employees)
                //     _tableBatchOperation.Insert(emp);

                // TableBatchResult _result = _table.ExecuteBatch(_tableBatchOperation);

                // Console.WriteLine("Ended Bulk Insert entities.");
                // #endregion BulkOperation

                // #region RetriveItems

                // TableOperation _tableOperation = TableOperation.Retrieve<Employee>(partition_key,row_key);
                // TableResult _result = _table.Execute(_tableOperation);

                // Employee emp = _result.Result as Employee;

                // Console.WriteLine($"Employee Name {emp.EmployeeName} and his/her city: {emp.PartitionKey}");

                // #endregion RetriveItems

            //    #region Update

            //     Employee _employee = new Employee("Nani Potti", partition_key, row_key);
            //     TableOperation _tableOperation = TableOperation.InsertOrMerge(_employee);
            //     TableResult _result = _table.Execute(_tableOperation);

            //     Console.WriteLine("Updated successfully.");
            //     #endregion Update

            
                #region Retrive_and_Delete

                TableOperation _tableOperation = TableOperation.Retrieve<Employee>(partition_key,row_key);
                TableResult _result = _table.Execute(_tableOperation);

                Employee emp = _result.Result as Employee;

                TableOperation _tableDeleteOperation = TableOperation.Delete(emp);
                TableResult _tableDeleteResult = _table.Execute(_tableDeleteOperation);

                Console.WriteLine($"Employee Name {emp.EmployeeName} and his/her city: {emp.PartitionKey}");

                #endregion Retrive_and_Delete

                Console.WriteLine("Ended Table Storage demo");

            
                Console.ReadKey();
            }
            catch(Exception ex){
                throw ex;
            }
        }
    }
}
