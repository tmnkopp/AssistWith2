using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssistWith.Models
{
    public interface BaseEntity { 
        int PrimeKey { get;   }
    }
    public class ClientViewModel : BaseEntity
    {

        public Client Client { get; set; }
        public int PrimeKey { get => Client.ClientID;}
    }
}
