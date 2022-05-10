using Microsoft.EntityFrameworkCore;
using System;
using WebAPITest.Models;

public class ApplicationDbContext : DbContext
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> Options) : base(Options)
	{
	}

	public DbSet<NationalPark> NationalParks { get; set; }
}