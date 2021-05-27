using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ADSProject.Models;
using ADSProject.Models.Context;

namespace ADSProject.DAL
{
    public class AsignacionGrupoDAL
    {
        //Instancia del contexto que nos permite conectarnos a la BD
        private MyDbContext _context;

        //Este constructor recibe el contexto que
        //Mandamos desde el servicio
        public AsignacionGrupoDAL(MyDbContext context)
        {
            _context = context;
        }

        //Método para obtener todas las Carreras
        public List<AsignacionGrupo> ObtenerTodos()
        {
            try
            {
                //Se consultan todos los registros de AsignacionGrupo
                var listado = _context.AsignacionGrupo.ToList();
                //Se retorna del listado de registros
                return listado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Método para buscar AsignacionGrupo por el Id
        public AsignacionGrupo ObtenerById(int Id)
        {
            try
            {
                //Se obtiene el registro usando el Id
                var item = _context.AsignacionGrupo.SingleOrDefault(x => x.Id == Id);
                //Se retorn el registro
                return item;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Método para insertar una AsignacionGrupo
        public int Insertar(AsignacionGrupo model)
        {
            try
            {
                //Se agrega la AsignacionGrupo que se insertará
                _context.AsignacionGrupo.Add(model);
                //Se guardan los cambios en la BD
                _context.SaveChanges();
                //Se retorna el Id de la AsignacionGrupo recién insertada
                return model.Id;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Método para insertar una lista de AsignacionGrupo
        public void Insertar(ICollection<AsignacionGrupo> model)
        {
            try
            {
                //Se agrega la lista de AsignacionGrupo que se insertará
                _context.AsignacionGrupo.AddRange(model);
                //Se guardan los cambios en la BD
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Método para modificar una AsignacionGrupo
        public int Modificar(int Id, AsignacionGrupo model)
        {
            try
            {
                //Primero se consulta la AsignacionGrupo
                var currentItem = _context.AsignacionGrupo.SingleOrDefault(x => x.Id == Id);
                //Se trasladan los valores de la AsignacionGrupo que queremos modificar
                //al registro que acabamos de consultar
                _context.Entry(currentItem).CurrentValues.SetValues(model);
                //Se guardan los cambios en la BD
                _context.SaveChanges();
                //Se retorn el Id de la AsignacionGrupo recién modificada
                return model.Id;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Método para eliminar una AsignacionGrupo
        public bool Eliminar(int IdGrupo)
        {
            try
            {
                //Se consulta la AsignacionGrupo que se quiere eliminar por el Id
                var items = _context.AsignacionGrupo.Where(x => x.IdGrupo == IdGrupo).ToList();
                //Se remueve la AsignacionGrupo recién consultada
                _context.AsignacionGrupo.RemoveRange(items);
                //Se guardan los cambios en la BD
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}