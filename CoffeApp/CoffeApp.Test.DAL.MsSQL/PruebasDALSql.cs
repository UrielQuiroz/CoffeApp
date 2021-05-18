using CoffeApp.COMMON.Entidades;
using CoffeApp.DAL.MsSQL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CoffeApp.Test.DAL.MsSQL
{
    [TestClass]
    public class PruebasDALSql
    {


        [TestMethod]
        public void TestTipoUsuario()
        {
            try
            {
                var repositorio = FabricRepository.TipoUsuario();
                var numAntes = repositorio.Read.Count();
                var dato = repositorio.Create(new TipoUsuario()
                {
                    Nombre = "Test",
                    Descripcion = "Prueba unitaria"
                });

                Assert.IsNotNull(dato, "No se pudo crear el objeto: " + repositorio.Error);
                dato.Nombre = "Modificado";
                dato.Descripcion = "Modificado";
                var datoModificado = repositorio.Update(dato);

                Assert.IsNotNull(datoModificado, "No se modifico el dato: " + repositorio.Error);
                Assert.AreEqual(dato.Nombre, datoModificado.Nombre);
                Assert.IsTrue(repositorio.Delete(datoModificado.Id));
                Assert.AreEqual(numAntes, repositorio.Read.Count(), "La cantidad de registros despues del CRUD no es igual");
            }
            catch (System.Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
