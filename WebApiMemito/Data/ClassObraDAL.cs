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
    public class ClassObraDAL
    {
        public List<Obra> ListaObra()
        {
            List<Obra> listObra = new List<Obra>();
            using (SqlConnection con = new SqlConnection(Conexion.CadCon))
            {
                SqlCommand cmd = new SqlCommand("SELECT Obra.id_Obra, Obra.Nombre_Obra, Obra.Direccion, Obra.Fecha_ini, Obra.fecha_fin, Obra.Dueño, Obra.Responsable, Obra.Tel_resp, Obra.Correo_res FROM OBRA", con);
                try
                {
                    con.Open();
                    //cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            listObra.Add(new Obra
                            {
                                id_Obra = Convert.ToInt32(dr["id_Obra"]),
                                Nombre_Obra = dr["Nombre_Obra"].ToString(),
                                Direccion = dr["Direccion"].ToString(),
                                Fecha_ini = Convert.ToDateTime(dr["Fecha_ini"].ToString()),
                                Fecha_fin = Convert.ToDateTime(dr["fecha_fin"].ToString()),
                                Dueño = dr["Dueño"].ToString(),
                                Responsable = dr["Responsable"].ToString(),
                                Tel_resp = dr["Tel_resp"].ToString(),
                                Correo_resp = dr["Correo_resp"].ToString()
                            });
                        }
                    }
                    return listObra;
                }
                catch (Exception ex)
                {
                    return listObra;
                }
            }
        }

        public Obra Obtener(string id_Obra)
        {
            Obra obj = new Obra();
            using (SqlConnection con = new SqlConnection(Conexion.CadCon))
            {
                SqlCommand cmd = new SqlCommand("SELECT Obra.id_Obra, Obra.Nombre_Obra, Obra.Direccion, Obra.Fecha_ini, Obra.fecha_fin, Obra.Dueño, Obra.Responsable, Obra.Tel_resp, Obra.Correo_res FROM OBRA " +
                                                "WHERE Obra.id_Obra = @ID", con);
                cmd.Parameters.AddWithValue("@ID", id_Obra);

                try
                {
                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            obj = new Obra()
                            {
                                id_Obra = Convert.ToInt32(dr["id_Obra"]),
                                Nombre_Obra = dr["Nombre_Obra"].ToString(),
                                Direccion = dr["Direccion"].ToString(),
                                Fecha_ini = Convert.ToDateTime(dr["Fecha_ini"].ToString()),
                                Fecha_fin = Convert.ToDateTime(dr["fecha_fin"].ToString()),
                                Dueño = dr["Dueño"].ToString(),
                                Responsable = dr["Responsable"].ToString(),
                                Tel_resp = dr["Tel_resp"].ToString(),
                                Correo_resp = dr["Correo_resp"].ToString()
                            };
                        }
                    }
                    return obj;
                }
                catch (Exception ex)
                {
                    return obj;
                }
            }
        }

        public bool RegistrarObra(Obra obra)
        {
            using (SqlConnection con = new SqlConnection(Conexion.CadCon))
            {
                SqlCommand cmd = new SqlCommand("INSERT Obra VALUES (@Nombre_Obra, @Direccion, @Fecha_ini, @fecha_fin, @Dueño, @Responsable, @Tel_resp, @Correo_res)", con);
                cmd.Parameters.AddWithValue("@Nombre_Obra", obra.Nombre_Obra);
                cmd.Parameters.AddWithValue("@Direccion", obra.Direccion);
                cmd.Parameters.AddWithValue("@Fecha_ini", obra.Fecha_ini);
                cmd.Parameters.AddWithValue("@fecha_fin", obra.Fecha_fin);
                cmd.Parameters.AddWithValue("@Dueño", obra.Dueño);
                cmd.Parameters.AddWithValue("@Responsable", obra.Responsable);
                cmd.Parameters.AddWithValue("@Tel_resp", obra.Tel_resp);
                cmd.Parameters.AddWithValue("@Correo_res", obra.Correo_resp);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}