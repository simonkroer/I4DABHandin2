using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DocumentDB.Repository;
using Handin2_2DDB.Core.Domain;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Client.TransientFaultHandling;
using Newtonsoft.Json;

//For the repository design pattern are used:
//https://github.com/Crokus/cosmosdb-repo
//CRUD Operations are used from this repo and adapted for the PersonRepository


namespace Handin2_2DDB.Persistence.Repositories
{
    class PersonRepository : DocumentDbRepository<Person>, IDocumentDbRepository<Person>
    {
        private DocumentDbRepository<Person> repo;

        public PersonRepository(IReliableReadWriteDocumentClient Client, string databaseName) : base(Client,databaseName)
        {
        }

        public async Task CreatePerson(Person personToCreate)
        {
            await AddOrUpdateAsync(personToCreate);

            WriteToConsoleAndPromptToContinue("Created person with ID: {0}", personToCreate.Id);
        }

        public async Task<Person> ReadPerson(string id)
        {
            var personToGet = await GetByIdAsync(id);
            WriteToConsoleAndPromptToContinue("Read person with ID: {0}", personToGet.Id);

            return personToGet;
        }

        public async Task UpdatePerson(Person personToUpdate)
        {
            await AddOrUpdateAsync(personToUpdate);
            WriteToConsoleAndPromptToContinue("Updated person with ID: {0}", personToUpdate.Id);
        }

        public async Task DeletePerson(string id)
        {

            var complete = await RemoveAsync(id);

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
            IEnumerable<Person> persons = await GetAllAsync();

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
