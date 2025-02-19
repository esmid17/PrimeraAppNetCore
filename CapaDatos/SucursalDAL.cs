using System.Data;
using System.Data.SqlClient;
using CapaEntid;
using CapaEntidad;
using Microsoft.Extensions.Configuration;

namespace CapaDatos
{
    public class SucursalDAL : ConexionSQL
    {
        public List<SucursalCLS> FiltrarSucursales(SucursalCLS obj)
        {

            List<SucursalCLS> lista = null;

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("uspFiltrarSucursal", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombresucursal", obj.nombre ==null ? "": obj.nombre);
                        cmd.Parameters.AddWithValue("@direccion", obj.direccion == null ? "" : obj.direccion);
                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr != null)
                        {
                            SucursalCLS oSucursalCLS;
                            lista = new List<SucursalCLS>();

                            int idSucursal = dr.GetOrdinal("IIDSUCURSAL");
                            int nombre = dr.GetOrdinal("NOMBRE");
                            int direccion = dr.GetOrdinal("DIRECCION");

                            while (dr.Read())
                            {
                                oSucursalCLS = new SucursalCLS();
                                oSucursalCLS.idSucursal = dr.GetInt32(idSucursal);
                                oSucursalCLS.nombre = dr.IsDBNull(nombre) ? "" : dr.GetString(nombre);
                                oSucursalCLS.direccion = dr.IsDBNull(direccion) ? "" : dr.GetString(direccion);
                                lista.Add(oSucursalCLS);
                            }
                        }
                    }

                    cn.Close();
                    cn.Dispose();
                }
                catch (Exception ex)
                {
                    lista = null;
                }
            }

            return lista;
        }

        public List<SucursalCLS> ListarSucursales()
        {
            List<SucursalCLS> lista = null;

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("uspListarSucursal", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr != null)
                        {
                            SucursalCLS oSucursalCLS;
                            lista = new List<SucursalCLS>();

                            int idSucursal = dr.GetOrdinal("IIDSUCURSAL");
                            int nombre = dr.GetOrdinal("NOMBRE");
                            int direccion = dr.GetOrdinal("DIRECCION");

                            while (dr.Read())
                            {
                                oSucursalCLS = new SucursalCLS();
                                oSucursalCLS.idSucursal = dr.GetInt32(idSucursal);
                                oSucursalCLS.nombre = dr.IsDBNull(nombre) ? "" : dr.GetString(nombre);
                                oSucursalCLS.direccion = dr.IsDBNull(direccion) ? "" : dr.GetString(direccion);
                                lista.Add(oSucursalCLS);
                            }
                        }
                    }

                    cn.Close();
                    cn.Dispose();
                }
                catch (Exception ex)
                {
                    lista = null;
                }
            }

            return lista;
        }
    }
}
