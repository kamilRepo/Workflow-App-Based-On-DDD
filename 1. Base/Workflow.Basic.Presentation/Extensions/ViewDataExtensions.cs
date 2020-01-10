using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Workflow.Basic.Presentation.Extensions
{
    public static class ViewDataExtensions
    {
        public static IDictionary<string, object> Model(this ViewDataDictionary viewData)
        {
            return viewData.ModelState.ToDictionary(modelState => modelState.Key,
                                                    modelState => modelState.Value.Value.RawValue);
        }

        public static IDictionary<string, string> ModelErrors(this ViewDataDictionary viewData)
        {
            return viewData.ModelState.Where(modelState => modelState.Value.Errors.Any())
                .ToDictionary(modelState => modelState.Key,
                              modelState => modelState.Value.Errors.First().ErrorMessage);
        }
    }
}
