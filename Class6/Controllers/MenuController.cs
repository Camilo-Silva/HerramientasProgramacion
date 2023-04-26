using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Class6.Data;
using Class6.Models;
using Class6.ViewModels;

namespace Class6.Controllers
{
    public class MenuController : Controller
    {
        private readonly MenuContext _context;

        public MenuController(MenuContext context)
        {
            _context = context;
        }

        // GET: Menu
        // Asignamos para que por parametro busque un nameFilter
        // Se arma query de busqueda de menu en el conxto menu
        // Hacemos un condicional if para validar que si no es vacio, o se si tiene un dato de name, entre a la
        // query con el where que contenga el name en la propiedad x.Name
        // Retorna una view para ejecutar la query que hicimos.
        public async Task<IActionResult> Index(string NameFilter)
        {
            var query = from menu in _context.Menu select menu;

            if (!string.IsNullOrEmpty(NameFilter))
            {
                query = query.Where(x => x.Name.Contains(NameFilter));
            }
            // El ToList, solo es para verlo en el debugger
            var restaurants = query.Include(x => x.Restaurants).Select(x => x.Restaurants).ToList();
            // Llenamos de elementos al menuViewModel
            var model = new MenuViewModel();
            model.Menus = await query.ToListAsync();

            return _context.Menu != null ?
                        View(model) :
                        Problem("Entity set 'MenuContext.Menu'  is null.");
        }

        // GET: Menu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Menu == null)
            {
                return NotFound();
            }

            var menu = await _context.Menu.Include(x=> x.Restaurants).FirstOrDefaultAsync(m => m.Id == id);
            if (menu == null)
            {
                return NotFound();
            }

            var viewModel = new MenuDetailViewModel();
            viewModel.Name = menu.Name;
            viewModel.Type = menu.Type.ToString();
            viewModel.Calories = menu.Calories;
            viewModel.IsVegetarianType = menu.IsVegetarianType;
            viewModel.Restaurants = menu.Restaurants !=null? menu.Restaurants : new List<Restaurant>();

            return View(viewModel);
        }

        // GET: Menu/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Menu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Type,IsVegetarianType,Calories")] Menu menu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(menu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(menu);
        }

        // GET: Menu/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Menu == null)
            {
                return NotFound();
            }

            var menu = await _context.Menu.FindAsync(id);
            if (menu == null)
            {
                return NotFound();
            }
            return View(menu);
        }

        // POST: Menu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Type,IsVegetarianType,Calories")] Menu menu)
        {
            if (id != menu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(menu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuExists(menu.Id))
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
            return View(menu);
        }

        // GET: Menu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Menu == null)
            {
                return NotFound();
            }

            var menu = await _context.Menu
                .FirstOrDefaultAsync(m => m.Id == id);
            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }

        // POST: Menu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Menu == null)
            {
                return Problem("Entity set 'MenuContext.Menu'  is null.");
            }
            var menu = await _context.Menu.FindAsync(id);
            if (menu != null)
            {
                _context.Menu.Remove(menu);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenuExists(int id)
        {
            return (_context.Menu?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
