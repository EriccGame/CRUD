using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Modelos.Json
{
    public class Root
    {
        public Meta Meta { get; set; }
        public dynamic Data { get; set; }
    }
}
