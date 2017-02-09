using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac.Builder;
using Xunit;

namespace Autofac.Test.Builder
{
    public class CallbackContainerTests
    {
        [Fact]
        public void Callback_Null()
        {
            var c = new CallbackContainer(reg => { });
            Assert.Throws<ArgumentNullException>(() => { c.Callback = null; });
        }

        [Fact]
        public void Ctor_NullCallback()
        {
            Assert.Throws<ArgumentNullException>(() => new CallbackContainer(null));
        }

        [Fact]
        public void Ctor_SetsId()
        {
            var c = new CallbackContainer(reg => { });
            Assert.NotEqual(Guid.Empty, c.Id);
        }
    }
}
