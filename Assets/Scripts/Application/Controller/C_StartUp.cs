using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class C_StartUp : Controller
{
    public override void Execute(object data)
    {
        //注册控制器
        RegisterController(Consts.E_EnterScene, typeof(C_EnterScene));
        RegisterController(Consts.E_ExitScene, typeof(C_ExitScene));

    }
}
