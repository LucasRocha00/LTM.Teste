using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTM.Teste.Entities
{
    public class Usuario
    {
        public int Id { get; private set; }
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}
