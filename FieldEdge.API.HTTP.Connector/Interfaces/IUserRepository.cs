using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldEdge.API.HTTP.Connector.Interfaces
{
    public interface IUserRepository
    {
        bool ValidateUser(string username, string password);
    }
}
