using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SercanUrunTakibi.Models
{
    public class Category : BaseClass
    {
        // Kılçık <-- Category -> Standart Kılçık
        public String CategoryName { get; set; }


        

        // Insert Ctor
        public Category(String p_categoryName,int p_createUser)
        {
            String sql = "insert into category"
                +" (category_name,create_user,create_date)"
            +" values (@Category_Name,@Create_User,now())";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@Category_Name", p_categoryName);
            cmd.Parameters.AddWithValue("@Create_User", p_createUser);
            
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
       
        // Get Ctor
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
                    this.Id = reader.GetInt32(0);
                    this.CategoryName = reader.GetString(1);
                    this.IsActive = reader.GetBoolean(2);
                    this.CreateUser = reader.GetInt32(3);
                    this.CreateDate = reader.GetDateTime(4);
                    this.LastUpdateUser = reader.GetInt32(5);
                    this.LastUpdateDate = reader.GetDateTime(6);
                }
                reader.Close();
                cnn.Close();
            }
            catch (Exception ex) {
                ConnectionCloser(cnn);
                throw new Exception(ex.Message);
            }

        }

        // Save ve Delete
        public void Save(){
            String sql = "update category"
                +" set category_name = @CategoryName,is_active = @IsActive,last_update_user = @LastUpdateUser, last_update_date = now()"
                +" where category_id = @CategoryId";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@CategoryName", this.CategoryName);
            cmd.Parameters.AddWithValue("@IsActive", this.IsActive);
            cmd.Parameters.AddWithValue("@LastUpdateUser", this.LastUpdateUser);
            cmd.Parameters.AddWithValue("@CategoryId", this.Id);

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

        // TODO: GetAll

       


    }
}