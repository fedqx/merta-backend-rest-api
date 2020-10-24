﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendApi.Extentions
{
    public static class ModelStateExtentions
    {
        public static ICollection<string> GetErrorMessage(this ModelStateDictionary Dictionary)
        {
            return Dictionary.SelectMany(m => m.Value.Errors).Select(m => m.ErrorMessage).ToList();
        }
    }
}
