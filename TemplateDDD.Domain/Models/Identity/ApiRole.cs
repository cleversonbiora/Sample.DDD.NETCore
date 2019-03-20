using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateDDD.Domain.Models.Identity
{
    public class ApiRole
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string NormalizedName { get; set; }
    }
}
