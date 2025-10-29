using TestNinja.Fundamentals;

namespace TestNinja.NUnitTests
{
    [TestFixture]
    internal class StackTests
    {
        [Test]
        public void Push_ArgIsNull_ThrowsArgNullExceprion()
        {
            var stack = new Fundamentals.Stack<string>();
            Assert.That(() => stack.Push(null), Throws.ArgumentNullException);
        }

        [Test]
        public void Push_ValidArg_AddTheObjectToTheStack()
        {
            var stack = new Fundamentals.Stack<string>();
            stack.Push("a");
            Assert.That(stack.Count, Is.EqualTo(1));
        }

        [Test]
        public void Pop_EmptyStack_ThrowsInvalidOperationException()
        {
            var stack = new Fundamentals.Stack<string>();
            Assert.That(() => stack.Pop(), Throws.InvalidOperationException);

        }
        [Test]
        public void Pop_StackWithAFewObject_ReturnsObjectOnTheTop()
        {
            //Arrange
            var stack = new Fundamentals.Stack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");
            //Act
            var result = stack.Pop();
            //Assert 
            Assert.That(result, Is.EqualTo("c"));
        }

        [Test]
        public void Pop_StackWithAFewObject_RemovesObjectOnTheTop()
        {
            //Arrange
            var stack = new Fundamentals.Stack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");
            //Act
            var result = stack.Pop();
            //Assert
            Assert.That(stack.Count, Is.EqualTo(2));
        }

        [Test]
        public void Peek_EmptyStack_ThrowsInvalidOperationException()
        {
            var stack = new Fundamentals.Stack<string>();
            Assert.That(() => stack.Peek(), Throws.InvalidOperationException);

        }
        [Test]
        public void Peek_StackWithAFewObject_ReturnsObjectOnTheTop()
        {
            //Arrange
            var stack = new Fundamentals.Stack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");
            //Act
            var result = stack.Peek();
            //Assert 
            Assert.That(result, Is.EqualTo("c"));
        }

        [Test]
        public void Peek_StackWithAFewObject_DoesntRemovesObjectOnTheTop()
        {
            //Arrange
            var stack = new Fundamentals.Stack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");
            //Act
            var result = stack.Peek();
            //Assert
            Assert.That(stack.Count, Is.EqualTo(3));
        }
    }
}
