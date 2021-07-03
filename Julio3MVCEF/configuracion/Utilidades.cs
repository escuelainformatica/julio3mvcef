using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Julio3MVCEF.configuracion
{
    public static class Utilidades
    {
        public const double IVA=1.19;

        public static int CalculoIva(int bruto)
        {
            return (int)(bruto * IVA);
        }
      
    }
}
