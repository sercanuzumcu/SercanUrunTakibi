using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SercanUrunTakibi.Models
{
    public class Product
    {
/*
    Örnek Ürün, erkanplastik.com.tr'dan alınmıştır.
 * Standart kılçık:
 * Ölçü: 8mm,10mm...
 * Birim: Kutu (1 olarak geçiyor sitede ama kutu,kilo,poşet  olması lazım)
 * Adet: 10000 (Bir kutunun içerisindeki kılçık miktarı)
 * Renkler: Tüm Renkler
 * Hammadde: P.P. Naylon 
 */
        public int ProductId { get; set; }

        // Websitesi datası
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        // Ölçü (int değil çünkü ölçü olarak "Standart" gelebiliyor)
        public String ProductSize { get; set; }        
        // Ölçüm Birimi (Kilo, tane, kutu...)
        public int MeasurementId { get; set; }
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

        public bool IsActive { get; set; }
    }
}