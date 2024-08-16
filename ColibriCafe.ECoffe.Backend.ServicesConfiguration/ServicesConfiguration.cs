using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ColibriCafe.ECoffe.Backend.ServicesConfiguration;

public static class ServicesConfiguration
{
    public static IServiceCollection ConfigureServices(this IServiceCollection collection, string assemblyLocation,
        bool isClass = false)
    {
        IEnumerable<Type> service = Assembly.LoadFrom(assemblyLocation)
            .GetTypes()
            .Where(type => type.IsAbstract == false
                           && type.IsInterface == false
                           && type.IsEnum == false
                           && Regex.IsMatch(type.Name, "Nullable|Attribute|[<>]") == false
                           && type.BaseType?.Name != "DbContext");

        service.ToList().ForEach(type => 
            type.GetInterfaces().ToList()
                .ForEach(interfaceType => collection.TryAddScoped(interfaceType, type)));

        if (isClass)
        {
            service.ToList().ForEach(type =>
                collection.TryAddScoped(type));
        }

        return collection;
    }
}