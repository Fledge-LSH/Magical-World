using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{

    /// <summary>
    /// 加载场景
    /// </summary>
    /// <param name="sceneIndex">场景索引</param>
    /// <param name="way">加载方式  Automaic/NeedKey  自动跳转/按下任意键跳转</param>
    public void LoadScene(int sceneIndex,LoadSceneWay way) 
    {
        StartCoroutine(LoadLevel(sceneIndex, way));
    }

    IEnumerator LoadLevel(int sceneIndex,LoadSceneWay way) 
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        switch (way) 
        {
            case LoadSceneWay.Automatic:
                operation.allowSceneActivation = true;
                while (!operation.isDone) 
                {
                    yield return null;
                }
                break;
            case LoadSceneWay.NeedKey:
                operation.allowSceneActivation = false;
                while (!operation.isDone)
                {
                    if (operation.progress >= 0.9f)
                    {
                        if (Input.anyKeyDown)
                        {
                            operation.allowSceneActivation = true;
                        }
                    }
                    yield return null;
                }
                break;
        }
    }
}
