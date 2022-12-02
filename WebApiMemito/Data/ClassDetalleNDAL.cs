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
    public class ClassDetalleNDAL
    {
         public List<DetalleNota> ListaDetalleNota()
         {
            List<DetalleNota> listNota = new List<DetalleNota>();
            using (SqlConnection con = new SqlConnection(Conexion.CadCon))
            {
                SqlCommand cmd = new SqlCommand("SELECT Detalle_Nota.id_Detalle, Obra.Nombre_Obra, Proveedor.RazonSoc, Material.Nombre_Mat, Nota.Fecha, Detalle_Nota.Cantidad, Detalle_Nota.PrecioUnitario, Detalle_Nota.Extra "
                                               + "FROM Detalle_Nota inner join Obra on (Detalle_Nota.Obra = Obra.id_Obra) inner join Nota on (Detalle_Nota.Nota = Nota.id_Nota) "
                                               + "inner join Material on (Detalle_Nota.Material = Material.Id_Mate) inner join Proveedor on (Detalle_Nota.Prove = Proveedor.Id_Prove);", con);
                try
                {
                    con.Open();
                    //cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            listNota.Add(new DetalleNota
                            {
                                id_Detalle = Convert.ToInt32(dr["id_Detalle"]),
                                obra = new Obra
                                {
                                    Nombre_Obra = dr["Nombre_Obra"].ToString(),
                                },
                                prove = new Proveedor
                                {
                                    RazonSoc = dr["RazonSoc"].ToString()
                                },
                                Mate = new Material
                                {
                                    Nombre_Mat = dr["Nombre_Mat"].ToString()
                                },
                                note = new Nota
                                {
                                    Fecha = Convert.ToDateTime(dr["Fecha"].ToString())
                                },
                                Cantidad = Convert.ToInt32(dr["Cantidad"]),
                                PrecioUnitario = Convert.ToSingle(dr["PrecioUnitario"]),
                                Extra = dr["Extra"].ToString()
                            });
                        }
                    }
                    return listNota;
                }
                catch (Exception ex)
                {
                    return listNota;
                }
            }
        }

        public DetalleNota Obtener(string id_DetalleNota)
        {
            DetalleNota obj = new DetalleNota();
            using (SqlConnection con = new SqlConnection(Conexion.CadCon))
            {
                SqlCommand cmd = new SqlCommand("SELECT Detalle_Nota.id_Detalle, Obra.Nombre_Obra, Proveedor.RazonSoc, Material.Nombre_Mat, Nota.Fecha, Detalle_Nota.Cantidad, Detalle_Nota.PrecioUnitario, Detalle_Nota.Extra " +
                                                "FROM Detalle_Nota inner join Obra on (Detalle_Nota.Obra = Obra.id_Obra) inner join Nota on (Detalle_Nota.Nota = Nota.id_Nota) " +
                                                "inner join Material on (Detalle_Nota.Material = Material.Id_Mate) inner join Proveedor on (Detalle_Nota.Prove = Proveedor.Id_Prove) " +
                                                "WHERE Detalle_Nota.id_Detalle = @ID", con);
                cmd.Parameters.AddWithValue("@ID", id_DetalleNota);

                try
                {
                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            obj = new DetalleNota()
                            {
                                id_Detalle = Convert.ToInt32(dr["id_Detalle"]),
                                obra = new Obra
                                {
                                    Nombre_Obra = dr["Nombre_Obra"].ToString(),
                                },
                                prove = new Proveedor
                                {
                                    RazonSoc = dr["RazonSoc"].ToString()
                                },
                                Mate = new Material
                                {
                                    Nombre_Mat = dr["Nombre_Mat"].ToString()
                                },
                                note = new Nota
                                {
                                    Fecha = Convert.ToDateTime(dr["Fecha"].ToString())
                                },
                                Cantidad = Convert.ToInt32(dr["Cantidad"]),
                                PrecioUnitario = Convert.ToSingle(dr["PrecioUnitario"]),
                                Extra = dr["Extra"].ToString()
                            };
                        }
                    }
                    return obj;
                }
                catch(Exception ex)
                {
                    return obj;
                }
            }
        }

        public bool RegistrarDetaNota(DetalleNotaPost note)
        {
            using (SqlConnection con = new SqlConnection(Conexion.CadCon))
            {
                SqlCommand cmd = new SqlCommand("INSERT Detalle_Nota VALUES (@Obra, @Prove, @Material, @Nota, @Cant, @PrecioUn, @Extra)", con);
                cmd.Parameters.AddWithValue("@Obra", note.Obra);
                cmd.Parameters.AddWithValue("@Prove", note.Prove);
                cmd.Parameters.AddWithValue("@Material", note.Material);
                cmd.Parameters.AddWithValue("@Nota", note.Nota);
                cmd.Parameters.AddWithValue("@Cant", note.Cantidad);
                cmd.Parameters.AddWithValue("@PrecioUn", note.PrecioUnitario);
                cmd.Parameters.AddWithValue("@Extra", note.Extra);

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