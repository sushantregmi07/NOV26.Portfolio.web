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
    public class ResumeModelsController : Controller
    {
        private readonly NOV26PortfoliowebContext _context;

        public ResumeModelsController(NOV26PortfoliowebContext context)
        {
            _context = context;
        }

        // GET: ResumeModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.ResumeModel.ToListAsync());
        }

        // GET: ResumeModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resumeModel = await _context.ResumeModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (resumeModel == null)
            {
                return NotFound();
            }

            return View(resumeModel);
        }

        // GET: ResumeModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ResumeModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StartYear,EndYear,Title,InstitutionName,Description")] ResumeModel resumeModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resumeModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(resumeModel);
        }

        // GET: ResumeModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resumeModel = await _context.ResumeModel.FindAsync(id);
            if (resumeModel == null)
            {
                return NotFound();
            }
            return View(resumeModel);
        }

        // POST: ResumeModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StartYear,EndYear,Title,InstitutionName,Description")] ResumeModel resumeModel)
        {
            if (id != resumeModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resumeModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResumeModelExists(resumeModel.Id))
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
            return View(resumeModel);
        }

        // GET: ResumeModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resumeModel = await _context.ResumeModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (resumeModel == null)
            {
                return NotFound();
            }

            return View(resumeModel);
        }

        // POST: ResumeModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resumeModel = await _context.ResumeModel.FindAsync(id);
            if (resumeModel != null)
            {
                _context.ResumeModel.Remove(resumeModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResumeModelExists(int id)
        {
            return _context.ResumeModel.Any(e => e.Id == id);
        }
    }
}
