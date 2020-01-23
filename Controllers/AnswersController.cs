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
    [Authorize(Roles= "forum_member")]
    public class AnswersController : Controller
    {
        private readonly Tech_Question_and_answer_DataContext _context;

        public AnswersController(Tech_Question_and_answer_DataContext context)
        {
            _context = context;
        }

        // GET: Answers
        public async Task<IActionResult> Index()
        {
            var tech_Question_and_answer_DataContext = _context.Answer.Include(a => a.ForumMember).Include(a => a.Question);
            return View(await tech_Question_and_answer_DataContext.ToListAsync());
        }

        // GET: Answers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var answer = await _context.Answer
                .Include(a => a.ForumMember)
                .Include(a => a.Question)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (answer == null)
            {
                return NotFound();
            }

            return View(answer);
        }

        // GET: Answers/Create
        public IActionResult Create(int Id)
        {
            var forumUser = (from user in _context.ForumMember
                             where user.Email.Equals(User.Identity.Name)
                             select user).First();

            var question = (from questions in _context.Question
                            where questions.Id == Id
                            select questions).First();

             ViewData["ForumMemberId"] = forumUser.Id;
            ViewData["QuestionId"] = Id;

            ViewData["Question"] = question.Details;
            return View();
        }

        // POST: Answers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Contents,ForumMemberId,QuestionId")] Answer answer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(answer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), "Questions" );
            }
            var forumUser = (from user in _context.ForumMember
                             where user.Email.Equals(User.Identity.Name)
                             select user).First();

            var question = (from questions in _context.Question
                            where questions.Id == answer.QuestionId
                            select questions).First();

            ViewData["ForumMemberId"] = forumUser.Id;
            ViewData["QuestionId"] = answer.QuestionId;

            ViewData["Question"] = question.Details;
            return View(answer);
        }

        // GET: Answers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var answer = await _context.Answer.FindAsync(id);
            if (answer == null)
            {
                return NotFound();
            }
            var forumUser = (from user in _context.ForumMember
                             where user.Email.Equals(User.Identity.Name)
                             select user).First();

            var question = (from questions in _context.Question
                            where questions.Id == answer.QuestionId
                            select questions).First();

            ViewData["ForumMemberId"] = forumUser.Id;
            ViewData["QuestionId"] = answer.QuestionId;

            ViewData["Question"] = question.Details;
            return View(answer);
        }

        // POST: Answers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Contents,ForumMemberId,QuestionId")] Answer answer)
        {
            if (id != answer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(answer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnswerExists(answer.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), "Questions");
            }
            var forumUser = (from user in _context.ForumMember
                             where user.Email.Equals(User.Identity.Name)
                             select user).First();

            var question = (from questions in _context.Question
                            where questions.Id == answer.QuestionId
                            select questions).First();

            ViewData["ForumMemberId"] = forumUser.Id;
            ViewData["QuestionId"] = answer.QuestionId;

            ViewData["Question"] = question.Details;
            return View(answer);
        }

        // GET: Answers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var answer = await _context.Answer
                .Include(a => a.ForumMember)
                .Include(a => a.Question)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (answer == null)
            {
                return NotFound();
            }

            return View(answer);
        }

        // POST: Answers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var answer = await _context.Answer.FindAsync(id);
            _context.Answer.Remove(answer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnswerExists(int id)
        {
            return _context.Answer.Any(e => e.Id == id);
        }
    }
}
