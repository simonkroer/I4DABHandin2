using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentDB.Repository;
using Handin2_2DDB.Core;
using Handin2_2DDB.Persistence.Repositories;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Client.TransientFaultHandling;
using Newtonsoft.Json;

namespace Handin2_2DDB
{
    class UnitOfWork : IUnitOfWork
    {
        public PersonRepository PersonRepo { get; private set; }

        public UnitOfWork(PersonRepository repository)
        {
            PersonRepo = repository;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
