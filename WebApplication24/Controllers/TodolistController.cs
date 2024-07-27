using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication24.Models;

namespace WebApplication24.Controllers
{
    public class TodolistController : Controller
    {
        Mycon con;
        public TodolistController(Mycon _con)
        {
            this.con = _con;
        }
        public async Task<IActionResult> Index()
        {
            var data = await con.tbl_todolist.ToListAsync();
            return View(data);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,title,iscomplete")]Todolist tbl)
        {
            if (ModelState.IsValid)
            {
                await con.tbl_todolist.AddAsync(tbl);
                await con.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tbl);
        }
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var data = await con.tbl_todolist.FindAsync(id);
            return View(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("id,title,iscomplete")] Todolist tbl,int id)
        {
            if (id != tbl.id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                con.tbl_todolist.Update(tbl);
                await con.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tbl);
        }
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var data = await con.tbl_todolist.Where(a => a.id == id).FirstOrDefaultAsync();
            return View(data);
        }
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> dlt(int id)
        {
            var data = await con.tbl_todolist.FindAsync(id);
            con.tbl_todolist.Remove(data);
            await con.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        private  bool todolistexists(int id)
        {
            return con.tbl_todolist.Any(a => a.id == id);           
        }
    }
}
