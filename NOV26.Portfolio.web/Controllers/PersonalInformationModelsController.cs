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
    public class PersonalInformationModelsController : Controller
    {
        private readonly NOV26PortfoliowebContext _context;

        public PersonalInformationModelsController(NOV26PortfoliowebContext context)
        {
            _context = context;
        }

        // GET: PersonalInformationModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.PersonalInformationModel.ToListAsync());
        }

        // GET: PersonalInformationModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalInformationModel = await _context.PersonalInformationModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personalInformationModel == null)
            {
                return NotFound();
            }

            return View(personalInformationModel);
        }

        // GET: PersonalInformationModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonalInformationModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FullName,Address,Title,Summary,DOB,Email,ZipCode,Phone,CompletedProjects,UserPhotoUrl")] PersonalInformationModel personalInformationModel, IFormFile UserPhotoUrl)
        {
            if (UserPhotoUrl != null && UserPhotoUrl.Length > 0)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", UserPhotoUrl.FileName);
                //Using Buffering
                using (var stream = System.IO.File.Create(filePath))
                {
                    //The file is saved in a buffer before being processed
                    await UserPhotoUrl.CopyToAsync(stream);
                }
            }
            if (ModelState.IsValid)
            {
                personalInformationModel.UserPhotoUrl = "/uploads/" + UserPhotoUrl.FileName;
                _context.Add(personalInformationModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personalInformationModel);
        }

        // GET: PersonalInformationModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalInformationModel = await _context.PersonalInformationModel.FindAsync(id);
            if (personalInformationModel == null)
            {
                return NotFound();
            }
            return View(personalInformationModel);
        }

        // POST: PersonalInformationModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,Address,Title,Summary,DOB,Email,ZipCode,Phone,CompletedProjects,UserPhotoUrl")] PersonalInformationModel personalInformationModel)
        {
            if (id != personalInformationModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personalInformationModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonalInformationModelExists(personalInformationModel.Id))
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
            return View(personalInformationModel);
        }

        // GET: PersonalInformationModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalInformationModel = await _context.PersonalInformationModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personalInformationModel == null)
            {
                return NotFound();
            }

            return View(personalInformationModel);
        }

        // POST: PersonalInformationModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personalInformationModel = await _context.PersonalInformationModel.FindAsync(id);
            if (personalInformationModel != null)
            {
                _context.PersonalInformationModel.Remove(personalInformationModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonalInformationModelExists(int id)
        {
            return _context.PersonalInformationModel.Any(e => e.Id == id);
        }
    }
}
