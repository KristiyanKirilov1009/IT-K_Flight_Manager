// See https://aka.ms/new-console-template for more information
using FlightManager.Data;
using FlightManager.Models;
using System.Reflection.Metadata;

FlightContext flightContext= new FlightContext();

User user = new User("Kikich", "12345", "Kristiyan", "Kirilov", "12345678", "at home", 08789, "Bulgarian", Roles.Admin);
flightContext.Users.Add(user);
flightContext.SaveChanges();
