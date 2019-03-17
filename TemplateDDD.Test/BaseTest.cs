using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using TemplateDDD.CrossCutting;
using TemplateDDD.IoC;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace TemplateDDD.Test
{
    public class BaseTest
    {
        public ServiceProvider _serviceProvider { get; set; }
        public BaseTest()
        {

            ConnectionStrings.TemplateDDDConnection = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\99000663\\Documents\\SampleDB.mdf;Integrated Security=True;";
            var services = new ServiceCollection();
            Mapper.Initialize(cfg =>
            {
                cfg.ValidateInlineMaps = false;
            });
            NativeInjectorBootStrapper.RegisterServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        internal static object[] GetArray(CustomAttributeTypedArgument cata)
        {
            var parameters = new List<object>();
            if (cata.Value.GetType() == typeof(ReadOnlyCollection<CustomAttributeTypedArgument>))
            {
                foreach (CustomAttributeTypedArgument cataElement in (ReadOnlyCollection<CustomAttributeTypedArgument>)cata.Value)
                {
                    parameters.Add(cataElement.Value);
                }
            }
            else
            {
                parameters.Add(cata.Value);
            }
            return parameters.ToArray();
        }

        internal static List<CustomAttributeData> GetAttrobutes(MethodInfo action)
        {
            return action.CustomAttributes
                    .Where(x => x.AttributeType.Name.Equals(nameof(CrossCutting.Attributes.TestAutmatedAttribute)))
                    .ToList();
        }

        internal List<object> GetConstructorParameters(ConstructorInfo constructor)
        {
            var param = new List<object>();
            var paransCtro = constructor.GetParameters();
            foreach (var prm in paransCtro)
            {
                var _service = _serviceProvider.GetService(prm.ParameterType);
                param.Add(_service);

            }

            return param;
        }

        internal static List<MethodInfo> GetActions(List<Type> controlleractionlist, Type controller)
        {
            return controlleractionlist.SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
                .Where(m => m.DeclaringType.Name.Equals(controller.Name) && m.GetCustomAttributes(typeof(CrossCutting.Attributes.TestAutmatedAttribute), true).Any())
                .ToList();
        }

        internal static List<Type> GetControllers(Assembly asm)
        {
            return asm.GetTypes()
           .Where(type => typeof(Microsoft.AspNetCore.Mvc.Controller).IsAssignableFrom(type))
           .ToList();
        }

    }
}
