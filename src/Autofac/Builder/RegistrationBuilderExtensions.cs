using System;
using System.Linq;

namespace Autofac.Builder
{
    /// <summary>
    /// Extension methods for <see cref="IRegistrationBuilder{TLimit, TActivatorData, TRegistrationStyle}"/>.
    /// </summary>
    public static class RegistrationBuilderExtensions
    {
        /// <summary>
        /// Gets the callback container from registration metadata.
        /// </summary>
        /// <param name="rb">The registration builder to search for the container.</param>
        /// <returns>
        /// A <see cref="CallbackContainer"/> if one is set; or <see langword="null" /> if
        /// none is found.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown if <paramref name="rb" /> is <see langword="null" />.
        /// </exception>
        public static CallbackContainer GetCallbackContainer<TLimit, TActivatorData, TRegistrationStyle>(this IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> rb)
        {
            if (rb == null)
            {
                throw new ArgumentNullException(nameof(rb));
            }

            return rb.RegistrationData.GetCallbackContainer();
        }

        /// <summary>
        /// Sets the callback container in registration metadata.
        /// </summary>
        /// <param name="rb">The registration builder to in which the container should be stored.</param>
        /// <param name="container">
        /// The <see cref="CallbackContainer"/> with the reference to the callback
        /// associated with the registration builder. If this is <see langword="null" />,
        /// the callback will be removed from the registration data.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown if <paramref name="rb" /> is <see langword="null" />.
        /// </exception>
        public static void SetCallbackContainer<TLimit, TActivatorData, TRegistrationStyle>(this IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> rb, CallbackContainer container)
        {
            if (rb == null)
            {
                throw new ArgumentNullException(nameof(rb));
            }

            rb.RegistrationData.SetCallbackContainer(container);
        }
    }
}
