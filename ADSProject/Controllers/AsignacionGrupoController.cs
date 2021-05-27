using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ADSProject.Models;
using ADSProject.Services;
using ADSProject.Utilities;
using System.Net;

namespace ADSProject.Controllers
{
    public class AsignacionGrupoController : Controller
    {
        public ServiceEstudiantes servicioEstudiantes = new ServiceEstudiantes();
        public ServiceGrupo servicioGrupo = new ServiceGrupo();
        public ServiceAsignacionGrupo servicioAsignacion = new ServiceAsignacionGrupo();

        public ActionResult Form(int IdGrupo)
        {
            var estudiantes = servicioEstudiantes.obtenerTodos();
            estudiantes.ForEach(x => x.nombres = x.nombres + " " + x.apellidos);
            ViewBag.Estudiantes = estudiantes;

            var model = new Grupo();
            model = servicioGrupo.ObtenerById(IdGrupo, new string[] {
                "Profesor",
                "Materia",
                "Carrera",
                "AsignacionGrupos",
                "AsignacionGrupos.Estudiante"
            });
            return View(model);
        }

        [HttpPost]
        public ActionResult Form(Grupo model)
        {
            try
            {
                //guardamos el id del modelo insertado
                servicioAsignacion.Insertar(model);
                // Si la operación fue exitosa entonces devolvemos el modelo
                // con un código 200 (Success)
                return new JsonHttpStatusResult(model, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                //Si ocurrió cualquier tipo de error, entonces devolvemos el código 500
                return new JsonHttpStatusResult(
                    model,
                    HttpStatusCode.InternalServerError
                    );
            }
        }
    }
}