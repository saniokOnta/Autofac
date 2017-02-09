using System;
using System.Linq;

namespace Autofac.Builder
{
    /// <summary>
    /// Extension methods for <see cref="RegistrationData"/>.
    /// </summary>
    public static class RegistrationDataExtensions
    {
        private static readonly string CallbackContainerKey = "__Autofac$CallbackContainer";

        /// <summary>
        /// Gets the callback container from registration metadata.
        /// </summary>
        /// <param name="data">The data to search for the container.</param>
        /// <returns>
        /// A <see cref="CallbackContainer"/> if one is set; or <see langword="null" /> if
        /// none is found.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown if <paramref name="data" /> is <see langword="null" />.
        /// </exception>
        public static CallbackContainer GetCallbackContainer(this RegistrationData data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            var container = (object)null;
            if (data.Metadata.TryGetValue(CallbackContainerKey, out container))
            {
                return container as CallbackContainer;
            }

            return null;
        }

        /// <summary>
        /// Sets the callback container in registration metadata.
        /// </summary>
        /// <param name="data">The data to in which the container should be stored.</param>
        /// <param name="container">
        /// The <see cref="CallbackContainer"/> with the reference to the callback
        /// associated with the registration builder. If this is <see langword="null" />,
        /// the callback will be removed from the registration data.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown if <paramref name="data" /> is <see langword="null" />.
        /// </exception>
        public static void SetCallbackContainer(this RegistrationData data, CallbackContainer container)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            if (container == null)
            {
                data.Metadata.Remove(CallbackContainerKey);
            }
            else
            {
                data.Metadata[CallbackContainerKey] = container;
            }
        }
    }
}
