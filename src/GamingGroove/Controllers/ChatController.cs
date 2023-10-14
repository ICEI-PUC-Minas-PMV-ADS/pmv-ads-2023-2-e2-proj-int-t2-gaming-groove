using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GamingGroove.Data;
using GamingGroove.Models;

namespace GamingGroove.Controllers
{
    public class ChatController : Controller
    {
        private readonly GamingGrooveDbContext _context;

        public ChatController(GamingGrooveDbContext context)
        {
            _context = context;
        }

        // GET: Chat
        public async Task<IActionResult> Index()
        {
            var gamingGrooveDbContext = _context.Chats.Include(c => c.amizade).Include(c => c.equipe);
            return View(await gamingGrooveDbContext.ToListAsync());
        }

        // GET: Chat/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Chats == null)
            {
                return NotFound();
            }

            var chatModel = await _context.Chats
                .Include(c => c.amizade)
                .Include(c => c.equipe)
                .FirstOrDefaultAsync(m => m.chatId == id);
            if (chatModel == null)
            {
                return NotFound();
            }

            return View(chatModel);
        }

        // GET: Chat/Create
        public IActionResult Create()
        {
            ViewData["amizadeId"] = new SelectList(_context.Amizades, "amizadeId", "amizadeId");
            ViewData["equipeId"] = new SelectList(_context.Equipes, "equipeId", "equipeId");
            return View();
        }

        // POST: Chat/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("chatId,equipeId,amizadeId,historico,dataChat")] ChatModel chatModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chatModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["amizadeId"] = new SelectList(_context.Amizades, "amizadeId", "amizadeId", chatModel.amizadeId);
            ViewData["equipeId"] = new SelectList(_context.Equipes, "equipeId", "equipeId", chatModel.equipeId);
            return View(chatModel);
        }

        // GET: Chat/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Chats == null)
            {
                return NotFound();
            }

            var chatModel = await _context.Chats.FindAsync(id);
            if (chatModel == null)
            {
                return NotFound();
            }
            ViewData["amizadeId"] = new SelectList(_context.Amizades, "amizadeId", "amizadeId", chatModel.amizadeId);
            ViewData["equipeId"] = new SelectList(_context.Equipes, "equipeId", "equipeId", chatModel.equipeId);
            return View(chatModel);
        }

        // POST: Chat/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("chatId,equipeId,amizadeId,historico,dataChat")] ChatModel chatModel)
        {
            if (id != chatModel.chatId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chatModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChatModelExists(chatModel.chatId))
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
            ViewData["amizadeId"] = new SelectList(_context.Amizades, "amizadeId", "amizadeId", chatModel.amizadeId);
            ViewData["equipeId"] = new SelectList(_context.Equipes, "equipeId", "equipeId", chatModel.equipeId);
            return View(chatModel);
        }

        // GET: Chat/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Chats == null)
            {
                return NotFound();
            }

            var chatModel = await _context.Chats
                .Include(c => c.amizade)
                .Include(c => c.equipe)
                .FirstOrDefaultAsync(m => m.chatId == id);
            if (chatModel == null)
            {
                return NotFound();
            }

            return View(chatModel);
        }

        // POST: Chat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Chats == null)
            {
                return Problem("Entity set 'GamingGrooveDbContext.Chats'  is null.");
            }
            var chatModel = await _context.Chats.FindAsync(id);
            if (chatModel != null)
            {
                _context.Chats.Remove(chatModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChatModelExists(int id)
        {
          return (_context.Chats?.Any(e => e.chatId == id)).GetValueOrDefault();
        }
    }
}
