using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace windowsForm
{
    [DataContract(IsReference = true)]
    class Ciudad
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        
        public string NombreCiudad { get; set; }
    }
}
