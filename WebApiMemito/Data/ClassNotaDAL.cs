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
        public List<Nota> ListaNota()
        {
            List<Nota> listNota = new List<Nota>();
            using (SqlConnection con = new SqlConnection(Conexion.CadCon))
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
                    return listNota;
                }
                catch (Exception ex)
                {
                    return listNota;
                }
            }
        }

        public Nota Obtener(string id_Nota)
        {
            Nota obj = new Nota();
            using (SqlConnection con = new SqlConnection(Conexion.CadCon))
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
                    return obj;
                }
                catch (Exception ex)
                {
                    return obj;
                }
            }
        }

        public bool RegistrarNota(Nota note)
        {
            using (SqlConnection con = new SqlConnection(Conexion.CadCon))
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
                    return false;
                }
            }
        }
    }
}