using System;
using System.Linq;
using Autofac.Builder;
using Xunit;

namespace Autofac.Test.Builder
{
    public class RegistrationBuilderExtensionsTests
    {
        [Fact]
        public void GetCallbackContainer_GetsContainer()
        {
            var rb = RegistrationBuilder.ForType(typeof(object));
            var c = new CallbackContainer(reg => { });
            rb.SetCallbackContainer(c);
            Assert.Same(c, rb.GetCallbackContainer());
        }

        [Fact]
        public void GetCallbackContainer_NoneSet()
        {
            var rb = RegistrationBuilder.ForType(typeof(object));
            Assert.Null(rb.GetCallbackContainer());
        }

        [Fact]
        public void GetCallbackContainer_NullData()
        {
            Assert.Throws<ArgumentNullException>(() => RegistrationBuilderExtensions.GetCallbackContainer<object, ConcreteReflectionActivatorData, SingleRegistrationStyle>(null));
        }

        [Fact]
        public void SetCallbackContainer_NullContainerAllowed()
        {
            var rb = RegistrationBuilder.ForType(typeof(object));
            rb.SetCallbackContainer(null);
            Assert.Null(rb.GetCallbackContainer());
        }

        [Fact]
        public void SetCallbackContainer_NullData()
        {
            var c = new CallbackContainer(reg => { });
            Assert.Throws<ArgumentNullException>(() => RegistrationBuilderExtensions.SetCallbackContainer<object, ConcreteReflectionActivatorData, SingleRegistrationStyle>(null, c));
        }

        [Fact]
        public void SetCallbackContainer_NullRemovesContainer()
        {
            var rb = RegistrationBuilder.ForType(typeof(object));
            var c = new CallbackContainer(reg => { });
            rb.SetCallbackContainer(c);
            rb.SetCallbackContainer(null);
            Assert.Null(rb.GetCallbackContainer());
        }
    }
}
