﻿using Castle.DynamicProxy;
using Microsoft.Build.Logging;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Reflection;
using IInterceptor = Castle.DynamicProxy.IInterceptor;

namespace Core.Utilities.Interceptors
{
 
        public class AspectInterceptorSelector : IInterceptorSelector
        {
            public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
            {
                var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                    (true).ToList();
                var methodAttributes = type.GetMethod(method.Name)
                    .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
                classAttributes.AddRange(methodAttributes);
        
              

                return classAttributes.OrderBy(x => x.Priority).ToArray();
            }
        }
    
}
