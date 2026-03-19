using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class SaveData {
    // 所有已保存的套牌
    Dictionary<int,Deck> decks;
    //     启用的套牌
    int EnableDeck;
    // 所有已解锁的关卡的进度
    Dictionary<Level,bool> levels;
    //     关卡是否完成
    //     关卡的进度是否完成
    // 所有已解锁的书本
    // 所有协助者的进度
    //     协助者的进度是否完成
    // 所有剧情的进度
    //     还不知道存啥
}

public class PermanentSaveData {
    // 包含游戏设置 存档数量等
    public static int BGM_VOLUME;
    public static int SFX_VOLUME;
    public static bool BGM_SWITCH;
    public static bool SFX_SWITCH;
    public static Dictionary<int,bool> SAVESLOTSSWITCH;
}

public class SaveManager : SingletonBehaviour<SaveManager> {

    public void Load() {
        
    }

    public void LoadSaveData() {
        //从本地文件读存档分别保存为SaveData和PermanentSaveData
    }

    public void LoadPermanentSaveData() {
        
    }

    public void WriteSaveData() {
        //保存当前的存档
    }

    public void WritePermanentSaveData() {
        //保存当前的永久存档
    }
}