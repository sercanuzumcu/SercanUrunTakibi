using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SercanUrunTakibi.Models
{
    public class Category
    {
        // Kılçık <-- Category -> Standart Kılçık
        public int CategoryId { get; set; }
        public String CategoryName { get; set; }
        public bool IsActive { get; set; }


        SqlConnection cnn = new SqlConnection("Server=.;Database=SercanDB; Trusted_Connection=true");

        public Category(String p_categoryName)
        {
            String sql = "insert into category (category_name) values (@Category_Name)";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@Category_Name", p_categoryName);

            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            catch (Exception ex) {
                ConnectionCloser(cnn);
                throw new Exception(ex.Message);
            }
        }

        public Category(int p_categoryId)
        {
            String sql = "select * from category where category_id = @CategoryId";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@CategoryId", p_categoryId);

            try
            {
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    this.CategoryId = reader.GetInt32(0);
                    this.CategoryName = reader.GetString(1);
                    this.IsActive = reader.GetBoolean(2);
                }
                reader.Close();
                cnn.Close();
            }
            catch (Exception ex) {
                ConnectionCloser(cnn);
                throw new Exception(ex.Message);
            }

        }

        public void Save(){
            String sql = "update category"
                +" set category_name = @CategoryName,is_active = @IsActive"
                +" where category_id = @CategoryId";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@CategoryName", this.CategoryName);
            cmd.Parameters.AddWithValue("@IsActive", this.IsActive);
            cmd.Parameters.AddWithValue("@CategoryId", this.CategoryId);

            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            catch (Exception ex) {
                ConnectionCloser(cnn);
                throw new Exception(ex.Message);
            }

        }

        public void ConnectionCloser(SqlConnection p_cnn) {
            if (p_cnn.State == System.Data.ConnectionState.Open)
            {
                p_cnn.Close();
            }
        }
    }
}