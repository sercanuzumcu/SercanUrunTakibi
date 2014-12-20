using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SercanUrunTakibi.Models
{
    public class Product : BaseClass
    {
/*
 * Örnek Ürün, erkanplastik.com.tr'dan alınmıştır.
 * Standart kılçık:
 * Ölçü: 8mm,10mm...
 * Birim: Kutu (1 olarak geçiyor sitede ama kutu,kilo,poşet  olması lazım)
 * Adet: 10000 (Bir kutunun içerisindeki kılçık miktarı)
 * Renkler: Tüm Renkler
 * Hammadde: P.P. Naylon 
 */

        // Websitesi datası
        private Category Category { get; set; }
        public SubCategory SubCategory { get; set; }
        // Ölçü (int değil çünkü ölçü olarak "Standart" gelebiliyor)
        public String ProductSize { get; set; }        
        // Ölçüm Birimi (Kilo, tane, kutu...)
        public Measurement Measurement { get; set; }
        // Adet
        public int ProductBoxSize { get; set; }
        // Rengi
        public int ProductColor { get; set; } // 0 - Tüm renkler demek
        // Hammadde
        public int ResourceId { get; set; }
        public String ProductDescription { get; set; }

        // Diğerleri
        public double BuyPrice { get; set; }
        // Ürüne bağlı olarak kar miktarı
        public double ProfitRate { get; set; }
        public int ProductStock { get; set; }


        //Object[] paramArray = new Object[12];

        public Product(Object[] paramArray)
        {
            setValues(paramArray);

            // insert
            String sql = "insert into product (category_id, sub_category_id, product_size, measurement_id, product_box_size, product_color,"
                +" resource_id,product_description,buy_price,profit_rate,product_stock)"
                +" values"
                +" (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11)";

            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@1", Category.getId());
            cmd.Parameters.AddWithValue("@2", SubCategory.getId());
            cmd.Parameters.AddWithValue("@3", ProductSize);
            cmd.Parameters.AddWithValue("@4", Measurement.getId());
            cmd.Parameters.AddWithValue("@5", ProductBoxSize);
            cmd.Parameters.AddWithValue("@6", ProductColor);
            cmd.Parameters.AddWithValue("@7", ResourceId);
            cmd.Parameters.AddWithValue("@8", ProductDescription);
            cmd.Parameters.AddWithValue("@9", BuyPrice);
            cmd.Parameters.AddWithValue("@10", ProfitRate);
            cmd.Parameters.AddWithValue("@11", ProductStock);

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
       


        public void setValues(Object[] paramArray)
        {
            for (int i = 0; i < paramArray.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        Category = new Category((int)paramArray[i]);                                               
                        break;
                    case 1:
                        SubCategory = new SubCategory((int)paramArray[i]);
                        break;
                    case 2:
                        ProductSize = (String)paramArray[i];
                        break;
                    case 3:
                        Measurement = new Measurement((int)paramArray[i]);
                        break;
                    case 4:
                        ProductBoxSize = (int)paramArray[i];
                        break;
                    case 5:
                        ProductColor = (int)paramArray[i];
                        break;
                    case 6:
                        ResourceId = (int)paramArray[i];
                        break;
                    case 7:
                        ProductDescription = (String)paramArray[i];
                        break;
                    case 8:
                        BuyPrice = (double)paramArray[i];
                        break;
                    case 9:
                        ProfitRate = (double)paramArray[i];
                        break;
                    case 10:
                        ProductStock = (int)paramArray[i];
                        break;
                    default:
                        break;
                }
            }

        }


    }
    
}