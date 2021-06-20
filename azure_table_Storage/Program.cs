using System;
using System.Collections.Generic;
using Microsoft.Azure.Cosmos.Table;
namespace azure_table_Storage
{
    class Program
    {
        private static string connection_string ="<Add_Your_Own_ConnectionString>";
        private static string table_name ="archivedata";

        private static string partition_key ="Kakinada";
        private static string row_key ="NP";
        
        static void Main(string[] args)
        {
            try{
                Console.WriteLine("Started Table Storage demo");
                CloudStorageAccount _account = CloudStorageAccount.Parse(connection_string);
                CloudTableClient _tableClient = _account.CreateCloudTableClient();
                CloudTable _table = _tableClient.GetTableReference(table_name);
                _table.CreateIfNotExists();
                
                Console.WriteLine("Table created succecssfully");

                // Based on your operation uncomment the below operation and perform it.

                // Insert(_table);
                // BulkOperation(_table);
                // Update(_table);
                // RetriveItems(_table);
                // RetriveAndDelete(_table);
                
                Console.WriteLine("Ended Table Storage demo");
                Console.ReadKey();
            }
            catch(Exception ex){
                throw ex;
            }
        }

         private static void Insert(CloudTable _table)
         {
                Console.WriteLine("Single Table Insert entity.");

                Employee _employee = new Employee("NaniPotti", "Kakinada", "NP");
                TableOperation _tableOperation = TableOperation.Insert(_employee);
                TableResult _result = _table.Execute(_tableOperation);

                Console.WriteLine("Ended Single Table Insert entity.");
        }

        private static void BulkOperation(CloudTable _table)
        {
                Console.WriteLine("Bulk Insert entities.");

                List<Employee> employees = new List<Employee>()
                {
                    new Employee("Nuthan", "EastGodavari", "NN"),
                    new Employee("Ramya", "EastGodavari", "SR"),
                };

                TableBatchOperation _tableBatchOperation = new TableBatchOperation();
                foreach(Employee emp in employees)
                    _tableBatchOperation.Insert(emp);

                TableBatchResult _result = _table.ExecuteBatch(_tableBatchOperation);

                Console.WriteLine("Ended Bulk Insert entities.");                
        }

        private static void Update(CloudTable _table)
        {

                Employee _employee = new Employee("Nani Potti", partition_key, row_key);
                TableOperation _tableOperation = TableOperation.InsertOrMerge(_employee);
                TableResult _result = _table.Execute(_tableOperation);

                Console.WriteLine("Updated successfully.");

        }

        private static void RetriveItems(CloudTable _table)
        {           

                TableOperation _tableOperation = TableOperation.Retrieve<Employee>(partition_key,row_key);
                TableResult _result = _table.Execute(_tableOperation);

                Employee emp = _result.Result as Employee;

                Console.WriteLine($"Employee Name {emp.EmployeeName} and his/her city: {emp.PartitionKey}");

        }
        private static void RetriveAndDelete(CloudTable _table)
        {            
                TableOperation _tableOperation = TableOperation.Retrieve<Employee>(partition_key,row_key);
                TableResult _result = _table.Execute(_tableOperation);

                Employee emp = _result.Result as Employee;

                TableOperation _tableDeleteOperation = TableOperation.Delete(emp);
                TableResult _tableDeleteResult = _table.Execute(_tableDeleteOperation);

                Console.WriteLine($"Deleted Sucessfull.");
        }
    }   
}
