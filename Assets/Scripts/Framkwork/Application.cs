using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public abstract class ApplicationBase<T> : Singleton<T>
    where T : MonoBehaviour
{
    //注册控制器
    protected void RegisterController(string eventName, Type controllerType)
    {
        MVC.RegisterController(eventName, controllerType);
    }

    protected void SendEvent(string eventName, object data = null)
    {
        MVC.SendEvent(eventName, data);
    }
}
