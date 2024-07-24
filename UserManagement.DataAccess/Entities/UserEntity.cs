using System;


namespace UserManagement.DataAccess.Entities
{
    public class UserEntity : BaseEntity
    {

        public string Name { get; set; }
        public string surName { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }

        public bool isActive  { get; set; } = true;

       
    }
}
