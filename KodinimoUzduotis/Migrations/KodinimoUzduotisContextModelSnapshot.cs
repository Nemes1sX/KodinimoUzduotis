﻿// <auto-generated />
using KodinimoUzduotis.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KodinimoUzduotis.Migrations
{
    [DbContext(typeof(KodinimoUzduotisContext))]
    partial class KodinimoUzduotisContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("KodinimoUzduotis.Models.CodeSolution", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Solution")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("CodeSolutions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Fibonacci sequence, such that each number is the sum of the two preceding ones, starting from 0 and 1",
                            Name = "Fibonacci",
                            Solution = "<?php $n=10; echo round(pow((sqrt(5)+1)/2, $n) / sqrt(5)); ?> "
                        },
                        new
                        {
                            Id = 2,
                            Description = "Sum of digits of a number just add all the digits.",
                            Name = "Digit sum",
                            Solution = "<?php $num = 14597;  $sum = 0; $rem = 0; for ($i = 0; $i <= strlen($num);$i++)  {  $rem =$num % 10;  $sum = $sum + $rem;  $num =$num / 10; } echo $sum; } ?>"
                        },
                        new
                        {
                            Id = 3,
                            Description = "A number can be written in reverse order.",
                            Name = "Reverse number",
                            Solution = "<?php  $num = 23456;  $revnum = 0; while ($num > 1)  {  $rem = $num % 10;  $revnum = ($revnum * 10) + $rem;  $num = ($num / 10) } echo $revnum;  ?>"
                        });
                });

            modelBuilder.Entity("KodinimoUzduotis.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Success")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
