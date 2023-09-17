using System.ComponentModel.DataAnnotations;
namespace core.Models
{
    [Serializable]
    public abstract class BaseModel
    {
        /// <summary>
        /// id
        /// </summary>
        [Key]
        public long Id { get; set; } = 0;

    }
}
