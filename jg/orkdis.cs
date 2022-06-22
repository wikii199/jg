using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;



namespace orkdis 
{ 
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public string ConnectionString { get; }

        public DatabaseContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(this.ConnectionString);
        }

    }


    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int UserID { get; set; }

        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Pesel { get; set; }
        public string NrTel { get; set; }
        public string Haslo { get; set; }
        public decimal Saldo { get; set; }

    }

    public class Pieniadze
    {
        [Key]
        public int UserID { get; set; }
        public int Saldo { get; set; }
    }
}