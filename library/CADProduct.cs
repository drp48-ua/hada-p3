using System;
using System.Data.SqlClient;
using System.Configuration;

namespace library
{
    public class CADProduct
    {
        private string constring;

        public CADProduct() 
        {
            constring = ConfigurationManager.ConnectionStrings["miconexion"].ToString();
        }

        public bool create(ENProduct en) 
        {
            bool exito = false;
            try
            {
                using (SqlConnection c = new SqlConnection(constring))
                {
                    c.Open();
                    string query = "INSERT INTO Products (name, code, amount, price, category, creationDate) VALUES (@name, @code, @amount, @price, @category, @creationDate)";
                    SqlCommand cmd = new SqlCommand(query, c);
                    cmd.Parameters.AddWithValue("@name", en.Name);
                    cmd.Parameters.AddWithValue("@code", en.Code);
                    cmd.Parameters.AddWithValue("@amount", en.Amount);
                    cmd.Parameters.AddWithValue("@price", en.Price);
                    cmd.Parameters.AddWithValue("@category", en.Category);
                    cmd.Parameters.AddWithValue("@creationDate", en.CreationDate);

                    if (cmd.ExecuteNonQuery() > 0) exito = true;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message); 
            }
            return exito;
        }

        public bool update(ENProduct en) 
        {
            bool exito = false;
            try
            {
                using (SqlConnection c = new SqlConnection(constring))
                {
                    c.Open();
                    string query = "UPDATE Products SET name=@name, amount=@amount, price=@price, category=@category, creationDate=@creationDate WHERE code=@code";
                    SqlCommand cmd = new SqlCommand(query, c);
                    cmd.Parameters.AddWithValue("@name", en.Name);
                    cmd.Parameters.AddWithValue("@code", en.Code);
                    cmd.Parameters.AddWithValue("@amount", en.Amount);
                    cmd.Parameters.AddWithValue("@price", en.Price);
                    cmd.Parameters.AddWithValue("@category", en.Category);
                    cmd.Parameters.AddWithValue("@creationDate", en.CreationDate);

                    if (cmd.ExecuteNonQuery() > 0) exito = true;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message); 
            }
            return exito;
        }

        public bool delete(ENProduct en) 
        {
            bool exito = false;
            try
            {
                using (SqlConnection c = new SqlConnection(constring))
                {
                    c.Open();
                    string query = "DELETE FROM Products WHERE code=@code";
                    SqlCommand cmd = new SqlCommand(query, c);
                    cmd.Parameters.AddWithValue("@code", en.Code);

                    if (cmd.ExecuteNonQuery() > 0) exito = true;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message); 
            }
            return exito;
        }

        public bool read(ENProduct en) 
        {
            bool leido = false;
            try
            {
                using (SqlConnection c = new SqlConnection(constring))
                {
                    c.Open();
                    string query = "SELECT * FROM Products WHERE code=@code";
                    SqlCommand cmd = new SqlCommand(query, c);
                    cmd.Parameters.AddWithValue("@code", en.Code);
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        en.Name = dr["name"].ToString();
                        en.Amount = int.Parse(dr["amount"].ToString());
                        en.Price = float.Parse(dr["price"].ToString());
                        en.Category = int.Parse(dr["category"].ToString());
                        en.CreationDate = DateTime.Parse(dr["creationDate"].ToString());
                        leido = true;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message); 
            }
            return leido;
        }

        public bool readFirst(ENProduct en) 
        {
            bool leido = false;
            try
            {
                using (SqlConnection c = new SqlConnection(constring))
                {
                    c.Open();
                    string query = "SELECT TOP 1 * FROM Products ORDER BY code ASC";
                    SqlCommand cmd = new SqlCommand(query, c);
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        en.Code = dr["code"].ToString();
                        en.Name = dr["name"].ToString();
                        en.Amount = int.Parse(dr["amount"].ToString());
                        en.Price = float.Parse(dr["price"].ToString());
                        en.Category = int.Parse(dr["category"].ToString());
                        en.CreationDate = DateTime.Parse(dr["creationDate"].ToString());
                        leido = true;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
            }
            return leido;
        }

        public bool readNext(ENProduct en)
        {
            bool leido = false;
            try
            {
                using (SqlConnection c = new SqlConnection(constring))
                {
                    c.Open();
                    string query = "SELECT TOP 1 * FROM Products WHERE code > @code ORDER BY code ASC";
                    SqlCommand cmd = new SqlCommand(query, c);
                    cmd.Parameters.AddWithValue("@code", en.Code);
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        en.Code = dr["code"].ToString();
                        en.Name = dr["name"].ToString();
                        en.Amount = int.Parse(dr["amount"].ToString());
                        en.Price = float.Parse(dr["price"].ToString());
                        en.Category = int.Parse(dr["category"].ToString());
                        en.CreationDate = DateTime.Parse(dr["creationDate"].ToString());
                        leido = true;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message); 
            }
            return leido;
        }

        public bool readPrev(ENProduct en) 
        {
            bool leido = false;
            try
            {
                using (SqlConnection c = new SqlConnection(constring))
                {
                    c.Open();
                    string query = "SELECT TOP 1 * FROM Products WHERE code < @code ORDER BY code DESC";
                    SqlCommand cmd = new SqlCommand(query, c);
                    cmd.Parameters.AddWithValue("@code", en.Code);
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        en.Code = dr["code"].ToString();
                        en.Name = dr["name"].ToString();
                        en.Amount = int.Parse(dr["amount"].ToString());
                        en.Price = float.Parse(dr["price"].ToString());
                        en.Category = int.Parse(dr["category"].ToString());
                        en.CreationDate = DateTime.Parse(dr["creationDate"].ToString());
                        leido = true;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message); 
            }
            return leido;
        }
    }
}