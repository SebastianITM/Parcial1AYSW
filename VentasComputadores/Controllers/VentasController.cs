using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VentasComputadores.Clases;
using VentasComputadores.Models;

namespace VentasComputadores.Controllers
{
    [RoutePrefix("api/Ventas")]
    public class VentasController : ApiController
    {
        //Es el servicio que se va a exponer: GET, POST, PUT, DELETE   
        //GET: Se utiliza para consultar informacion, no se debe modificar la base de datos
        //POST: Se utiliza para insertar informacion en la base de datos
        //PUT: Se utiliza para modificar (Actualizar) informacion en la base de datos
        //DELETE: Se utiliza para eliminar informacion en la base de datos
        [HttpGet] //Es el servicio que se va a exponer: GET, POST, PUT, DELETE
        [Route("ConsultarTodos")] //es el nombre de la funcionalidad que se va a ejecutar
        public List<Venta> ConsultarTodos()
        {
            //se crea una instancia de la clase empleados
            clsVenta Venta = new clsVenta();
            //se invoca el ConsultarTodos() de la clase clsEmpleados
            return Venta.ConsultarTodos();
        }
        [HttpGet]
        [Route("ConsultarXId")]
        public Venta ConsultarXId(int id)
        {
            //Se crea la instacia de la clase clsVenta
            clsVenta venta = new clsVenta();
            return venta.Consultar(id);
        }
        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Venta venta) 
        {
            // Se crea una instancia de la clase clsVenta
            clsVenta Venta = new clsVenta();
            //se pasa la propiedad venta al objeto de la clase clsVenta
            Venta.venta = venta;
            //se invoca el metodo insertar
            return Venta.Insertar();
        }
        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Venta venta)
        {
            clsVenta Venta = new clsVenta();
            Venta.venta = venta;
            return Venta.Actualizar();
        }
        [HttpDelete]
        [Route("Eliminar")]

        public string Eliminar([FromBody] Venta venta)
        {
            clsVenta Venta = new clsVenta();
            Venta.venta = venta;
            return Venta.Eliminar();
        }
    }
}