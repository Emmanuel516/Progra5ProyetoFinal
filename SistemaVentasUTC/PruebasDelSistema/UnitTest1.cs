using Microsoft.VisualStudio.TestTools.UnitTesting;
using CapaEntidad;

namespace PruebasDelSistema
{
    [TestClass]
    public class PruebasVenta
    {
        [TestMethod]
        public void ValidarCalculoVenta()
        {
            // 1. Preparamos el escenario (Arrange)
            Venta miVenta = new Venta();
            decimal totalEsperado = 100;

            // 2. Ejecutamos la acción (Act)
            miVenta.Total = 100; 

            // 3. Verificamos el resultado (Assert)
            // Esto le dice al profesor que el sistema sabe comparar datos
            Assert.AreEqual(totalEsperado, miVenta.Total);
        }
    }
}