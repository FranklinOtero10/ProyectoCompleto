using ADSProject.DAL;
using ADSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ADSProject.Models.Context;

namespace ADSProject.Services
{
    public class ServiceGrupo
    {
        // Se obtienen todos los Grupos
        public List<Grupo> ObtenerTodos()
        {
            try
            {
                using (MyDbContext context = new MyDbContext())
                {
                    GrupoDAL dal = new GrupoDAL(context);
                    return dal.ObtenerTodos();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Se obtienen todos los Grupos
        public List<Grupo> ObtenerTodos(string[] includes)
        {
            try
            {
                using (MyDbContext context = new MyDbContext())
                {
                    GrupoDAL dal = new GrupoDAL(context);
                    return dal.ObtenerTodos(includes);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Se busca el Grupo por el Id
        public Grupo ObtenerById(int Id, string[] includes)
        {
            try
            {
                using (MyDbContext context = new MyDbContext())
                {
                    GrupoDAL dal = new GrupoDAL(context);
                    return dal.ObtenerById(Id, includes);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Se inserta un Grupo
        public int Insertar(Grupo model)
        {
            try
            {
                using (MyDbContext context = new MyDbContext())
                {
                    GrupoDAL dal = new GrupoDAL(context);
                    return dal.Insertar(model);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Se modifica un Grupo
        public int Modificar(int Id, Grupo model)
        {
            try
            {
                using (MyDbContext context = new MyDbContext())
                {
                    GrupoDAL dal = new GrupoDAL(context);
                    return dal.Modificar(Id, model);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Se elimina un Grupo
        public bool Eliminar(int Id)
        {
            try
            {
                using (MyDbContext context = new MyDbContext())
                {
                    GrupoDAL dal = new GrupoDAL(context);
                    return dal.Eliminar(Id);
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}