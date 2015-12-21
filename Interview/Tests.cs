using System.Diagnostics;
using System.Linq;
using System;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace Interview
{
    [TestFixture]
    public class Tests
    {
        [TestCase(TestName = "Count all")]
        public void GetAllCars()
        {
            // Arrange
            var cars = GetDummyCar(2);
            var carDbSet = GetCarsDbSet(cars);
            var carsContextMock = new Mock<CarSqlDataStoreStrategy>();
            carsContextMock.Setup(pc => pc.All()).Returns(carDbSet);
            var entityRepository = new CarRepository(carsContextMock.Object);

            // Act
            IEnumerable<Car> carResult = entityRepository.All().ToList();

            // Assert
            Assert.AreEqual(carDbSet.Count(), carResult.Count());
        }

        [TestCase(TestName = "Save")]
        public void SaveCar()
        {
            // Arrange
            var cars = GetDummyCar(1);
            var carDbSet = GetCarsDbSet(cars);
            var carsContextMock = new Mock<CarSqlDataStoreStrategy>(MockBehavior.Loose, carDbSet);
            carsContextMock.Setup(pc => pc.Save(It.IsAny<Car>())).Verifiable();
           
            var entityRepository = new CarRepository(carsContextMock.Object);

            // Act
            entityRepository.Save(cars.FirstOrDefault());

            // Assert
            carsContextMock.VerifyAll();

            Assert.DoesNotThrow(() => entityRepository.Save(new Car { Id = 1 }));

            Assert.Throws<InvalidOperationException>(() => entityRepository.Save(new Car()));
        }

        [TestCase(TestName = "Delete")]
        public void DeleteCar()
        {
            // Arrange
            var cars = GetDummyCar(4);
            var carDbSet = GetCarsDbSet(cars);
            int id;
            id = 1;

            var carsDatastoreContextMock = new Mock<SqlDataStoreContext>();
            carsDatastoreContextMock.Setup(pc => pc.Set<Car>()).Returns(carDbSet);
            var carsDatastoreStrategyMock = new Mock<CarSqlDataStoreStrategy>(MockBehavior.Loose, carsDatastoreContextMock);

            carsDatastoreStrategyMock.Setup(pc => pc.Delete(It.IsAny<IComparable>())).Verifiable();

            var carRepoMock = new Mock<CarRepository>(MockBehavior.Loose, carsDatastoreStrategyMock);
            //var entityRepository = new CarRepository(carsDatastoreStrategyMock.Object);

            // Act
            carRepoMock.Object.Delete(id);

            Assert.AreEqual(carRepoMock.Object.All().Count(), 3);

            // Assert
           // carsContextMock.VerifyAll();

       //     Assert.DoesNotThrow(() => entityRepository.Delete(id));


         //   Assert.Throws<InvalidOperationException>(() => entityRepository.Delete(id));
        }

        [TestCase(TestName = "FindById")]
        public void FindCar()
        {
            // Arrange
            var cars = GetDummyCar(4);
            var carDbSet = GetCarsDbSet(cars);
            object id = new object();
            id = 1;
            var carToFind = carDbSet.FirstOrDefault(s => s.Id.CompareTo(id) == 0 );
            var carsContextMock = new Mock<CarSqlDataStoreStrategy>();
            carsContextMock.Setup(pc => pc.FindById(1)).Returns(carToFind);
            var entityRepository = new CarRepository(carsContextMock.Object);

            // Act
            Car carResult = entityRepository.FindById(1);

            // Assert
            Assert.AreEqual(carToFind.Id, carResult.Id);
        }

        private FakeDbSet<Car> GetCarsDbSet(IEnumerable<Car> cars)
        {
            var carDbSet = new FakeDbSet<Car>();
            foreach (var car in cars)
            {
                carDbSet.Add(car);
            }
            return carDbSet;
        }

        private IEnumerable<Car> GetDummyCar(int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return new Car
                {
                    Id = i
                };
            }
        }
    }
}