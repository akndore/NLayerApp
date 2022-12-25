using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.Core.DTOs
{
    public class ErrorModel
    {
        public ErrorModel(List<string> errors)
        {
            Errors = errors;
        }

        public List<string> Errors { get; set; }
    }
}
