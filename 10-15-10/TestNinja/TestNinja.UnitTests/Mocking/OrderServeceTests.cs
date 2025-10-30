using Moq;
using NUnit.Framework;
using TestNinja.Mocking;
using System;
using System.Collections.Generic;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    internal class OrderServeceTests
    {
	    [Test]
        public void PlaceOrder_WhenCalled_StoreTheOrder()
        {
            var storage = new Mock<IStorage>();
            var service = new OrderService(storage.Object);

            var order = new Order();
            service.PlaceOrder(order);
            storage.Verify(s => s.Store(order));
        }
    }
}
