using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NOV26.Portfolio.web.Data;
using NOV26.Portfolio.web.Models;

namespace NOV26.Portfolio.web.Controllers
{
    public class BlogModelsController : Controller
    {
        private readonly NOV26PortfoliowebContext _context;

        public BlogModelsController(NOV26PortfoliowebContext context)
        {
            _context = context;
        }

        // GET: BlogModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.BlogModel.ToListAsync());
        }

        // GET: BlogModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogModel = await _context.BlogModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blogModel == null)
            {
                return NotFound();
            }

            return View(blogModel);
        }

        // GET: BlogModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BlogModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ImageUrl,Paragraph1,Paragraph2")] BlogModel blogModel, IFormFile ImageUrl)
        {
            if (ImageUrl != null && ImageUrl.Length > 0)
            {
                string filename = new Guid().ToString()+ "." + ImageUrl.FileName.Split('.').Last();
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", ImageUrl.FileName);
                //Using Buffering
                using (var stream = System.IO.File.Create(filePath))
                {
                    //The file is saved in a buffer before being processed
                    await ImageUrl.CopyToAsync(stream);
                }
                blogModel.ImageUrl = "/uploads/" + ImageUrl.FileName;
            }
            if (ModelState.IsValid)
            {
                _context.Add(blogModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(blogModel);
        }

        // GET: BlogModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogModel = await _context.BlogModel.FindAsync(id);
            if (blogModel == null)
            {
                return NotFound();
            }
            return View(blogModel);
        }

        // POST: BlogModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ImageUrl,Paragraph1,Paragraph2")] BlogModel blogModel)
        {
            if (id != blogModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blogModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogModelExists(blogModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(blogModel);
        }

        // GET: BlogModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogModel = await _context.BlogModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blogModel == null)
            {
                return NotFound();
            }

            return View(blogModel);
        }

        // POST: BlogModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blogModel = await _context.BlogModel.FindAsync(id);
            if (blogModel != null)
            {
                _context.BlogModel.Remove(blogModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BlogModelExists(int id)
        {
            return _context.BlogModel.Any(e => e.Id == id);
        }
    }
}
