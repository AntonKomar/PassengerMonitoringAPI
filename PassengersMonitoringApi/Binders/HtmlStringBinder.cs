using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ganss.XSS;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using PassengersMonitoring.Common.Extensions;
using PassengersMonitoringApi.Atributes;

namespace PassengersMonitoringApi.Binders
{
    public class HtmlStringBinder : IModelBinder
    {
        private readonly BodyModelBinder _defaultBinder;
        private readonly HtmlSanitizer _sanitizer;

        public HtmlStringBinder(IList<IInputFormatter> formatters, IHttpRequestStreamReaderFactory readerFactory)
        {
            _defaultBinder = new BodyModelBinder(formatters, readerFactory);
            _sanitizer = new HtmlSanitizer();
        }

        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            await _defaultBinder.BindModelAsync(bindingContext);

            if (bindingContext.Result.IsModelSet)
            {
                var properties = bindingContext.Result.Model
                    .GetType()
                    .GetProperties()
                    .Where(p => p.ContainsAttribute<HtmlStringAttribute>() && p.PropertyType == typeof(string))
                    .ToList();

                foreach (var property in properties)
                {
                    var value = property.GetValue(bindingContext.Result.Model, null).ToString();
                    property.SetValue(bindingContext.Result.Model, _sanitizer.Sanitize(value));
                }
            }
        }
    }
}
