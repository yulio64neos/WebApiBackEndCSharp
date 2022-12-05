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
    public class ClassNotaDAL
    {
        readonly private string CadConexion = ConfigurationManager.ConnectionStrings["Obra"].ConnectionString;

        public List<Nota> ListaNota(ref string mensaje)
        {
            List<Nota> listNota = new List<Nota>();
            using (SqlConnection con = new SqlConnection(CadConexion))
            {
                SqlCommand cmd = new SqlCommand("SELECT Nota.id_Nota, Nota.Fecha, Nota.Extra FROM Nota", con);
                try
                {
                    con.Open();
                    //cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            listNota.Add(new Nota
                            {
                                id_Nota = Convert.ToInt32(dr["id_Nota"]),
                                Fecha = Convert.ToDateTime(dr["Fecha"].ToString()),
                                Extra = dr["Extra"].ToString()
                            });
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
            return listNota;
        }

        public Nota Obtener(string id_Nota, ref string mensaje)
        {
            Nota obj = new Nota();
            using (SqlConnection con = new SqlConnection(CadConexion))
            {
                SqlCommand cmd = new SqlCommand("SELECT Nota.id_Nota, Nota.Fecha, Nota.Extra FROM Nota WHERE Nota.id_Nota = @ID", con);
                cmd.Parameters.AddWithValue("@ID", id_Nota);

                try
                {
                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            obj = new Nota()
                            {
                                id_Nota = Convert.ToInt32(dr["id_Nota"]),
                                Fecha = Convert.ToDateTime(dr["Fecha"].ToString()),
                                Extra = dr["Extra"].ToString()
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

        public List<Nota> NotaObra(string id_Obra, ref string mensaje)
        {
            List<Nota> obj = new List<Nota>();
            using (SqlConnection con = new SqlConnection(CadConexion))
            {
                SqlCommand cmd = new SqlCommand(@"SELECT Nota.Extra, Nota.Fecha
                FROM Detalle_Nota 
                INNER JOIN Nota ON Detalle_Nota.Nota = Nota.id_Nota
                INNER JOIN Obra ON Detalle_Nota.Obra = Obra.id_Obra
                WHERE Obra.id_Obra = @ID", con);
                cmd.Parameters.AddWithValue("@ID", id_Obra);

                try
                {
                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            obj.Add(new Nota
                            {
                                Fecha = Convert.ToDateTime(dr["Fecha"].ToString()),
                                Extra = dr["Extra"].ToString()
                            });
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

        public List<Nota> NotaObraFecha(string id_Obra, string fecha_ini, string fecha_fin, ref string mensaje)
        {
            List<Nota> obj = new List<Nota>();
            using (SqlConnection con = new SqlConnection(CadConexion))
            {
                SqlCommand cmd = new SqlCommand(@"SELECT Nota.Extra, Nota.Fecha
                FROM Detalle_Nota 
                INNER JOIN Nota ON Detalle_Nota.Nota = Nota.id_Nota
                INNER JOIN Obra ON Detalle_Nota.Obra = Obra.id_Obra
                WHERE Obra.id_Obra = @ID AND  Nota.Fecha >= @ini AND Nota.Fecha <= @fin", con);
                cmd.Parameters.AddWithValue("@ID", id_Obra);
                cmd.Parameters.AddWithValue("@ini", fecha_ini);
                cmd.Parameters.AddWithValue("@fin", fecha_fin);

                try
                {
                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            obj.Add(new Nota
                            {
                                Fecha = Convert.ToDateTime(dr["Fecha"].ToString()),
                                Extra = dr["Extra"].ToString()
                            });
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

        public bool RegistrarNota(Nota note, ref string mensaje)
        {
            using (SqlConnection con = new SqlConnection(CadConexion))
            {
                SqlCommand cmd = new SqlCommand("INSERT Nota VALUES(@Fecha, @Extra)", con);
                cmd.Parameters.AddWithValue("@Fecha", note.Fecha);
                cmd.Parameters.AddWithValue("@Extra", note.Extra);

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