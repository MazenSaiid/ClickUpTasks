using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.HCSChampian.Dropdowns
{
    [AmbientValue(typeof(Guid), "d3fe59cc-b44d-498f-8d93-6e63d0277e6f")]
    public enum RecurringDeadlines
    {
        [AmbientValue(typeof(Guid), "85b878df-6003-4a5f-bd31-bc0693773c43")] January,
        [AmbientValue(typeof(Guid), "9c6df8db-00f3-4272-9ece-b7e2c7a9c61c")] February,
        [AmbientValue(typeof(Guid), "d699f32a-266d-46c3-95d1-cf40d852a5a4")] March,
        [AmbientValue(typeof(Guid), "c6fc907b-df12-4806-8c29-7b6f9a76cfd4")] April,
        [AmbientValue(typeof(Guid), "c31e4fb8-46cc-465a-986b-02af9041c657")] May,
        [AmbientValue(typeof(Guid), "e2b4afbe-529f-4610-a6bd-8d1145de0807")] June,
        [AmbientValue(typeof(Guid), "2cdc3aec-11b0-44ae-aaaf-9dd2baa37e7c")] July,
        [AmbientValue(typeof(Guid), "a02a6760-cb55-433d-b6eb-1a338e1cade9")] August,
        [AmbientValue(typeof(Guid), "d95e88eb-9d1f-4c2e-b2dc-fdd4ed55e231")] September,
        [AmbientValue(typeof(Guid), "c452ddd3-5431-4080-b87b-8f5103023891")] October,
        [AmbientValue(typeof(Guid), "e2af4753-1e1b-4c1b-b5d5-f7dd93be5070")] November,
        [AmbientValue(typeof(Guid), "726d5405-1a23-4381-b1de-5f288f2a305f")] December,
        [AmbientValue(typeof(Guid), "8f222f7b-834d-4202-ae4b-ce22bb937cce")] HCBSReAuthorization6Months,
        [AmbientValue(typeof(Guid), "623bb867-2bb4-43f2-b7e3-ae9352d9751d")] DisabilityCertificate,
        [AmbientValue(typeof(Guid), "8309d728-41b9-448d-ac3c-4064669a4444")] AnnualCMEnrollment,
        [AmbientValue(typeof(Guid), "6152cdcc-a572-4910-b49f-1d90d492f65e")] AnnualHCBSEnrollment,
        [AmbientValue(typeof(Guid), "f9580643-6447-4a6c-9644-0086011900fc")] TransferWithHCBS

    }
}
