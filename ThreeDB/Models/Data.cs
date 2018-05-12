using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ThreeDB.Models
{
    [Table("Datas")]
    public class Data
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
