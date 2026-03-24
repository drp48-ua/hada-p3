using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;

namespace library
{
    public class CADCategory
    {
        private string constring;

        public CADCategory()
        {
            constring = ConfigurationManager.ConnectionStrings["miconexion"].ToString();
        }

        public List<ENCategory> readAll()
        {
            List<ENCategory> lista = new List<ENCategory>();
            try
            {
                using (SqlConnection c = new SqlConnection(constring))
                {
                    c.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Categories", c);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ENCategory cat = new ENCategory();
                        cat.Id = int.Parse(dr["id"].ToString());
                        cat.Name = dr["name"].ToString();
                        lista.Add(cat);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
            }
            return lista;
        }
    }
}