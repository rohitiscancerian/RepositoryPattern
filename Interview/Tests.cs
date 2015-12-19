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
            var carsContextMock = new Mock<CarDataStore>();
            carsContextMock.Setup(pc => pc.All()).Returns(carDbSet);
            var entityRepository = new CarRepository(carsContextMock.Object);

            // Act
            IEnumerable<Car> carResult = entityRepository.All().ToList();

            // Assert
            Assert.AreEqual(carDbSet.Count(), carResult.Count());
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