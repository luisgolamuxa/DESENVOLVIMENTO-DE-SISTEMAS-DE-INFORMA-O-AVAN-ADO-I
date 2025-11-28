using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MinhaApp.Application.Interfaces;
using MinhaApp.Application.DTOs;
using System.Linq;

namespace MinhaApp.Api.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _produtoService;
        private readonly ICategoriaService _categoriaService;

        public ProdutoController(IProdutoService produtoService, ICategoriaService categoriaService)
        {
            _produtoService = produtoService;
            _categoriaService = categoriaService;
        }

        public async Task<IActionResult> Index()
        {
            var produtos = await _produtoService.GetAllAsync();
            var categorias = (await _categoriaService.GetAllAsync()).ToList();
            ViewBag.Categorias = categorias;
            return View(produtos);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Categorias = (await _categoriaService.GetAllAsync()).ToList();
            return View(new ProdutoDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProdutoDto dto)
        {
            if (!ModelState.IsValid) { ViewBag.Categorias = (await _categoriaService.GetAllAsync()).ToList(); return View(dto); }
            await _produtoService.CreateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var p = await _produtoService.GetByIdAsync(id);
            if (p == null) return NotFound();
            ViewBag.Categorias = (await _categoriaService.GetAllAsync()).ToList();
            return View(p);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, ProdutoDto dto)
        {
            if (id != dto.Id) return BadRequest();
            if (!ModelState.IsValid) { ViewBag.Categorias = (await _categoriaService.GetAllAsync()).ToList(); return View(dto); }
            await _produtoService.UpdateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _produtoService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
