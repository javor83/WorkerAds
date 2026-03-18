namespace WebApplication6.Models
{
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
