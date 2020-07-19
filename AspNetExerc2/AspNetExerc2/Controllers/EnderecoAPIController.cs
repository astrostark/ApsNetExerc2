using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetExerc2.DAL;
using AspNetExerc2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetExerc2.Controllers
{
    [Route("api/Endereco")]
    [ApiController]
    public class EnderecoAPIController : ControllerBase
    {
        //
        // Nome: Luan Baum Bastos
        // Matrícula: 1711925
        //

        private readonly EnderecoDAO _enderecoDAO;
        public EnderecoAPIController(EnderecoDAO enderecoDAO)
        {
            _enderecoDAO = enderecoDAO;
        }

        // GET: /api/Endereco/ListarEnderecos
        [HttpGet]
        [Route("ListarEnderecos")]
        public IActionResult Listar()
        {
            return Ok(_enderecoDAO.Listar());
        }

        // GET: /api/Endereco/ListarEndereco/81730000
        [HttpGet]
        [Route("ListarEndereco/{cep}")]
        public IActionResult Pesquisar(string cep)
        {
            return Ok(_enderecoDAO.Pesquisar(cep));
        }

        // POST: /api/Endereco/CadastrarEndereco
        [HttpPost]
        [Route("CadastrarEndereco")]
        public IActionResult Cadastar(Endereco endereco)
        {
            _enderecoDAO.Cadastrar(endereco);
            return Created("", endereco);
        }

        // PUT: /api/Endereco/AlterarEndereco
        [HttpPut]
        [Route("AlterarEndereco")]
        public IActionResult Alterar(Endereco endereco)
        {
            _enderecoDAO.Alterar(endereco);
            return Ok(endereco);
        }

        // DELETE: /api/Endereco/DeletarEndereco/2
        [HttpDelete]
        [Route("DeletarEndereco/{cepId}")]
        public IActionResult Alterar(int cepId)
        {
            if (_enderecoDAO.Remover(cepId))
            {
                return Ok(cepId);
            }
            else
            {
                return NotFound();
            }
        }
    }
}