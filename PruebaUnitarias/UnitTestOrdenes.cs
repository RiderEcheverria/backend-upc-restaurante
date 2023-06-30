using backend_upc_restaurante.Connection;
using backend_upc_restaurante.Dominio;
using backend_upc_restaurante.Servicios;

namespace PruebaUnitarias
{
    [TestCaseOrderer("TestOrderExamples.TestCaseOrdering.PriorityOrderer", "TestOrderExamples")]
    public class UnitTestOrdenes
    {
        public UnitTestOrdenes()
        {
            //utilizar otra BD (temporal)
            DBManager.Instance.ConnectionString = "workstation id=upc-riderdatabase.mssql.somee.com;packet size=4096;user id=riderecheverria_SQLLogin_1;pwd=3sughlin6b;data source=upc-riderdatabase.mssql.somee.com;persist security info=False;initial catalog=upc-riderdatabase";
        }

        [Fact, TestPriority(0)]
        public void Ordenes_Get_VerificarNotNull()
        {
            // Arrange
            // Declarar variables
            Console.WriteLine("TestPriority(0)");

            // Act
            // Usar Métodos
            var result = OrdenesServicios.Get<Ordenes>();//un listado

            // Assert
            // Las Comparaciones
            Assert.NotNull(result);
        }

        [Fact, TestPriority(1)]
        public void Ordenes_GetById_RegresaItem()
        {
            Console.WriteLine("TestPriority(1)");
            var result = PlatosServicios.GetById<Ordenes>(1);
            Assert.Equal(1, result.Id);
        }

        [Fact, TestPriority(2)]
        public void Ordenes_Insertar_RetornaUno()
        {
            // Arrange
            Console.WriteLine("TestPriority(2)");
            Ordenes ordenes = new();
           // ordenes.Cantidad = "uno";
            // Act
            var result = OrdenesServicios.Insert(ordenes);

            // Assert
            Assert.Equal(1, result);
        }

        [Fact, TestPriority(3)]
        public void Ordenes_Update_RetornaUno()
        {
            Console.WriteLine("TestPriority(3)");
            Ordenes ordenes = new();
            ordenes.Id = 4;
           // ordenes.Cantidad = "2";

            var result = OrdenesServicios.Update(ordenes);

            Assert.Equal(1, result);
        }

        [Fact, TestPriority(4)]
        public void Ordenes_Delete_RetornaUno()
        {
            Console.WriteLine("TestPriority(4)");
            var result = OrdenesServicios.Delete(10);
            
        }
    }
}