using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCore.CodeFirst.Entities.Concrete
{

    // Şuan bir default ef configurasyonu çalışır .
    // İsim -> Products , proplar birebir
    // Id veya ProductId -> otomatik primary key tanımlanır


    // Tablo adı ve sema alttaki gibi değişir.
    // Data Annotations
    // [Table("ProductTb",Schema ="products")]

    //[Index(nameof(Name), nameof(Price))] // composite index ilk yazılan kolon daha hızlı çalışıyor
    [Index(nameof(Name))]
   // [Index(nameof(Price))]
    public class Product
    {
        //pk lara sql server tarafından clustered index atar
        //fk lara da otomatik atanır
        public int Id { get; set; }
        public string Name { get; set; }

        [Precision(9,2)]
        public decimal Price { get; set; }
        [Precision(9,2)]
        public decimal DiscountPrice { get; set; }
        public int Stock { get; set; }
        public int Barcode { get; set; }
        public virtual ProductFeature ProductFeature { get; set; }

        // Ef bunu otomatik foreign key olarak anlayabiliyor ->CategoryId
        // Farklı bi isim istermsem tanımlamam lazım FluentAPI , Data An.
        public int CategoryId { get; set; }

        //Navigation property
        //[ForeignKey("Category_Id")]
        public virtual Category Category { get; set; }
    }
}
