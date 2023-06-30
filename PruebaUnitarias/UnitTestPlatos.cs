using backend_upc_restaurante.Connection;
using backend_upc_restaurante.Dominio;
using backend_upc_restaurante.Servicios;

namespace PruebaUnitarias
{
    [TestCaseOrderer("TestOrderExamples.TestCaseOrdering.PriorityOrderer", "TestOrderExamples")]
    public class UnitTestPlatos
    {
        public UnitTestPlatos()
        {
            //utilizar otra BD (temporal)
            DBManager.Instance.ConnectionString = "workstation id=upc-riderdatabase.mssql.somee.com;packet size=4096;user id=riderecheverria_SQLLogin_1;pwd=3sughlin6b;data source=upc-riderdatabase.mssql.somee.com;persist security info=False;initial catalog=upc-riderdatabase";
        }

        [Fact, TestPriority(0)]
        public void Platos_Get_VerificarNotNull()
        {
            // Arrange
            // Declarar variables
            Console.WriteLine("TestPriority(0)");

            // Act
            // Usar Métodos
            var result = PlatosServicios.Get<Platos>();//un listado

            // Assert
            // Las Comparaciones
            Assert.NotNull(result);
        }

        [Fact, TestPriority(1)]
        public void Platos_GetById_RegresaItem()
        {
            Console.WriteLine("TestPriority(1)");
            var result = PlatosServicios.GetById<Platos>(1);
            Assert.Equal(1, result.Id);
        }

        [Fact, TestPriority(2)]
        public void Platos_Insertar_RetornaUno()
        {
            // Arrange
            Console.WriteLine("TestPriority(2)");
            Platos platos = new();
            platos.Nombre = "Platos UnitTest";
            // Act
            var result = PlatosServicios.Insert(platos);

            // Assert
            Assert.Equal(1, result);
        }

        [Fact, TestPriority(3)]
        public void Platos_Update_RetornaUno()
        {
            Console.WriteLine("TestPriority(3)");
            Platos platos = new();
            platos.Id = 4;
            platos.Nombre = "Update plato";

            var result = PlatosServicios.Update(platos);

            Assert.Equal(1, result);
        }

        [Fact, TestPriority(4)]
        public void Platos_Delete_RetornaUno()
        {
            Console.WriteLine("TestPriority(4)");
            var result = PlatosServicios.Delete(10);
            
        }
    }
}