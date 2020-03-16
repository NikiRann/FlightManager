using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FlightManager1.Models;
using Microsoft.AspNetCore.Identity;
using FlightManager1.Data;
using Microsoft.EntityFrameworkCore;
using FlightManager1.Data.Models;
using System.Web;
using PagedList;

namespace FlightManager1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly RoleManager<IdentityRole> roleManager;

        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, RoleManager<IdentityRole> roleManager, ApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            this.roleManager = roleManager;
            this._context = applicationDbContext;
        }

        public async Task<IActionResult> Index()
        {
            IdentityRole userRole = new IdentityRole() { Id = Guid.NewGuid().ToString(), Name = "User" };
          
            IdentityRole adminRole = new IdentityRole() { Id = Guid.NewGuid().ToString(), Name = "Admin" };

           
            await this.roleManager.CreateAsync(userRole);
            await this.roleManager.CreateAsync(adminRole);

            if (this.User.Identity.IsAuthenticated)
            {
                if (this.User.IsInRole("User"))
                {
                    return this.View("UserView", await _context.Flights.ToListAsync());
                }
 
                if (this.User.IsInRole("Admin"))
                {
                    return this.View("AdminView", await _context.Flights.ToListAsync());
                }
            }
      
            
            return View(await _context.Flights.ToListAsync());
        }
        public async Task<IActionResult> ReserveAsync(String id)
        {

            ViewBag.Message = id;

            return View("../Reservations/Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FlightId,FirstName,SecondName,LastName,PIN,PhoneNumber,Nationality,TypeOfTicket")] Reservation reservation)
        {
            reservation.Id = Guid.NewGuid().ToString();
            
            Console.WriteLine(reservation.FlightId);
          
            var flight = await _context.Flights
                .FirstOrDefaultAsync(m => m.Id == reservation.FlightId);

            if (reservation.TypeOfTicket == "VIP")
            {
                if (!flight.BuisnessClassCapacity.Equals(0))
                {
                    flight.BuisnessClassCapacity--;
                    flight.PlaneCapacity--;
                }
                else
                {
                    return View("FullPlaneView");
                }
            }
            else
            {
                if (flight.PlaneCapacity == flight.BuisnessClassCapacity)
                    return View("FullPlaneView");
                else
                    flight.PlaneCapacity--;
            }
            
            if (ModelState.IsValid)
            {
                _context.Add(reservation);
                await _context.SaveChangesAsync();
                return View("CompleteReservation");
            }
            return View(reservation);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
