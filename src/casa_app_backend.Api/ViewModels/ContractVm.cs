using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using casa_app_backend.Domain.Models;

namespace casa_app_backend.Api.ViewModels
{
    public class ContractVm
    {
        public int Id { get; set; }
         public string Name { get; set; } = null!;
        public virtual List<User> UsersOfContract { get; set; } = null!;   
        public virtual List<Invite>? Invites { get; set; }  
    }
    public class ContractNewVm
    {
               public int OwnerId { get; set; }
    }
    public class ContractUpdateVm
    {
        public int OwnerId { get; set; }
    }
}