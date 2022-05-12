using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Game
    {
        [Key]
        public int ID { get; private set; }

        [Required]
        [MaxLength(20)]
        public string Name{ get; set; }

        
        public IEnumerable<User> Users { get; set; }

        public IEnumerable<Genre> Gernes { get; set; }

        private Game()
        {

        }

        public Game(string name)
        {
            Name = name;
            
        }
    }
}
