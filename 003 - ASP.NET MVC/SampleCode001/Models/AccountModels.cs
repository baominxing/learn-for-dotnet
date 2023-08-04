using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SampleCode001.Models
{
    public class UsersContext : DbContext
    {
        public UsersContext() : base("default")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
    }

    public class ApplicationContext : UsersContext
    {
        public ApplicationContext()
        {
        }


        public DbSet<Role> Roles { get; set; }

        public DbSet<UsersInRole> UsersInRoles { get; set; }
    }

    [Table("UserProfiles")]
    public class UserProfile
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [MaxLength(100)]
        public string UserName { get; set; }

        [MaxLength(100)]
        public string Sex { get; set; }

        public int Age { get; set; }
    }

    [Table("webpages_Roles")]
    public class Role
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int RoleId { get; set; }

        [MaxLength(256)]
        public string RoleName { get; set; }
    }

    [Table("webpages_UsersInRoles")]
    public class UsersInRole
    {
        [Key]
        [Column(Order = 0)]
        public int UserId { get; set; }

        [Key]
        [Column(Order = 1)]
        public int RoleId { get; set; }
    }
}