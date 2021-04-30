using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeApp.COMMON.Entidades
{
    public abstract class BaseDTO : IDisposable
    {
        public string Id { get; set; }


        private bool _isDisposed;

        public void Dispose()
        {

            if (!_isDisposed)
            {
                this._isDisposed = true;
                GC.SuppressFinalize(this);
            }
            
        }
    }
}
