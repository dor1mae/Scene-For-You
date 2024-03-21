using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface ICanLoadSave<T>
{
    void LoadSave(T data, Action<bool> callback = null);
}

