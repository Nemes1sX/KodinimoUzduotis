using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KodinimoUzduotis.Models
{
    public class Player
    {
        [Key]
       public int Id { get; set; }
        [Required(ErrorMessage = "Player name is required")]
        public string Name { get; set; } 
        [NotMapped]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [DefaultValue(0)]
        [Display(Name = "Successfull solutions")]
        public int Success { get; set; }

       [NotMapped]
        public List<CodeSolution> CodeSolutions { get; set; }

    }
}
