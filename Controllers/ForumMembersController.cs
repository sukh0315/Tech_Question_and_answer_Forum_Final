using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tech_Question_and_answer_Forum_Final.Models;

namespace Tech_Question_and_answer_Forum_Final.Controllers
{
    [Authorize(Roles = "forum_member")]
    public class ForumMembersController : Controller
    {
        private readonly Tech_Question_and_answer_DataContext _context;

        public ForumMembersController(Tech_Question_and_answer_DataContext context)
        {
            _context = context;
        }

        // GET: ForumMembers
        public async Task<IActionResult> Index()
        {
            return View(await _context.ForumMember.ToListAsync());
        }

        // GET: ForumMembers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forumMember = await _context.ForumMember
                .FirstOrDefaultAsync(m => m.Id == id);
            if (forumMember == null)
            {
                return NotFound();
            }

            return View(forumMember);
        }

        // GET: ForumMembers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ForumMembers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Email,Name,Description")] ForumMember forumMember)
        {
            if (ModelState.IsValid)
            {
                _context.Add(forumMember);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(forumMember);
        }

        // GET: ForumMembers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forumMember = await _context.ForumMember.FindAsync(id);
            if (forumMember == null)
            {
                return NotFound();
            }
            return View(forumMember);
        }

        // POST: ForumMembers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Email,Name,Description")] ForumMember forumMember)
        {
            if (id != forumMember.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(forumMember);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ForumMemberExists(forumMember.Id))
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
            return View(forumMember);
        }

        // GET: ForumMembers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forumMember = await _context.ForumMember
                .FirstOrDefaultAsync(m => m.Id == id);
            if (forumMember == null)
            {
                return NotFound();
            }

            return View(forumMember);
        }

        // POST: ForumMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var forumMember = await _context.ForumMember.FindAsync(id);
            _context.ForumMember.Remove(forumMember);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ForumMemberExists(int id)
        {
            return _context.ForumMember.Any(e => e.Id == id);
        }
    }
}
