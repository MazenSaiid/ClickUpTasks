using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.HCSChampian.Dropdowns
{
    [AmbientValue(typeof(Guid), "5316f869-db69-46da-9213-7c9c6258b786")]
    public enum SED_MF
    {
        [AmbientValue(typeof(Guid), "0b376c77-9136-4c4b-b32f-79afed50e689")] SED,
        [AmbientValue(typeof(Guid), "7440ab50-1433-492f-9d25-d6fcfd1112e1")] MF
    }
}
