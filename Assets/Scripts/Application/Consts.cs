using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Consts
{
    //view
    public const string V_Role = "V_Role";
    //model
    public const string M_Role = "M_Role";
    //controller
    public const string E_StartUp = "E_StartUp";    //游戏开始事件
    public const string E_ExitScene = "E_ExitScene";    //离开场景事件
    public const string E_EnterScene = "E_EnterScene";  //进入场景事件


}

public enum LoadSceneWay
{
    NeedKey,
    Automatic
}
