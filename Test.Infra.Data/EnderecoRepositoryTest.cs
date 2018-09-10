using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SGE.Domain.Entities;
using SGE.Domain.Interfaces;
using SGE.Infra.Data.Context;
using SGE.Infra.Data.Repositories;
using SGE.Infra.Data.UoW;
using System.IO;

namespace Test.Infra.Data
{
    [TestClass]
    public class EnderecoRepositoryTest
    {
        SgeContext _ctx;
        IEnderecoRepository _repository;

        [TestInitialize]
        public void Initialize()
        {
            DbContextOptionsBuilder<SgeContext> builder = new DbContextOptionsBuilder<SgeContext>().UseSqlServer(@"Data Source=SPDEV\\SHAREPOINT;Initial Catalog=Sge;Integrated Security=True");
            _ctx = new SgeContext(builder.Options);
            _repository = new EnderecoRepository(_ctx);
        }

        [TestMethod]
        public void AddEnderecoRepositoryTest()
        {
            var endereco = new Endereco
            {
                Bairro = "Jardim Primavera",
                Cep = "25215283",
                Cidade = "Duque de Caxias",
                Complemento = "",
                Logradouro = "Estrada São Mateus",
                Numero = 204,
                UF = "RJ"
            };
            _repository.Add(endereco);
        }
        //[TestCleanup]
        //public void Cleanup()
        //{
        //    _ctx.Database.EnsureDeleted();
        //}
    }
}
