using ADSProject.Models;
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
    public class GruposController : Controller
    {
        public ServiceGrupo servicio = new ServiceGrupo();
        public ServiceCarrera servicioCarreras = new ServiceCarrera();
        public ServiceMateria servicioMateria = new ServiceMateria();
        public ServiceProfesor servicioProfesor = new ServiceProfesor();

        public GruposController() { }


        [HttpGet]
        public ActionResult Index()
        {
            var grupo = servicio.ObtenerTodos(new string[] { "Carrera", "Materia", "Profesor" });
            return View(grupo);
        }

        [HttpGet]
        public ActionResult Form(int? id, Operacion operacion)
        {
            var grupo = new Grupo();
            string[] includes = null;
            // Si el id tiene un valor; entonces se procede  a buscar un estudiante
            if (id.HasValue)
            {
                grupo = servicio.ObtenerById(id.Value, includes);
            }
            // Indica la operacion que estamos realizando en el formulario

            ViewData["Operacion"] = operacion;
            //Para llenar el listado de carreras
            ViewBag.Carreras = servicioCarreras.obtenerTodos();

            //Para llenar el listado de materias
            ViewBag.Materias = servicioMateria.obtenerTodos();

            //Para llenar el listado de profesores
            ViewBag.Profesor = servicioProfesor.obtenerTodos();
            return View(grupo);
        }

        [HttpGet]
        public JsonResult CargarMaterias(int? IdCarrera)
        {
            var listadoCarreras = IdCarrera == null ? new List<Materia>() :
            servicioMateria.obtenerTodos().Where(x => x.IdCarrera == IdCarrera);
            return new JsonHttpStatusResult(listadoCarreras, HttpStatusCode.OK);
        }

        [HttpPost]
        public ActionResult Form(Grupo grupo)
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
                    if (grupo.id == 0)
                    {
                        id = servicio.Insertar(grupo);
                    }
                    else
                    {
                        // Si el ID es distinto de cero entonces estamos modificando
                        id = servicio.Modificar(grupo.id, grupo);
                    }

                    //Si el id es mayor que 0 la operación es correcta
                    if (id > 0)
                    {
                        //Si la operación fue exitosa entonces devolvemos el codigo 200(success)
                        return new JsonHttpStatusResult(grupo, HttpStatusCode.OK);
                    }
                    else
                    {
                        //Si la operación no fue exitosa entonces devolvemos un codigo 202(accepted)
                        return new JsonHttpStatusResult(grupo, HttpStatusCode.Accepted);
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
                return new JsonHttpStatusResult(grupo, HttpStatusCode.InternalServerError);
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
                // Eliminar un grupo
                correcto = servicio.Eliminar(id);

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