using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AyleesAngels.Client.Shared.Components
{
    public partial class AAHeader
    {
        [Parameter]
        public string Heading { get; set; }
        [Parameter]
        public string SubHeading { get; set; }
        [Parameter]
        public string Author { get; set; }
        [Parameter]
        public DateTime PostedDate { get; set; }
    }
}
