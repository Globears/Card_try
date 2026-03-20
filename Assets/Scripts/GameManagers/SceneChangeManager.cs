
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : SingletonBehaviour<SceneChangeManager> {
    
    //TODO:这里要写Scene的切换，做渐变吧，大概
    public void ChangeScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    public void ChangeToCardGame() {
        ChangeScene("CardGameScene");
    }
}