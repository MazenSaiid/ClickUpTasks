using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.HCSChampian.Dropdowns
{
    [AmbientValue(typeof(Guid), "493184d5-54d6-4c39-9a62-e388cf065eff")]

    public enum DisabilityCertificate
    {
        [AmbientValue(typeof(Guid), "f4786731-9d48-4274-b840-02fda7ba8ec9")] Yes,
        [AmbientValue(typeof(Guid), "14bae400-4418-4caf-8c48-bb4cb00d3b8b")] No
    }
}
