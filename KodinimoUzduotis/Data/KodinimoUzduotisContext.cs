using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KodinimoUzduotis.Models;
using Microsoft.Extensions.Logging;

namespace KodinimoUzduotis.Data
{
    public class KodinimoUzduotisContext : DbContext
    {
        public KodinimoUzduotisContext (DbContextOptions<KodinimoUzduotisContext> options)
            : base(options)
        {
        }

        public DbSet<CodeSolution> CodeSolutions { get; set; }
        public DbSet<Player> Players { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=codesolve.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CodeSolution>()
                .HasData(
                new CodeSolution
                {
                    Id = 1,
                    Name = "Fibonacci",
                    Description = "Fibonacci sequence, such that each number is the sum of the two preceding ones, starting from 0 and 1",
                    Solution = "<?php $n=10; echo round(pow((sqrt(5)+1)/2, $n) / sqrt(5)); ?>"
                },
                new CodeSolution
                {
                    Id = 2,
                    Name = "Digit sum",
                    Description = "Sum of digits of a number just add all the digits.",
                    Solution = "<?php $num = 14597;  $sum = 0; $rem = 0; for ($i = 0; $i <= strlen($num);$i++)  {  $rem =$num % 10;  $sum = $sum + $rem;  $num =$num / 10; } echo $sum;  ?>"
                },
                new CodeSolution
                {
                    Id = 3,
                    Name = "Reverse number",
                    Description = "A number can be written in reverse order.",
                    Solution = "<?php  $num = 23456;  $revnum = 0; while ($num > 1)  {  $rem = $num % 10;  $revnum = ($revnum * 10) + $rem;  $num = ($num / 10) } echo $revnum;  ?>",
                }
                ); 
        }
    }
}
