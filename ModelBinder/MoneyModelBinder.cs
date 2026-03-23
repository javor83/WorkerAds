using GCommon.ValidationMessage;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Globalization;

namespace GCommon.ModelBinder
{

    public class MoneyModelBinder : IModelBinder
    {
        

        Task IModelBinder.BindModelAsync(ModelBindingContext bindingContext)
        {
            var vprov = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (vprov != ValueProviderResult.None)
            {
                string? value = vprov.FirstValue;
                if (value != null)
                {
                    decimal x_bg = 0;
                    if (Decimal.TryParse(value,
                        NumberStyles.Any | NumberStyles.AllowDecimalPoint,
                        new CultureInfo("bg-bg"),
                        out x_bg))
                    {
                        bindingContext.Result = ModelBindingResult.Success(x_bg);
                    }
                    else
                    if (Decimal.TryParse(value,
                        NumberStyles.Any | NumberStyles.AllowDecimalPoint,
                        new CultureInfo("en-us"),
                        out x_bg))
                    {
                        bindingContext.Result = ModelBindingResult.Success(x_bg);
                    }
                    else
                    {
                        bindingContext.ModelState.AddModelError(bindingContext.ModelName, valid_Worker.Range_Price);
                    }

                }
                else
                {
                    bindingContext.ModelState.AddModelError(bindingContext.ModelName, valid_Worker.Range_Price);
                }
            }
            return Task.CompletedTask;

        }
    }


   


    //public class PointListModelBinder : IModelBinder
    //{
    //    Task IModelBinder.BindModelAsync(ModelBindingContext bindingContext)
    //    {


    //        var vprov = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
    //        if (vprov != ValueProviderResult.None)
    //        {
    //            string? value = vprov.FirstValue;
    //            if (value != null)
    //            {

    //                var comma_list = PointCards.FromString(value);
    //                if (comma_list != null)
    //                {
    //                    bindingContext.Result = ModelBindingResult.Success(comma_list);
    //                }
    //                else
    //                {
    //                    bindingContext.ModelState.AddModelError(bindingContext.ModelName, "Invalid points");
    //                }
    //            }
    //            else
    //            {
    //                bindingContext.ModelState.AddModelError(bindingContext.ModelName, "Missing points");
    //            }
    //        }


    //        return Task.CompletedTask;
    //    }
    //}

    //public class PointListModelBinderProvider : IModelBinderProvider
    //{
    //    public IModelBinder? GetBinder(ModelBinderProviderContext context)
    //    {
    //        if (context.Metadata.ModelType == typeof(PointCards))
    //        {
    //            return new PointListModelBinder();
    //        }
    //        return null;
    //    }
    //}

    //builder.Services.AddControllersWithViews

    //(
    //    options =>
    //    {
    //        options.ModelBinderProviders.Insert(0, new StringListModelBinderProvider());
    //        options.ModelBinderProviders.Insert(1, new PointListModelBinderProvider());
    //    }
    //);
}
