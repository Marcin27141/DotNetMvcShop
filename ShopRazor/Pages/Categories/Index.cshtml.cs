﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShopRazor.Database;
using ShopRazor.Models.Database;

namespace ShopRazor.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ShopRazor.Models.Database.ShopDbContext _context;

        public IndexModel(ShopRazor.Models.Database.ShopDbContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Category = await _context.Categories.ToListAsync();
        }
    }
}
