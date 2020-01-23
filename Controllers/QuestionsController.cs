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
    public class QuestionsController : Controller
    {
        private readonly Tech_Question_and_answer_DataContext _context;

        public QuestionsController(Tech_Question_and_answer_DataContext context)
        {
            _context = context;
        }

        // GET: Questions
        public async Task<IActionResult> Index()
        {
            var tech_Question_and_answer_DataContext = _context.Question.Include(q => q.ForumMember);
            return View(await tech_Question_and_answer_DataContext.ToListAsync());
        }

        // GET: Questions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Question
                .Include(q => q.ForumMember)
                .FirstOrDefaultAsync(m => m.Id == id);

            var answers = await _context.Answer.Where(a => a.QuestionId == question.Id).Include(a=>a.ForumMember).ToListAsync();

            if (question == null)
            {
                return NotFound();
            }

            QuestionAndAnswers qa = new QuestionAndAnswers();

            qa.Answers = answers;
            qa.Question = question;
            return View(qa);
        }

        // GET: Questions/Create
        public IActionResult Create()
        {
            var forumUser = (from user in _context.ForumMember
                             where user.Email.Equals(User.Identity.Name)
                             select user).First();

          

            ViewData["ForumMemberId"] = forumUser.Id;

        
            return View();
        }

        // POST: Questions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Details,ForumMemberId")] Question question)
        {
            if (ModelState.IsValid)
            {
                _context.Add(question);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ForumMemberId"] = new SelectList(_context.ForumMember, "Id", "Id", question.ForumMemberId);
            return View(question);
        }

        // GET: Questions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Question.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }

            var forumUser = (from user in _context.ForumMember
                             where user.Email.Equals(User.Identity.Name)
                             select user).First();

            ViewData["ForumMemberId"] = forumUser.Id;
            return View(question);
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Details,ForumMemberId")] Question question)
        {
            if (id != question.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(question);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionExists(question.Id))
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
            var forumUser = (from user in _context.ForumMember
                             where user.Email.Equals(User.Identity.Name)
                             select user).First();

            ViewData["ForumMemberId"] = forumUser.Id;
            return View(question);
        }

        // GET: Questions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Question
                .Include(q => q.ForumMember)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var question = await _context.Question.FindAsync(id);
            _context.Question.Remove(question);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionExists(int id)
        {
            return _context.Question.Any(e => e.Id == id);
        }
    }
}
