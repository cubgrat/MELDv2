using MELDv2.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MELDv2;

namespace MELDv2_UI_
{
    internal class Startup
    {
        public Startup()
        {
            MeldProcessor processor = new MeldProcessor(ConfigRepository.Config.MeltConfiguration);
            processor.Run();
        }
    }
}
