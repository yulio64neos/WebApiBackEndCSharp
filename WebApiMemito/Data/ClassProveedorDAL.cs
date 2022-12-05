using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using WebApiMemito.Models;

namespace WebApiMemito.Data
{
    public class ClassProveedorDAL
    {
        readonly private string CadConexion = ConfigurationManager.ConnectionStrings["Obra"].ConnectionString;

        public List<Proveedor> ListaProveedor(ref string mensaje)
        {
            List<Proveedor> listObra = new List<Proveedor>();
            using (SqlConnection con = new SqlConnection(CadConexion))
            {
                SqlCommand cmd = new SqlCommand("SELECT Proveedor.Id_Prove, Proveedor.RazonSoc, Proveedor.Agente, Proveedor.Direccion, Proveedor.Telefono, Proveedor.Correo, Proveedor.Tipo_Material FROM Proveedor", con);
                try
                {
                    con.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            listObra.Add(new Proveedor
                            {
                                Id_Prove = Convert.ToInt32(dr[0]),
                                RazonSoc = dr["RazonSoc"].ToString(),
                                Agente = dr["Agente"].ToString(),
                                Direccion = dr["Direccion"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Tipo_Material = dr["Tipo_Material"].ToString()
                            });
                        }
                        con.Close();
                    }
                }
                catch (Exception ex)
                {
                    con.Close();
                    mensaje = ex.Message;
                }
            }
            return listObra;
        }

        public Proveedor Obtener(string id_Proveedor, ref string mensaje)
        {
            Proveedor obj = new Proveedor();
            using (SqlConnection con = new SqlConnection(CadConexion))
            {
                SqlCommand cmd = new SqlCommand("SELECT Proveedor.Id_Prove, Proveedor.RazonSoc, Proveedor.Agente, Proveedor.Direccion, Proveedor.Telefono, Proveedor.Correo, Proveedor.Tipo_Material FROM Proveedor " +
                                                "WHERE Proveedor.Id_Prove = @ID", con);
                cmd.Parameters.AddWithValue("@ID", id_Proveedor);

                try
                {
                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            obj = new Proveedor()
                            {
                                Id_Prove = Convert.ToInt32(dr[0]),
                                RazonSoc = dr["RazonSoc"].ToString(),
                                Agente = dr["Agente"].ToString(),
                                Direccion = dr["Direccion"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Tipo_Material = dr["Tipo_Material"].ToString()
                            };
                        }
                    }

                    con.Close();
                }
                catch (Exception ex)
                {
                    con.Close();
                    mensaje = ex.Message;
                }
            }
            return obj;
        }

        public bool RegistrarProveedor(Proveedor prove, ref string mensaje)
        {
            using (SqlConnection con = new SqlConnection(CadConexion))
            {
                SqlCommand cmd = new SqlCommand("INSERT Proveedor VALUES(@RazonSoc, @Agente, @Direccion, @Telefono, @Correo, @Tipo_Material);", con);
                cmd.Parameters.AddWithValue("@RazonSoc", prove.RazonSoc);
                cmd.Parameters.AddWithValue("@Agente", prove.Agente);
                cmd.Parameters.AddWithValue("@Direccion", prove.Direccion);
                cmd.Parameters.AddWithValue("@Telefono", prove.Telefono);
                cmd.Parameters.AddWithValue("@Correo", prove.Correo);
                cmd.Parameters.AddWithValue("Tipo_Material", prove.Tipo_Material);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    mensaje = ex.Message;
                    return false;
                }
            }
        }
    }
}