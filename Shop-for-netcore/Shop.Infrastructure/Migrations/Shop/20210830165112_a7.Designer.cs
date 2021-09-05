﻿#if NET5_0
// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shop.Ef;

namespace Shop.Migrations.Shop
{
    [DbContext(typeof(ShopDbContext))]
    [Migration("20210830165112_a7")]
    partial class a7
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.6");

            modelBuilder.Entity("Shop.Domain.Entities.EmailNotifyProduct", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Account")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("account");

                    b.Property<long?>("BuyerId")
                        .HasMaxLength(50)
                        .HasColumnType("INTEGER")
                        .HasColumnName("buyer_id");

                    b.Property<DateTime>("Notifydate")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("notifydate");

                    b.Property<string>("ProductID")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("product_i_d");

                    b.Property<string>("ProductName")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("product_name");

                    b.Property<string>("ReceiveEmail")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("receive_email");

                    b.Property<long?>("SellerId")
                        .HasMaxLength(50)
                        .HasColumnType("INTEGER")
                        .HasColumnName("seller_id");

                    b.Property<int>("SendFailureCount")
                        .HasMaxLength(50)
                        .HasColumnType("INTEGER")
                        .HasColumnName("send_failure_count");

                    b.Property<char>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("status");

                    b.HasKey("Id")
                        .HasName("id");

                    b.ToTable("t_email_notify_product");
                });
#pragma warning restore 612, 618
        }
    }
}
#endif