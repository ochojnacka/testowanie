using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestClass]
    public class ReservationTests
    {
        [TestMethod]
        public void CanBeCancelledBy_UserIsAdmin_ReturnsTrue()
        {
            // Arrange
            // przygotowanie danych testowych
            var reservation = new Reservation();

            // Act
            // wykonanie testowanej metody
            var result = reservation.CanBeCancelledBy(new User { IsAdmin = true });

            // Assert
            // weryfikacja wyniku
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanBeCancelledBy_UserIsMadeBy_ReturnsTrue()
        {
            var user = new User();
            var reservation = new Reservation { MadeBy = user };

            var result = reservation.CanBeCancelledBy(user);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanBeCancelledBy_UserIsNotAdminOrMadeBy_ReturnsFalse()
        {
            var reservation = new Reservation { MadeBy = new User() };

            var result = reservation.CanBeCancelledBy(new User());

            Assert.IsFalse(result);
        }
    }
}
