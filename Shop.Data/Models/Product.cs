using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Shop.Data.Models;

public class Product
{
    public int ProductID { get; set; }
    [Required, StringLength(50)]  public string Name { get; set; }
    [Required, StringLength(50)]  public string Category { get; set; }
    [Column(TypeName = "decimal(10,2)"), Range(0.01, 100000, ErrorMessage = "Price must be positive.")]  public decimal Price { get; set; }
}
