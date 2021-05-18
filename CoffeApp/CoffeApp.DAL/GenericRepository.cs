using CoffeApp.COMMON.Entidades;
using CoffeApp.COMMON.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CoffeApp.DAL.MsSQL
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseDTO
    {
        private readonly SQLConnection db;
        private readonly AbstractValidator<T> validator;

        public GenericRepository(AbstractValidator<T> validator)
        {
            this.validator = validator;
            db = new SQLConnection();
        }

        public string Error { get; private set; }



        public IEnumerable<T> Read
        {
            get
            {
                try
                {
                    var datos = Query($"Select * from {typeof(T).Name}");
                    Error = "";
                    return datos;
                }
                catch (Exception ex)
                {
                    Debug.Print($"==========> Error: {ex.Message}");
                    Error = "";
                    return null;
                }
            }
        }


        public T Create(T entidad)
        {
            string Id = Guid.NewGuid().ToString();
            entidad.Id = Id;
            ValidationResult validationResult = validator.Validate(entidad);
            if (validationResult.IsValid)
            {
                string sql1 = $"INSERT INTO {typeof(T).Name} (";
                string sql2 = ") VALUES (";
                string sql3 = ");";

                var campos = typeof(T).GetProperties();
                T dato = (T)Activator.CreateInstance(typeof(T));
                Type tTipo = typeof(T);

                for (int i = campos.Length - 1; i >= 0; i--)
                {
                    var propiedad = tTipo.GetProperty(campos[i].Name);
                    var valor = propiedad.GetValue(entidad);
                    if (valor == null)
                    {
                        continue;
                    }
                    sql1 += " " + campos[i].Name;
                    switch (propiedad.PropertyType.Name)
                    {
                        case "String":
                            sql2 += valor + "";
                            break;
                        case "DateTime":
                            //2021-02-05 05:51:25
                            DateTime dateTime = (DateTime)valor;
                            sql2 += $"'{dateTime.Year}-{dateTime.Month}-{dateTime.Day} {dateTime.Hour}:{dateTime.Minute}:{dateTime.Second}'";
                            break;
                        case "Boolean":
                            sql2 += (bool)valor ? "1" : "0";
                            break;
                        default:
                            sql2 += " " + valor;
                            break;
                    }

                    if (i != 0)
                    {
                        sql1 += ", ";
                        sql2 += ", ";
                    }

                }

                if (db.Comando(sql1 + sql2 + sql3) == 1)
                {
                    Error = "";
                    return SearchById(Id);
                }
                else
                {
                    Error = $"Error al construir el SQL: {db.Error}";
                    return null;
                }
            }
            else
            {
                Error = "Error de validacion: ";
                foreach (var item in validationResult.Errors)
                {
                    Error += item.ErrorMessage + ". ";
                }

                return null;
            }
        }

        public bool Delete(string Id)
        {
            try
            {
                int r = db.Comando($"Delete from {typeof(T).Name} where Id='{Id}';");
                if (r == 1)
                {
                    Error = "";
                    return true;
                }
                else
                {
                    Error = db.Error;
                    return false;
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message + " :" + db.Error;
                return false;
            }
        }

        public IEnumerable<T> Query(string querySql)
        {
            try
            {
                SqlDataReader dataReader = db.Consulta(querySql);
                List<T> datos = new List<T>();
                var campos = typeof(T).GetProperties();
                T dato;
                Type tTipo = typeof(T);
                while (dataReader.Read())
                {
                    dato = (T)Activator.CreateInstance(typeof(T));
                    for (int i = 0; i < campos.Length; i++)  //Obtiene las filas
                    {
                        int indice = campos.ToList().FindIndex(columna => columna.Name == dataReader.GetString(i));
                        PropertyInfo property = tTipo.GetProperty(campos[indice].Name);

                        if (dataReader[i] != DBNull.Value) //Obtiene las columnas
                        {
                            property.SetValue(dato, dataReader[i]);
                        }
                        else
                        {
                            property.SetValue(dato, null);
                        }
                    }
                    datos.Add(dato);
                }

                dataReader.Close();
                Error = "";
                return datos;

            }
            catch (Exception ex)
            {
                Error = ex.Message + ": " + db.Error;
                return null;
            }
        }

        public T SearchById(string Id)
        {
            try
            {
                return Query($"Select * from {typeof(T).Name} where Id='{Id}';").SingleOrDefault();
            }
            catch (Exception ex)
            {
                Error = ex.Message + ": " + db.Error;
                return null;
            }
        }

        public T Update(T entidad)
        {
            ValidationResult validationResult = validator.Validate(entidad);
            if (validationResult.IsValid)
            {
                string sql1 = $"update {typeof(T).Name} set ";
                string sql2 = $" where Id='{entidad.Id}'";
                string sql = "";

                var campos = typeof(T).GetProperties();
                T dato = (T)Activator.CreateInstance(typeof(T));
                Type tTipo = typeof(T);

                for (int i = 0; i <= campos.Length - 1; i++)
                {
                    if (campos[i].Name == "Id")
                    {
                        continue;
                    }
                    var propiedad = tTipo.GetProperty(campos[i].Name);
                    var valor = propiedad.GetValue(entidad);

                    if (valor != null)
                    {
                        sql += propiedad.Name + "=";
                        switch (propiedad.PropertyType.Name)
                        {
                            case "String":
                                sql += valor + "";
                                break;
                            case "DateTime":
                                //2021-02-05 05:51:25
                                DateTime dateTime = (DateTime)valor;
                                sql += $"'{dateTime.Year}-{dateTime.Month}-{dateTime.Day} {dateTime.Hour}:{dateTime.Minute}:{dateTime.Second}'";
                                break;
                            case "Boolean":
                                sql += (bool)valor ? "1" : "0";
                                break;
                            default:
                                sql += " " + valor;
                                break;
                        }

                        if (i != campos.Length - 2)
                        {
                            sql += ",";
                        }
                        sql1 += sql;
                        sql = "";
                    }

                }

                if (db.Comando(sql1 + " " + sql2) == 1)
                {
                    Error = "";
                    return SearchById(entidad.Id);
                }
                else
                {
                    Error = $"Error al construir el SQL: {db.Error}";
                    return null;
                }
            }
            else
            {
                Error = "Error de validacion: ";
                foreach (var item in validationResult.Errors)
                {
                    Error += item.ErrorMessage + ". ";
                }

                return null;
            }
        }


    }
}
