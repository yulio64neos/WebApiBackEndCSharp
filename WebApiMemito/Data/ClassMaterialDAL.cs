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
    public class ClassMaterialDAL
    {
        public List<Material> ListaMaterial()
        {
            List<Material> listMate = new List<Material>();
            using (SqlConnection con = new SqlConnection(Conexion.CadCon))
            {
                SqlCommand cmd = new SqlCommand("SELECT Material.Id_Mate, Material.Nombre_Mat, Material.Marca, Material.Categoria, Material.UnidadMedida " +
                                                "FROM Material;", con);
                try
                {
                    con.Open();
                    //cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            listMate.Add(new Material
                            {
                                Id_Mate = Convert.ToInt32(dr["Id_Mate"]),
                                Nombre_Mat = dr["Nombre_Mat"].ToString(),
                                Marca = dr["Marca"].ToString(),
                                Categoria = dr["Categoria"].ToString(),
                                UnidadMedida = dr["UnidadMedida"].ToString()
                            });
                        }
                    }
                    return listMate;
                }
                catch (Exception ex)
                {
                    return listMate;
                }
            }
        }

        public Material Obtener(string id_Material)
        {
            Material obj = new Material();
            using (SqlConnection con = new SqlConnection(Conexion.CadCon))
            {
                SqlCommand cmd = new SqlCommand("SELECT Material.Id_Mate, Material.Nombre_Mat, Material.Marca, Material.Categoria, Material.UnidadMedida " +
                                                "FROM Material WHERE Material.Id_Mate = @ID;", con);
                cmd.Parameters.AddWithValue("@ID", id_Material);

                try
                {
                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            obj = new Material()
                            {
                                Id_Mate = Convert.ToInt32(dr["Id_Mate"]),
                                Nombre_Mat = dr["Nombre_Mat"].ToString(),
                                Marca = dr["Marca"].ToString(),
                                Categoria = dr["Categoria"].ToString(),
                                UnidadMedida = dr["UnidadMedida"].ToString()
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

        public bool RegistrarMaterial(Material mate)
        {
            using (SqlConnection con = new SqlConnection(Conexion.CadCon))
            {
                SqlCommand cmd = new SqlCommand("INSERT Material VALUES (@Nombre_Mat, @Marca, @Categoria, @UnidadMedida)", con);
                cmd.Parameters.AddWithValue("@Nombre_Mat", mate.Nombre_Mat);
                cmd.Parameters.AddWithValue("@Marca", mate.Marca);
                cmd.Parameters.AddWithValue("@Categoria", mate.Categoria);
                cmd.Parameters.AddWithValue("@UnidadMedida", mate.UnidadMedida);

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