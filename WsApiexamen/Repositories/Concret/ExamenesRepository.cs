using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Win32;
using System.Windows.Markup;
using WsApiexamen.Data;
using WsApiexamen.Data.Entities;
using WsApiexamen.DTO;
using WsApiexamen.Repositories.Abstract;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WsApiexamen.Repositories.Concret
{
    public class ExamenesRepository : IExamenesRepository
    {
        private readonly DBContext _context;

        public ExamenesRepository(DBContext context)
        {
            _context = context;
        }
        public async Task<ResponseCode> Actualizar(ExamenIDTO model)
        {
            ResponseCode response = new ResponseCode();
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var Examen = _context.tblExamen.Find(model.idExamen);

                    if (Examen != null)
                    {



                        Examen.Descripcion = model.Descripcion;
                        Examen.Nombre = model.Nombre;

                        _context.Entry(Examen).State = EntityState.Modified;

                        var num = await _context.SaveChangesAsync();

                        dbContextTransaction.Commit();

                        response.Codigo = 0;
                        response.Descripcion = "Registro Actualizado satisfactoriamente";
                    }
                    else
                    {
                        response.Codigo = 1;
                        response.Descripcion = "No existe un registro con ese ID";
                    }
                }
                catch (Exception ex)
                {
                    //hacemos rollback si hay excepción
                    dbContextTransaction.Rollback();
                    response.Codigo = 1;
                    response.Descripcion = ex.Message;
                }
            }


            return response;
        }

        public async Task<ResponseCode> Agregar(ExamenIDTO model)
        {
            ResponseCode response = new ResponseCode();
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var Examen = new tblExamen()
                    {
                        idExamen = model.idExamen,
                        Descripcion = model.Descripcion,
                        Nombre = model.Nombre,

                    };

                    var aux = _context.tblExamen.Find(Examen.idExamen);
                    if (aux == null)
                    {

                        _context.tblExamen.Add(Examen);

                        var num = await _context.SaveChangesAsync();

                        dbContextTransaction.Commit();

                        response.Codigo = 0;
                        response.Descripcion = "Registro insertado satisfactoriamente";
                    }
                    else
                    {
                        response.Codigo = 2;
                        response.Descripcion = "Error ya existe un registro con ese Id";
                    }
                    
                }
                catch (Exception ex)
                {
                    //hacemos rollback si hay excepción
                    dbContextTransaction.Rollback();
                    response.Codigo = 2;
                    response.Descripcion = ex.Message;
                }
            }


            return response;
        }

        public async Task<List<tblExamen>> Consultar(ExamenIDTO model)
        {
            List<tblExamen> Examenes = new List<tblExamen>();
            Examenes  = await  _context.tblExamen.Where(e => e.Descripcion == model.Descripcion && e.Nombre == model.Nombre).ToListAsync();
            return Examenes;
        }

        public async Task<ResponseCode> Eliminar(int id)
        {   
            ResponseCode response = new ResponseCode();
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var Examen = _context.tblExamen.Find(id);
                    if (Examen != null)
                    {
                        _context.Remove(Examen);
                        var num = await _context.SaveChangesAsync();

                        dbContextTransaction.Commit();

                        response.Codigo = 0;
                        response.Descripcion = "Registro Eliminado satisfactoriamente";
                    }
                    else
                    {
                        response.Codigo = 1;
                        response.Descripcion = "No existe un registro con ese ID";
                    }
                }
                catch (Exception ex)
                {
                    //hacemos rollback si hay excepción
                    dbContextTransaction.Rollback();
                    response.Codigo = 1;
                    response.Descripcion = ex.Message;
                }
            }


            return response;
        }
    }
}
