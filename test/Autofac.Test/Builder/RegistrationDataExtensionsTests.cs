using System;
using System.Linq;
using Autofac.Builder;
using Autofac.Core;
using Xunit;

namespace Autofac.Test.Builder
{
    public class RegistrationDataExtensionsTests
    {
        [Fact]
        public void GetCallbackContainer_GetsContainer()
        {
            var data = new RegistrationData(new TypedService(typeof(object)));
            var c = new CallbackContainer(reg => { });
            data.SetCallbackContainer(c);
            Assert.Same(c, data.GetCallbackContainer());
        }

        [Fact]
        public void GetCallbackContainer_NoneSet()
        {
            var data = new RegistrationData(new TypedService(typeof(object)));
            Assert.Null(data.GetCallbackContainer());
        }

        [Fact]
        public void GetCallbackContainer_NullData()
        {
            Assert.Throws<ArgumentNullException>(() => RegistrationDataExtensions.GetCallbackContainer(null));
        }

        [Fact]
        public void SetCallbackContainer_NullContainerAllowed()
        {
            var data = new RegistrationData(new TypedService(typeof(object)));
            data.SetCallbackContainer(null);
            Assert.Null(data.GetCallbackContainer());
        }

        [Fact]
        public void SetCallbackContainer_NullData()
        {
            var c = new CallbackContainer(reg => { });
            Assert.Throws<ArgumentNullException>(() => RegistrationDataExtensions.SetCallbackContainer(null, c));
        }

        [Fact]
        public void SetCallbackContainer_NullRemovesContainer()
        {
            var data = new RegistrationData(new TypedService(typeof(object)));
            var c = new CallbackContainer(reg => { });
            data.SetCallbackContainer(c);
            data.SetCallbackContainer(null);
            Assert.Null(data.GetCallbackContainer());
        }
    }
}
