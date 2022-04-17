using NUnit.Framework;
using NETCOREHENRYTENORIOMVC.Models;
using NETCOREHENRYTENORIOMVC.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace PruebaUnitariaHT
{

    public class Tests
    {
        public void Listar()
        {
            MantenedorController controlador = new MantenedorController();
            ViewResult result = controlador.Listar() as ViewResult;
            Assert.IsNotNull(result);


        }
    }
}