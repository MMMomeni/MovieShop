using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopMVC.Core.Entities
{
    public class MovieCast
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        [Required]
        public int CastId { get; set; }
        [Required]
        [Column(TypeName="varchar(450)")]
        public string Character { get; set; }

        public virtual Cast Cast { get; set; }
    }
}
