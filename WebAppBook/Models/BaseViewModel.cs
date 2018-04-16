using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace WebAppBook.Models
{
    /*
     * Os métodos Load e Extract irão apresentar problemas se a Domain.Entity tiver propriedades não contempladas na ViewModel.
     * Para solução deste eventual problema, seria interessante tratar leitura de atributos para Load e Extract (TODO)
    */ 

    public abstract class BaseViewModel<T>
    {
        private object GetInstance()
        {
            Type type = typeof(T);

            return Activator.CreateInstance(type);
        }

        public void Load(T entity)
        {
            foreach (PropertyInfo propertyInfo in entity.GetType().GetProperties())
            {
                this.GetType().GetProperty(propertyInfo.Name).SetValue(this, propertyInfo.GetValue(entity));
            }
        }

        public T Extract()
        {
            object extracted = GetInstance();

            foreach (PropertyInfo propertyInfo in extracted.GetType().GetProperties())
            {
                propertyInfo.SetValue(extracted, this.GetType().GetProperty(propertyInfo.Name).GetValue(this));
            }

            return (T)(extracted);
        }
    }
}