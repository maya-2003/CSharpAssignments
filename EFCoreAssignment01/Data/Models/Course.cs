using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreAssignment01.Data.Models
{
    [Table("Courses")]
    internal class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DataType(DataType.Duration)]
        public TimeSpan Duration { get; set; }
        [Column(TypeName = "varchar(50)")]
        [StringLength(50)]
        public string Name { get; set; }
        [Column(TypeName = "varchar(200)")]
        [StringLength(200)]
        public string Description { get; set; }
        public int TopicId { get; set; }
        public required Topic Topic { get; set; }
    }
}
