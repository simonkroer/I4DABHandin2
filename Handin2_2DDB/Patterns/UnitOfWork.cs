using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentDB.Repository;
using Handin2_2DDB.Models;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Client.TransientFaultHandling;
using Newtonsoft.Json;

namespace Handin2_2DDB.Patterns
{
    class UnitOfWork
    {
        //For the repository design pattern are used:
        //https://github.com/Crokus/cosmosdb-repo
        //Oprindeligt blev nedenstående repository brugt, men dette fungerede ikke.
        //https://github.com/San7hos/DocumentDbRepository

        private DocumentDbRepository<Person> repo;

        public UnitOfWork(IReliableReadWriteDocumentClient client, string databaseName)
        {
            repo = new DocumentDbRepository<Person>(client, databaseName);
        }

        public async Task Create(Person personToCreate)
        {
            await repo.AddOrUpdateAsync(personToCreate);

            WriteToConsoleAndPromptToContinue("Created person with ID: {0}", personToCreate.Id);
        }

        public async Task<Person> Read(string id)
        {
            var personToGet = await repo.GetByIdAsync(id);
            WriteToConsoleAndPromptToContinue("Read person with ID: {0}", personToGet.Id);

            return personToGet;
            
        }

        public async Task Update(Person personToUpdate)
        {
            await repo.AddOrUpdateAsync(personToUpdate);
            WriteToConsoleAndPromptToContinue("Updated person with ID: {0}",personToUpdate.Id);
        }

        public async Task Delete(string id)
        {

            var complete = await repo.RemoveAsync(id);

            if (complete)
            {
                WriteToConsoleAndPromptToContinue("Deleted person with ID: {0}", id);
            }
            else
            {
                WriteToConsoleAndPromptToContinue("Couldn't delete person with ID: {0}", id);
            }
            
        }


        public async Task PrintPersonCollection()
        {
            IEnumerable<Person> persons = await repo.GetAllAsync();

            persons.ToList().ForEach(Console.WriteLine);
        }


        private void WriteToConsoleAndPromptToContinue(string format, params object[] args)
        {
            Console.WriteLine();
            Console.WriteLine(format, args);
            Console.WriteLine("Press any key to continue ...");
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
