using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ModelApi.Test
{

    [TestClass]
    public class AutomatedTest : BaseTest
    {
        [TestMethod]
        public void AutomaticTest()
        {
            Assembly asm = Assembly.LoadFrom("ModelApi.Application.dll");
            List<Type> controlleractionlist = GetControllers(asm);
            foreach (var controller in controlleractionlist)
            {
                ConstructorInfo constructor = controller.GetConstructors()[0];
                List<MethodInfo> actionList = GetActions(controlleractionlist, controller);
                foreach (var action in actionList)
                {
                    List<object> param = GetConstructorParameters(constructor);
                    var ctro = constructor.Invoke(param.ToArray());
                    List<CustomAttributeData> attributeInfo = GetAttrobutes(action);
                    foreach (var attr in attributeInfo)
                    {
                        var parameters = GetArray(attr.ConstructorArguments.FirstOrDefault());
                        var result = action.Invoke(ctro, parameters);
                    }
                }
            }
            var boll = true;
            Assert.IsTrue(boll);
        }
    }
}
