using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveFileManager : FileManager
{
    public string m_RedBossFlagName = "RedBossFlag";

    public bool GetRedBossFlag()
    {
        string info = FindAndGet(m_RedBossFlagName);
        return info == "true";
    }

    public void FlagRedBossFlag()
    {
        FindAndPut(m_RedBossFlagName, "true");
    }

    private string[] Find(string text)
    {
        foreach (string[] splitRow in m_SplitRows)
        {
            if (splitRow[0] == text)
            {
                return splitRow;
            }
        }
        return null;
    }

    private string FindAndGet(string text)
    {
        return Find(text)[1];
    }

    private void FindAndPut(string find, string put)
    {
        Find(find)[1] = put;
    }

    public void SaveGame()
    {
        WriteFile();
    }
}
