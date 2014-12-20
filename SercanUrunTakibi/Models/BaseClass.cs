﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SercanUrunTakibi.Models
{
    public class BaseClass
    {
        protected SqlConnection cnn = new SqlConnection("Server=.;Database=SercanDB; Trusted_Connection=true");

        protected int Id { get; set; }
        protected bool IsActive { get; set; }
        protected int CreateUser { get; set; }
        protected DateTime CreateDate { get; set; }
        protected int LastUpdateUser { get; set; }
        protected DateTime LastUpdateDate { get; set; }

        public void setId(int p_id){
            Id = p_id;
        }

        public int getId() {
            return Id;
        }

        public void setIsActive(bool p_isActive) {
            IsActive = p_isActive;
        }

        public bool getIsActive() {
            return IsActive;
        }




        public void ConnectionCloser(SqlConnection p_cnn)
        {
            if (p_cnn.State == System.Data.ConnectionState.Open)
            {
                p_cnn.Close();
            }
        }
    }


}