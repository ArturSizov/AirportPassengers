using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace AirportPassengers.Infrastructure
{
    /// <summary>
    /// DI container
    /// </summary>
    public sealed class RootContainer
    {
        /// <summary>
        /// Singletone instance
        /// </summary>
        private static RootContainer? instance;

        /// <summary>
        /// Container
        /// </summary>
        private UnityContainer container;

        /// <summary>
        /// Constructor
        /// </summary>
        private RootContainer()
        {
            container = new UnityContainer();
        }

        /// <summary>
        /// Container
        /// </summary>
        public static IUnityContainer Container
        {
            get
            {
                if (instance == null)
                {
                    instance = new RootContainer();
                }

                return instance.container;
            }
        }

        /// <summary>
        /// Destructor
        /// </summary>
        ~RootContainer()
        {
            if (instance != null)
            {
                instance.container.Dispose();
            }
        }
    }
}
