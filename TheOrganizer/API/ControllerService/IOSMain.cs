using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheOrganizer
{
    public interface IOSMain
    {
        /// <summary>
        /// Load necessary dependencies
        /// </summary>
        void PreStart();

        /// <summary>
        /// Start the service
        /// </summary>
        void Start();

        /// <summary>
        /// Stop properly
        /// </summary>
        void Stop();
    }
}
