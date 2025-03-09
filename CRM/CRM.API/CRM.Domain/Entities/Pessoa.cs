using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMB.Abstractions.Entities;

namespace CRM.Domain.Entities
{
    public class Pessoa : Entity<Guid>
    {

        public string Email { get; set; }

    }
}
