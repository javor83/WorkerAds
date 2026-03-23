using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GCommon.ModelBinder
{
    public class DecimalBinderProvider : IModelBinderProvider
    {
        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.ModelType == typeof(decimal) || context.Metadata.ModelType == typeof(decimal?))
            {
                return new MoneyModelBinder();
            }
            return null;
        }
    }
}
