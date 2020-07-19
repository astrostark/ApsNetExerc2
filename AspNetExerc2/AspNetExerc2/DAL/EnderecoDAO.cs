﻿using AspNetExerc2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetExerc2.DAL
{
    public class EnderecoDAO
    {
        private readonly Context _context;
        public EnderecoDAO(Context context)
        {
            _context = context;
        }

        public void Cadastrar(Endereco endereco)
        {
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
        }
        public List<Endereco> Listar()
        {
            return _context.Enderecos.ToList();
        }

        public Endereco Pesquisar(string cep)
        {
            string cepFormatado = cep.Substring(0, 5) + "-" + cep.Substring(5);
            return _context.Enderecos.SingleOrDefault(endereco => endereco.Cep == cepFormatado);
        }
    }
}
