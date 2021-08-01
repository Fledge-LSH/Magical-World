using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : ApplicationBase<Game>
{

    /// <summary>
    /// 加载场景
    /// </summary>
    /// <param name="sceneIndex">场景索引</param>
    public void LoadScene(int sceneIndex)
    {
        //发送离开当前场景事件
        SceneArg e = new SceneArg() { SceneIndex = SceneManager.GetActiveScene().buildIndex };
        SendEvent(Consts.E_ExitScene, e);
        //异步加载新场景
        SceneLoadManager loader = new SceneLoadManager();
        loader.LoadScene(sceneIndex, LoadSceneWay.Automatic);

    }
    /// <summary>
    /// 加载一个新场景时调用
    /// </summary>
    /// <param name="level"></param>
    void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        //发送既进入场景事件
        SceneArg e = new SceneArg() { SceneIndex = scene.buildIndex };
        SendEvent(Consts.E_EnterScene, e);
    }
    /// <summary>
    /// 游戏入口
    /// </summary>
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneLoaded += OnSceneLoad;

        //注册启动命令
        RegisterController(Consts.E_StartUp, typeof(C_StartUp));
        SendEvent(Consts.E_StartUp);
    }
}
