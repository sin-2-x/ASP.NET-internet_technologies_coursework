using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_MVC.Data;

namespace Web_MVC.Controllers {
  public class StatisticsController : Controller {
    private readonly Web_MVCContext _context;

    public StatisticsController(Web_MVCContext context) {
      _context = context;
    }

    // GET: Categories
    public async Task<IActionResult> Index() {
      return _context.Categories != null ?
                  View(/*await _context.Category.ToListAsync()*/) :
                  Problem("Entity set 'Web_MVCContext.Category'  is null.");
    }

    /*// GET: Categories/Details/5
    public async Task<IActionResult> Details(long? id)
    {
        if (id == null || _context.Category == null)
        {
            return NotFound();
        }

        var category = await _context.Category
            .FirstOrDefaultAsync(m => m.IdCategory == id);
        if (category == null)
        {
            return NotFound();
        }

        return View(category);
    }

    // GET: Categories/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Categories/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("IdCategory,IdUser,NameCategory,UsedCountCategory")] Category category)
    {
        if (ModelState.IsValid)
        {
            _context.Add(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(category);
    }

    // GET: Categories/Edit/5
    public async Task<IActionResult> Edit(long? id)
    {
        if (id == null || _context.Category == null)
        {
            return NotFound();
        }

        var category = await _context.Category.FindAsync(id);
        if (category == null)
        {
            return NotFound();
        }
        return View(category);
    }

    // POST: Categories/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(long id, [Bind("IdCategory,IdUser,NameCategory,UsedCountCategory")] Category category)
    {
        if (id != category.IdCategory)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(category);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(category.IdCategory))
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
        return View(category);
    }

    // GET: Categories/Delete/5
    public async Task<IActionResult> Delete(long? id)
    {
        if (id == null || _context.Category == null)
        {
            return NotFound();
        }

        var category = await _context.Category
            .FirstOrDefaultAsync(m => m.IdCategory == id);
        if (category == null)
        {
            return NotFound();
        }

        return View(category);
    }

    // POST: Categories/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(long id)
    {
        if (_context.Category == null)
        {
            return Problem("Entity set 'Web_MVCContext.Category'  is null.");
        }
        var category = await _context.Category.FindAsync(id);
        if (category != null)
        {
            _context.Category.Remove(category);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool CategoryExists(long id)
    {
        return (_context.Category?.Any(e => e.IdCategory == id)).GetValueOrDefault();
    }*/
  }
}
