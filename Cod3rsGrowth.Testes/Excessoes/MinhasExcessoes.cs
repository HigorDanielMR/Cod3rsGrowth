using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.Testes.Excessoes
{
    public class MinhasExcessoes : Exception
    {
        public MinhasExcessoes(string message) : base(message)
        {
        }
    }
}
