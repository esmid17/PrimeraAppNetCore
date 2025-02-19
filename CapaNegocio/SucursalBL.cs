using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntid;

namespace CapaNegocio
{
    public class SucursalBL
    {
        public List<SucursalCLS> ListarSucursales()
        {
            SucursalDAL sucursalDAL = new SucursalDAL();
            return sucursalDAL.ListarSucursales();
        }

        public List<SucursalCLS> FiltrarSucursales(SucursalCLS obj)
        {
            SucursalDAL sucursalDAL = new SucursalDAL();
            return sucursalDAL.FiltrarSucursales(obj);
        }
    }
}
