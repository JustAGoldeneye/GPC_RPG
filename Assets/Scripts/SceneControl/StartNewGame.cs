using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartNewGame : LoadGameArea1
{

    public void LoadAndDelete()
    {
        GetComponent<SaveFileManager>().DeleteSave();
        Load();
    }
}
