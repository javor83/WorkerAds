using GCommon.Captions;
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
                            
                            
                            bindingContext.ModelState.AddModelError(bindingContext.ModelName, string.Format(valid_Worker.Required_Field, text_Worker.Price));
                    }

                }
                else
                {
                    bindingContext.ModelState.AddModelError(bindingContext.ModelName, string.Format(valid_Worker.Required_Field, text_Worker.Price));
                }
            }
            return Task.CompletedTask;

        }
    }


}
