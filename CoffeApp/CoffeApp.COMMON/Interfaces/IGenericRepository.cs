using CoffeApp.COMMON.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Se usa para implementar en la capa DAL del proyecto
/// </summary>

namespace CoffeApp.COMMON.Interfaces
{
    public interface IGenericRepository<T> where T:BaseDTO
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
        T Create(T entidad);

        /// <summary>
        /// Regresa todos los registros de la tabla
        /// </summary>
        IEnumerable<T> Read { get; }

        /// <summary>
        /// Actualiza una entidad en la base de datos
        /// </summary>
        /// <param name="entidad">Entidad a actualizar en base a su ID</param>
        /// <returns>Entidad actualizada completa</returns>
        T Update(T entidad);

        /// <summary>
        /// Elimina un entidad en la base al ID proporcionado
        /// </summary>
        /// <param name="Id">Id de la entidad a eliminar</param>
        /// <returns>La confirmacion de que la entidad fue eliminada</returns>
        bool Delete(string Id);

        /// <summary>
        /// Ejectuta una consulta SQL sobre la tabla, regresando todos los campos de la misma
        /// </summary>
        /// <param name="querySql">Consulta SQL</param>
        /// <returns>Conjunto de entidad que coinciden con la consulta</returns>
        IEnumerable<T> Query(string querySql);


        /// <summary>
        /// Buscar una entidad por su Id
        /// </summary>
        /// <param name="Id">Id de la entidad a buscar</param>
        /// <returns>Entidad que conincide con el Id</returns>
        T SearchById(string Id);

    }
}
