using core.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("TO_ITEM")]
    public class ToItem: BaseModel
    {
        [Column("NAME")]
        public string? Name { get; set; }
        [Column("SEX")]
        public bool Sex { get; set; }
    }
}
