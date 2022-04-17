using Microsoft.AspNetCore.Mvc;

using NETCOREHENRYTENORIOMVC.Datos;
using NETCOREHENRYTENORIOMVC.Models;
using Microsoft.AspNetCore.Authorization;

namespace NETCOREHENRYTENORIOMVC.Controllers
{
    public class MantenedorController : Controller
    {

        CuentaDatos _CuentaDatos = new CuentaDatos();
        ClienteDatos _ClienteDatos = new ClienteDatos();
        MovimientoDatos _MovimientoDatos = new MovimientoDatos();
        ReporteEstadoCuenta _EstadoCuentaDatos = new ReporteEstadoCuenta();


        [Authorize(Roles = "ROLE_ADMIN")]
        public IActionResult Listar()
        {
            //LA VISTA MOSTRARÁ UNA LISTA DE CUENTAS
            var oLista = _CuentaDatos.Listar();

            return View(oLista);
        }

        [Authorize(Roles = "ROLE_ADMIN")]
        public IActionResult ListarClientes()
        {
            //LA VISTA MOSTRARÁ UNA LISTA DE CLIENTES
            var oListaCliente = _ClienteDatos.ListarClientes();

            return View(oListaCliente);
        }
        public IActionResult ListarMovimientos()
        {
            //LA VISTA MOSTRARÁ UNA LISTA DE MOVIMIENTOS
            var oListaCliente = _MovimientoDatos.ListarMovimientos();

            return View(oListaCliente);
        }

        public IActionResult ListarEstadoCuenta()
        {
            var oReporteEstadoCuenta = _EstadoCuentaDatos.ListarEstadoCuenta();

            return View(oReporteEstadoCuenta);
        }


        public IActionResult Guardar()
        {
            //METODO SOLO DEVUELVE LA VISTA
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(CuentaModel oCuenta)
        {
            //METODO RECIBE EL OBJETO PARA GUARDARLO EN BD
            if (!ModelState.IsValid)
                return View();


            var respuesta = _CuentaDatos.Guardar(oCuenta);

            if (respuesta)
                return RedirectToAction("Listar");
            else 
                return View();
        }
        public IActionResult GuardarCliente()
        {
            //METODO SOLO DEVUELVE LA VISTA
            return View();
        }

        [HttpPost]
        public IActionResult GuardarCliente(ClienteModel oCliente)
        {
            //METODO RECIBE EL OBJETO PARA GUARDARLO EN BD
            if (!ModelState.IsValid)
                return View();


            var respuesta = _ClienteDatos.GuardarCliente(oCliente);

            if (respuesta)
                return RedirectToAction("ListarClientes");
            else
                return View();
        }
        


        public IActionResult Editar(int IdCuenta)
        {
            //METODO SOLO DEVUELVE LA VISTA
            var ocuenta = _CuentaDatos.Obtener(IdCuenta);
            return View(ocuenta);
        }

        [HttpPost]
        public IActionResult Editar(CuentaModel oCuenta)
        {
            if (!ModelState.IsValid)
                return View();


            var respuesta = _CuentaDatos.Editar(oCuenta);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult EditarCliente(int IdCliente)
        {
            //METODO SOLO DEVUELVE LA VISTA
            var ocliente= _ClienteDatos.ObtenerCliente(IdCliente);
            return View(ocliente);
        }

        [HttpPost]
        public IActionResult EditarCliente(ClienteModel oCliente)
        {
            if (!ModelState.IsValid)
                return View();


            var respuesta = _ClienteDatos.EditarCliente(oCliente);

            if (respuesta)
                return RedirectToAction("ListarClientes");
            else
                return View();
        }



        public IActionResult Eliminar(int IdCuenta)
        {
            //METODO SOLO DEVUELVE LA VISTA
            var ocuenta = _CuentaDatos.Obtener(IdCuenta);
            return View(ocuenta);
        }

        [HttpPost]
        public IActionResult Eliminar(CuentaModel oCuenta)
        {
  
            var respuesta = _CuentaDatos.Eliminar(oCuenta.IdCuenta);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }


        public IActionResult EliminarCliente(int IdCliente)
        {
            //METODO SOLO DEVUELVE LA VISTA
            var ocliente = _ClienteDatos.ObtenerCliente(IdCliente);
            return View(ocliente);
        }

        [HttpPost]
        public IActionResult EliminarCliente(ClienteModel oCliente)
        {

            var respuesta = _ClienteDatos.EliminarCliente(oCliente.IdCliente);

            if (respuesta)
                return RedirectToAction("ListarClientes");
            else
                return View();
        }

        public IActionResult BuscarEstadoCuenta(int cedula, DateTime fecha)
        {
            //METODO SOLO DEVUELVE LA VISTA
            var oEstadoCuenta = _EstadoCuentaDatos.Obtener(cedula,fecha);
            return View(oEstadoCuenta);
        }

        


    }
}
