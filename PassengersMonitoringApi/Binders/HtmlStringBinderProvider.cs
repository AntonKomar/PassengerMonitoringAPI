using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using PassengersMonitoring.Common.Extensions;
using PassengersMonitoringApi.Atributes;

namespace PassengersMonitoringApi.Binders
{
    public class HtmlStringBinderProvider : IModelBinderProvider
    {
        private readonly IList<IInputFormatter> _formatters;
        private readonly IHttpRequestStreamReaderFactory _readerFactory;
        private readonly BodyModelBinderProvider _defaultModelBinderProviderProvider;

        public HtmlStringBinderProvider(IList<IInputFormatter> formatters, IHttpRequestStreamReaderFactory readerFactory)
        {
            _formatters = formatters;
            _readerFactory = readerFactory;
            _defaultModelBinderProviderProvider = new BodyModelBinderProvider(formatters, readerFactory);
        }

        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var modelBinder = _defaultModelBinderProviderProvider.GetBinder(context);

            if (modelBinder != null)
            {
                modelBinder =
                    context.Metadata.ModelType.GetProperties().Any(property => property.ContainsAttribute<HtmlStringAttribute>())
                    ? new HtmlStringBinder(_formatters, _readerFactory)
                    : modelBinder;
            }

            return modelBinder;
        }
    }
}
