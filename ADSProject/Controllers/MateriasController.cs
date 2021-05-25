﻿using ADSProject.Models;
using ADSProject.Services;
using ADSProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace ADSProject.Controllers
{
    public class MateriasController : Controller
    {
        public ServiceMateria servicio = new ServiceMateria();
        public ServiceCarrera servicioCarreras = new ServiceCarrera();

        public MateriasController() { }


        [HttpGet]
        public ActionResult Index()
        {
            var materia = servicio.obtenerTodos(new string[] { "Carrera" });
            return View(materia);
        }

        [HttpGet]
        public ActionResult Form(int? id, Operacion operacion)
        {
            var materia = new Materia();

            if (id.HasValue)
            {
                materia = servicio.obtenerPorID(id.Value);
            }
            // Indica la operacion que estamos realizando en el formulario
            ViewData["Operacion"] = operacion;

            //Para llenar el listado de carreras
            ViewBag.Carreras = servicioCarreras.obtenerTodos();
            return View(materia);
        }

        [HttpPost]
        public ActionResult Form(Materia materia)
        {
            try
            {
                // Validamos que el modelo carrera sea valido
                // segun las validaciones que le agregamos anteriormente
                if (ModelState.IsValid)
                {
                    //Esta variable nos sirve para sabaer si una carrera ha sido insertada correctamente
                    int id = 0;
                    // Si el ID es 0; entonces se esta insertando
                    if (materia.id == 0)
                    {
                        id = servicio.insertar(materia);
                    }
                    else
                    {
                        // Si el ID es distinto de cero entonces estamos modificando
                        id = servicio.modificar(materia.id, materia);
                    }

                    //Si el id es mayor que 0 la operación es correcta
                    if (id > 0)
                    {
                        //Si la operación fue exitosa entonces devolvemos el codigo 200(success)
                        return new JsonHttpStatusResult(materia, HttpStatusCode.OK);
                    }
                    else
                    {
                        //Si la operación no fue exitosa entonces devolvemos un codigo 202(accepted)
                        return new JsonHttpStatusResult(materia, HttpStatusCode.Accepted);
                    }
                }
                else
                {
                    //Si hubo error en la validación, entonces devolvemos todos los errores del modelo con un codigo 
                    // 400 (BadRequest)
                    IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(Temp => Temp.Errors);
                    return new JsonHttpStatusResult(allErrors, HttpStatusCode.BadRequest);
                }

                //return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return new JsonHttpStatusResult(materia, HttpStatusCode.InternalServerError);
                //throw;
            }
        }

        [HttpPost]
        public JsonResult Delete(int id, string operacion)
        {
            try
            {
                //variable que permite controlar si fue eliminado correctamente
                bool correcto = false;
                correcto = servicio.eliminar(id);

                if (correcto)
                {
                    //Se devuelve el id del elemento eliminado y se retorna un código 200 (success)
                    return new JsonHttpStatusResult(new { id }, HttpStatusCode.OK);
                }
                else
                {
                    //si no se puede eliminar entonces se retorna un código 202 (Acceptes)
                    return new JsonHttpStatusResult(new { id }, HttpStatusCode.Accepted);
                }

                //return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return new JsonHttpStatusResult(new { id }, HttpStatusCode.InternalServerError);
                //throw;
            }
        }
    }
}