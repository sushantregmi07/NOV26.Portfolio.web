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
    public class ProjectModelsController : Controller
    {
        private readonly NOV26PortfoliowebContext _context;

        public ProjectModelsController(NOV26PortfoliowebContext context)
        {
            _context = context;
        }

        // GET: ProjectModels
        public async Task<IActionResult> Index()
        {
            var nOV26PortfoliowebContext = _context.ProjectModel.Include(p => p.Service);
            return View(await nOV26PortfoliowebContext.ToListAsync());
        }

        // GET: ProjectModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectModel = await _context.ProjectModel
                .Include(p => p.Service)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectModel == null)
            {
                return NotFound();
            }

            return View(projectModel);
        }

        // GET: ProjectModels/Create
        public IActionResult Create()
        {
            ViewData["ServiceId"] = new SelectList(_context.ServiceModel, "Id", "Title");
            return View();
        }

        // POST: ProjectModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Width,ClientName,ServiceId")] ProjectModel projectModel, IFormFile ProjectImageUrl)
        {
            if (ProjectImageUrl != null && ProjectImageUrl.Length > 0)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", ProjectImageUrl.FileName);
                //Using Buffering
                using (var stream = System.IO.File.Create(filePath))
                {
                    //The file is saved in a buffer before being processed
                    await ProjectImageUrl.CopyToAsync(stream);
                }
                projectModel.ProjectImageUrl = "/uploads/" + ProjectImageUrl.FileName;
            }
            if (ModelState.IsValid)
            {
                
                _context.Add(projectModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ServiceId"] = new SelectList(_context.ServiceModel, "Id", "Title", projectModel.ServiceId);
            return View(projectModel);
        }

        // GET: ProjectModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectModel = await _context.ProjectModel.FindAsync(id);
            if (projectModel == null)
            {
                return NotFound();
            }
            ViewData["ServiceId"] = new SelectList(_context.ServiceModel, "Id", "Title", projectModel.ServiceId);
            return View(projectModel);
        }

        // POST: ProjectModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Width,ClientName,ServiceId")] ProjectModel projectModel, IFormFile ProjectImageUrl)
        {
            if (id != projectModel.Id)
            {
                return NotFound();
            }
            if (ProjectImageUrl != null && ProjectImageUrl.Length > 0)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", ProjectImageUrl.FileName);
                //Using Buffering
                using (var stream = System.IO.File.Create(filePath))
                {
                    //The file is saved in a buffer before being processed
                    await ProjectImageUrl.CopyToAsync(stream);
                }
                projectModel.ProjectImageUrl = "/uploads/" + ProjectImageUrl.FileName;
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectModelExists(projectModel.Id))
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
            ViewData["ServiceId"] = new SelectList(_context.ServiceModel, "Id", "Title", projectModel.ServiceId);
            return View(projectModel);
        }

        // GET: ProjectModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectModel = await _context.ProjectModel
                .Include(p => p.Service)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectModel == null)
            {
                return NotFound();
            }

            return View(projectModel);
        }

        // POST: ProjectModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projectModel = await _context.ProjectModel.FindAsync(id);
            if (projectModel != null)
            {
                _context.ProjectModel.Remove(projectModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectModelExists(int id)
        {
            return _context.ProjectModel.Any(e => e.Id == id);
        }
    }
}
