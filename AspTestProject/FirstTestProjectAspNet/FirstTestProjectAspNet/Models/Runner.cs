using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FirstTestProjectAspNet.Models
{
    public class RunnerContext:DbContext
    {
        public RunnerContext()
            : base("CompactDB")
        { }
        public DbSet<Runner> Runners { get; set; }
    }

    [Table("Runner")]
    public class Runner
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Display(Name="Номер")]
        public int Id { get; set; }
        [Display(Name = "Имя")]
        public string FirstName { get; set; }
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
        [Display(Name = "Возраст")]
        public int Age { get; set; }
        [Display(Name = "Название клуба")]
        public string NameClub { get; set; }
    }
}