using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            //defensive coding 
            //burada yanlış bir tip gelmesin diye kontrol ekleniyor
            //çünkü attirubute ler type of ile atanıyor ve onu kontrol ediyoruz.

            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            //reflaction = çalışma anında bir şeyleri çalıştırmamızı sağlar.
            //Activator.CreateInstance burada reflection yapısıdır.
            //ProductValidator ın bir örneğini oluştur.
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            //ProductValidator ın çalışma tipini bul.
            //ProductValidator'ın base typenı bul onun generic'teki type ının  ilkini bul bizde bu Product 
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            //parametrelerini bul artık
            //invocation = metot
            //parametrelerine bak ve entityType 'ini bul.
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            //her bir parametre için tek tek gez ve ValidationTool'u kullanarak validate et.
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
