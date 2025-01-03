using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("this is not a validation class");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);        //reflection çalışma anında örn productvalidatörün bir instance ını oluştur
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];                  // base typı bul çalışma tipini bul
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);           //ilgili methodun parametrelerini bul
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);                      //validationtool u kullanarak tek tek gez doğrula
            }
        }
    }
}
