using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models;
using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Data
{
    public class SeedingService
    {
        private SalesWebMvcContext _context;

        public SeedingService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if(_context.Department.Any() || _context.Seller.Any() || _context.SalesRecord.Any())
            {
                return; // DB já foi polupado
            }

            Department dep = new Department(1, "Computers");
            Department dep1 = new Department(2, "Eletronics");
            Department dep2 = new Department(3, "Fashion");
            Department dep3 = new Department(4, "Books");

            Seller seller = new Seller(1, "Bob Brown", "bob@gmail.com", new DateTime(1998, 4, 21), 1500, dep);
            Seller seller1 = new Seller(2, "Maria", "maria@gmail.com", new DateTime(1996, 5, 25), 1200.00, dep1);
            Seller seller2 = new Seller(3, "Alex", "alex@gmail.com", new DateTime(1985, 02, 10), 1800.00, dep1);
            Seller seller3 = new Seller(4, "Joana", "joana@gmail.com", new DateTime(1999, 07, 13), 1800.00, dep3);
            Seller seller4 = new Seller(5, "Joao", "joao@gmail.com", new DateTime(1999, 07, 14), 1800.00, dep2);

            SalesRecord salesRecord = new SalesRecord(1, new DateTime(2018, 09, 25), 11000.0, SaleStatus.Builled, seller);
            SalesRecord salesRecord1 = new SalesRecord(2, new DateTime(2018, 09, 26), 10050.0, SaleStatus.Builled, seller3);
            SalesRecord salesRecord2 = new SalesRecord(3, new DateTime(2018, 09, 26), 7050.0, SaleStatus.Builled, seller1);
            SalesRecord salesRecord3 = new SalesRecord(4, new DateTime(2018, 09, 26), 60050.0, SaleStatus.Builled, seller2);
            SalesRecord salesRecord4 = new SalesRecord(5, new DateTime(2018, 09, 26), 40050.0, SaleStatus.Builled, seller4);

            _context.AddRange(dep, dep1, dep2, dep3);
            _context.AddRange(seller, seller1, seller2, seller3, seller4);
            _context.AddRange(salesRecord, salesRecord1, salesRecord2, salesRecord3, salesRecord4);

            _context.SaveChanges();
        }
    }
}
