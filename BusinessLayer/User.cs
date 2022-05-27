using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class User
    {

        [Key]
        public int ID { get; private set; }

        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }

        [Required]
        [Range(10, 80)]
        public byte Age { get; set; }

        [Required]
        [MaxLength(20)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(70)]
        public string Password { get; set; }

        [Required]
        [MaxLength(20)]
        public string EMail { get; set; }

        public IEnumerable<User> Friends { get; set; }

        public IEnumerable<Game> Games { get; set; }

        

        private User()
        {

        }
        public User(string firstName, string lastName, byte age, string userName, string password, string eMail)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            UserName = userName;
            Password = password;
            EMail = eMail;
            
        }
        public User(int id, string firstName, string lastName, byte age, string userName, string password, string eMail)
            : this(firstName, lastName, age, userName, password, eMail)
        {
            this.ID = id;
        }

    }
}
