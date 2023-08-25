﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WEBMVC.Models;

namespace WEBMVC.Controllers
{
    public class AtendimentoesController : Controller
    {
        private readonly Contexto _context;

        public AtendimentoesController(Contexto context)
        {
            _context = context;
        }

        // GET: Atendimentoes
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Atendimentos.Include(a => a.aluno).Include(a => a.sala);
            return View(await contexto.ToListAsync());
        }

        // GET: Atendimentoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Atendimentos == null)
            {
                return NotFound();
            }

            var atendimento = await _context.Atendimentos
                .Include(a => a.aluno)
                .Include(a => a.sala)
                .FirstOrDefaultAsync(m => m.id == id);
            if (atendimento == null)
            {
                return NotFound();
            }

            return View(atendimento);
        }

        // GET: Atendimentoes/Create
        public IActionResult Create()
        {
            ViewData["alunoID"] = new SelectList(_context.Alunos, "id", "email");
            ViewData["salaID"] = new SelectList(_context.Salas, "id", "descricao");
            return View();
        }

        // POST: Atendimentoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,alunoID,salaID,data")] Atendimento atendimento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(atendimento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["alunoID"] = new SelectList(_context.Alunos, "id", "email", atendimento.alunoID);
            ViewData["salaID"] = new SelectList(_context.Salas, "id", "descricao", atendimento.salaID);
            return View(atendimento);
        }

        // GET: Atendimentoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Atendimentos == null)
            {
                return NotFound();
            }

            var atendimento = await _context.Atendimentos.FindAsync(id);
            if (atendimento == null)
            {
                return NotFound();
            }
            ViewData["alunoID"] = new SelectList(_context.Alunos, "id", "email", atendimento.alunoID);
            ViewData["salaID"] = new SelectList(_context.Salas, "id", "descricao", atendimento.salaID);
            return View(atendimento);
        }

        // POST: Atendimentoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,alunoID,salaID,data")] Atendimento atendimento)
        {
            if (id != atendimento.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(atendimento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtendimentoExists(atendimento.id))
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
            ViewData["alunoID"] = new SelectList(_context.Alunos, "id", "email", atendimento.alunoID);
            ViewData["salaID"] = new SelectList(_context.Salas, "id", "descricao", atendimento.salaID);
            return View(atendimento);
        }

        // GET: Atendimentoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Atendimentos == null)
            {
                return NotFound();
            }

            var atendimento = await _context.Atendimentos
                .Include(a => a.aluno)
                .Include(a => a.sala)
                .FirstOrDefaultAsync(m => m.id == id);
            if (atendimento == null)
            {
                return NotFound();
            }

            return View(atendimento);
        }

        // POST: Atendimentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Atendimentos == null)
            {
                return Problem("Entity set 'Contexto.Atendimentos'  is null.");
            }
            var atendimento = await _context.Atendimentos.FindAsync(id);
            if (atendimento != null)
            {
                _context.Atendimentos.Remove(atendimento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AtendimentoExists(int id)
        {
          return _context.Atendimentos.Any(e => e.id == id);
        }
    }
}