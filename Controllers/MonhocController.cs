using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BTLNhom8.Models;
using BTLNhom8.Models.Process;

namespace BTLNhom8.Controllers
{
    public class MonhocController : Controller
    {
        private readonly ApplicationDbContext _context;
        private ExcelProcess _excelProcess = new ExcelProcess();

        public MonhocController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Monhoc
        public async Task<IActionResult> Index()
        {
              return _context.Monhoc != null ? 
                          View(await _context.Monhoc.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Monhoc'  is null.");
        }

        // GET: Monhoc/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Monhoc == null)
            {
                return NotFound();
            }

            var monhoc = await _context.Monhoc
                .FirstOrDefaultAsync(m => m.Ma_mon == id);
            if (monhoc == null)
            {
                return NotFound();
            }

            return View(monhoc);
        }

        // GET: Monhoc/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Monhoc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Ma_mon,Ten_mon")] Monhoc monhoc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(monhoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(monhoc);
        }

        // GET: Monhoc/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Monhoc == null)
            {
                return NotFound();
            }

            var monhoc = await _context.Monhoc.FindAsync(id);
            if (monhoc == null)
            {
                return NotFound();
            }
            return View(monhoc);
        }

        // POST: Monhoc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Ma_mon,Ten_mon")] Monhoc monhoc)
        {
            if (id != monhoc.Ma_mon)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(monhoc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonhocExists(monhoc.Ma_mon))
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
            return View(monhoc);
        }

        // GET: Monhoc/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Monhoc == null)
            {
                return NotFound();
            }

            var monhoc = await _context.Monhoc
                .FirstOrDefaultAsync(m => m.Ma_mon == id);
            if (monhoc == null)
            {
                return NotFound();
            }

            return View(monhoc);
        }

        // POST: Monhoc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Monhoc == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Monhoc'  is null.");
            }
            var monhoc = await _context.Monhoc.FindAsync(id);
            if (monhoc != null)
            {
                _context.Monhoc.Remove(monhoc);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MonhocExists(string id)
        {
          return (_context.Monhoc?.Any(e => e.Ma_mon == id)).GetValueOrDefault();
        }
        // uploading
          public async Task<IActionResult>Upload()
        {
            return View();
        }
        [HttpPost]
          [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upload(IFormFile file){

            if(file != null){
                string fileExtension = Path.GetExtension(file.FileName);
                if(fileExtension != ".xls" && fileExtension != ".xlsx")
                {
                    ModelState.AddModelError("","Please choose excel file to upload!");
                }
                else{
                    var fileName = DateTime.Now.ToShortTimeString() + fileExtension;
                    var filePath = Path.Combine(Directory.GetCurrentDirectory() + "/Upload/Excels", fileName);
                    var fileLocation = new FileInfo(filePath).ToString();
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);

                        var dt = _excelProcess.ExcelToDataTable(fileLocation);
                        for(int i = 0; i< dt.Rows.Count; i++)
                        {
                            var emp = new Monhoc();

                            emp.Ma_mon = dt.Rows[i][0].ToString();
                            emp.Ten_mon = dt.Rows[i][1].ToString();

                            _context.Monhoc.Add(emp);
                        } 

                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            return View();
        }
    }
}
