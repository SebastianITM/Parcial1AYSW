using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Web;
using VentasComputadores.Models;

namespace VentasComputadores.Clases
{
    public class clsVenta
    {
        private DBVentasComputadoresEntities dbVentasComputadores = new DBVentasComputadoresEntities(); //Es el atributo (Propiedad) para gestionar la conexion a la base de datos
        public Venta venta { get; set; } //Propiedad para manipular la informacion en la base de datos: Permite agregar, modificar o elimnar
        public string Insertar()
        {
            try
            {
                dbVentasComputadores.Ventas.Add(venta); // Agrega el objeto venta a la lista Ventas, aun no se agrega a la base de datos, se debe invocar el metodo savechanges
                dbVentasComputadores.SaveChanges(); //guardar los cambios
                return "se ha agregado la venta correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar la venta: " + ex.Message;
            }
        }
        public string Actualizar()
        {
            try
            {
                //Antes de actualizar un elemento (Ventas), se debe consultar para verificar que exista, y ahi si poderlo actualizar
                Venta vent = Consultar(venta.id);
                if (vent == null)
                {
                    return "la venta con el codigo ingresado no existe, por ende no se puede actualizar ";
                }
                //La venta existe la podemos actualizar
                dbVentasComputadores.Ventas.AddOrUpdate(venta); //Actualiza el objeto Venta en la lista de "Ventas". Todavia no se actualiza en la base de datos. Se debe invocar el metodo SaveChanges()
                dbVentasComputadores.SaveChanges();//Guarda los cambios en la base de datos
                return "Se actualizo la vivienda correctamente";
            }
            catch (Exception ex)
            {
                return "No se pudo actualizar la venta" + ex.Message;
            }
        }
        public List<Venta> ConsultarTodos()
        {
            return dbVentasComputadores.Ventas
                .OrderBy(e => e.id) // Ordenamos por el id
                .ToList();
        }
        public Venta Consultar(int id)
        {
            //Expresiones lambda. => permite definir funciones anonimas o instancias de objetos, sin la creacion formal, dependiendo de la lista a la cual se hace referencia
            //FirstOrDefault. Es una funcion que permite consultar el primer elemento de una lista que cumple las condiciones solicitadas
            return dbVentasComputadores.Ventas.FirstOrDefault(e => e.id == id);
        }
        public string Eliminar()
        {
            try
            {
                //Antes de eliminar debo verificar si la venta existe
                Venta vent = Consultar(venta.id);
                if (vent == null)
                {
                    return "La venta con el id ingresado no existe, por lo tanto no se puede eliminar";
                }
                //La venta existe la podemos eliminar
                dbVentasComputadores.Ventas.Remove(vent);//Elimina el objeto Venta en la lista de "Ventas". Todavia no se elimina en la base de datos. Se debe invocar el metodo SaveChanges()
                dbVentasComputadores.SaveChanges(); // Guarda los cambios en la base de datos
                return "Se elimino la vivienda correctamente";
            }
            catch (Exception ex)
            {

                return "No se pudo actualizar la venta: " + ex.Message;
            }
        }
    }
}