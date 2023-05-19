using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine_RestAPI_DataAccess.Exceptions
{
    public class EntityNotFoundException: Exception
    {
        public EntityNotFoundException(int id) : base($"Entity with ID '{id}' was not found.") { }

        public EntityNotFoundException(string message) : base(message) { }
    }
}
