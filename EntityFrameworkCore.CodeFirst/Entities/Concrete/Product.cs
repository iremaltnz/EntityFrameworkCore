﻿using System;
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
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int Barcode { get; set; }

        // Ef bunu otomatik foreign key olarak anlayabiliyor ->CategoryId
        // Farklı bi isim istermsem tanımlamam lazım FluentAPI , Data An.
        public int Category_Id { get; set; }

        //Navigation property
        //[ForeignKey("Category_Id")]
        public Category Category { get; set; }
    }
}
