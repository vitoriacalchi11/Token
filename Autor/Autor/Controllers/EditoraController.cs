﻿using Autor.Models;
using Autor.Repositorios.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Autor.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EditoraController : ControllerBase
    {
        private readonly IEditoraRepositorio _editoraRepositorio;

        public EditoraController(IEditoraRepositorio editoraRepositorio)
        {
            _editoraRepositorio = editoraRepositorio;
        }



        [HttpGet]
        public async Task<ActionResult<List<EditoraModel>>> BuscarTodasEditoras()
        {
            List<EditoraModel> editores = await _editoraRepositorio.BuscarTodasEditoras();
            return Ok(editores);
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<EditoraModel>> BuscarPorId(int id)
        {
            EditoraModel editores = await _editoraRepositorio.BuscarPorId(id);
            return Ok(editores);
        }

        [HttpPost]
        public async Task<ActionResult<EditoraModel>> Adicionar([FromBody] EditoraModel editoraModel)
        {
            EditoraModel editora = await _editoraRepositorio.Adicionar(editoraModel);
            return Ok(editora);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EditoraModel>> Atualizar(int id, [FromBody] EditoraModel editoraModel)
        {
            editoraModel.Id = id;
            EditoraModel editora = await _editoraRepositorio.Atualizar(editoraModel, id);
            return Ok(editora);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<EditoraModel>> Apagar(int id)
        {
            bool apagado = await _editoraRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
