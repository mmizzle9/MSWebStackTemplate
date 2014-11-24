using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLibrary.Models
{
    [Table("TestTable")]
    public class TestModel
    {
        [Key]
        public int Id { get; set; }
        [Column]
        public string Column1 { get; set; }
        [Column]
        public string Column2 { get; set; }
    }
}
