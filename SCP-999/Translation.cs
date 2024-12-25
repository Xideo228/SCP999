using Exiled.API.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCP_999
{
    public class Translation : ITranslation
    {
        [Description("Prefix SCP-999")]
        public string Info { get; set; } = "SCP-999";
    }
}
