using CoffeApp.COMMON.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeApp.COMMON.Interfaces
{
    public interface IGenericManager<T> where T:BaseDTO
    {
        /// <summary>
        /// Proporciona informacion sobre el error ocurrido en alguna de las operaciones
        /// </summary>
        string Error { get; }


        /// <summary>
        /// Inserta un entidad en la base de datos
        /// </summary>
        /// <param name="entidad">Entidad a insertar sin ID</param>
        /// <returns>Entidad completa</returns>
        T insertar(T entidad);

        /// <summary>
        /// Regresa todos los registros de la tabla
        /// </summary>
        IEnumerable<T> ObtenerTodos { get; }

        /// <summary>
        /// Actualiza una entidad en la base de datos
        /// </summary>
        /// <param name="entidad">Entidad a actualizar en base a su ID</param>
        /// <returns>Entidad actualizada completa</returns>
        T Actualizar(T entidad);

        /// <summary>
        /// Elimina un entidad en la base al ID proporcionado
        /// </summary>
        /// <param name="Id">Id de la entidad a eliminar</param>
        /// <returns>La confirmacion de que la entidad fue eliminada</returns>
        bool Eliminar(string Id);

    }
}
