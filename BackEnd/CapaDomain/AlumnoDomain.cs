﻿using CapaEntidad;
using CapaDatos;

namespace CapaDomain
{
    public class AlumnoDomain
    {
        private readonly AlumnoRepository _alumnoRepository;

        public AlumnoDomain(AlumnoRepository alumnoRepository)
        {
           
                _alumnoRepository = alumnoRepository;     
        }

        public IEnumerable<Cancion> ObtenerAlumnoTodos()
        {
            try
            {
                return _alumnoRepository.ObtenerAlumnoTodos();
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public int InsertarAlumno(Cancion oAlumno)
        {
            try
            {
                return _alumnoRepository.InsertarAlumno(oAlumno);
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}
