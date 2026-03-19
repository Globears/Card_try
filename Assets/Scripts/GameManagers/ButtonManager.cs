

using UnityEngine;


/// <summary>
/// 管理场景内所有按钮的对应效果，因为DontDestroy的单例们会丢绑定
/// 用这个来找单例们
/// </summary>
public class ButtonManager : SingletonBehaviour<ButtonManager>{
    //TODO：
    
    public void NewGameButton() {
        
    }

    public void ContinueGameButton() {
        
    }

    public void SettingButton() {
        
    }

    public void ExitGameButton() {
        Debug.Log("退出游戏按钮被按下");
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}