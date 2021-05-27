using ADSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using ADSProject.Models.Context;
using System.Data.Entity;

namespace ADSProject.DAL
{
    public class GrupoDAL
    {
        private MyDbContext _context;

        public GrupoDAL(MyDbContext context)
        {
            _context = context;
        }

        // Se listan todos los Profesores
        public List<Grupo> ObtenerTodos()
        {
            try
            {
                var listado = _context.Grupo.Include("Carrera").Include("Materia").Include("Profesor").ToList();
                return listado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Se listan todos los Grupos
        public List<Grupo> ObtenerTodos(
            string[] includes
            )
        {
            try
            {
                var listado = _context.Grupo.AsQueryable();
                if (includes != null && includes.Count() > 0)
                {
                    foreach (var include in includes)
                    {
                        listado = listado.Include(include);
                    }
                }
                return listado.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Se busca el Grupo en el listado usando el Id
        public Grupo ObtenerById(int Id)
        {
            try
            {
                var item = _context.Grupo.SingleOrDefault(x => x.id == Id);
                return item;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Se busca el Grupo en el listado usando el Id
        public Grupo ObtenerById(int Id, string[] includes)
        {
            try
            {
                var item = _context.Grupo.AsQueryable();
                if (includes != null && includes.Count() > 0)
                {
                    foreach (var include in includes)
                    {
                        item = item.Include(include);
                    }
                }
                return item.SingleOrDefault(x => x.id == Id); ;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Se inserta el Grupo en el listado
        public int Insertar(Grupo model)
        {
            try
            {
                _context.Grupo.Add(model);
                _context.SaveChanges();
                return model.id;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Se modifica el Grupo en el listado
        public int Modificar(int Id, Grupo model)
        {
            try
            {
                var currentItem = _context.Grupo.SingleOrDefault(x => x.id == Id);
                _context.Entry(currentItem).CurrentValues.SetValues(model);
                _context.SaveChanges();
                return model.id;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Se elimina el Grupo del listado
        public bool Eliminar(int Id)
        {
            try
            {
                var item = _context.Grupo.SingleOrDefault(x => x.id == Id);
                _context.Grupo.Remove(item);
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