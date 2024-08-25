using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KlassyCafePostgreSql.DAL.Context;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KlassyCafePostgreSql.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly Context _context;

        public SignalRHub(Context context)
        {
            _context = context;
        }

        public async Task TableIsFullCount()
        {
            var value = _context.Tables.Where(i => i.TableIsFull).Count();
            await Clients.All.SendAsync("ReceiveTableIsFullCount", value);
        }

        public async Task ReservationCount()
        {
            var value = _context.Reservations.Count();
            await Clients.All.SendAsync("ReceiveReservationCount", value);
        }

        public async Task ProductCount()
        {
            var value = _context.Products.Count();
            await Clients.All.SendAsync("ReceiveProductCount", value);
        }

        public async Task CategoryCount()
        {
            var value = _context.Categories.Count();
            await Clients.All.SendAsync("ReceiveCategoryCount", value);
        }
    }
}