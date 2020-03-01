using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileManager : MonoBehaviour
{
    public string m_FileName = "game_save.csv";
    public string m_ColumnDivider = ",";

    private string m_FilePath;
    private string[] m_Rows;
    protected List<string[]> m_SplitRows;

    private StreamReader m_Reader;
    private StreamWriter m_Writer;

    private void Awake()
    {
        m_FilePath = Application.persistentDataPath + "/" + m_FileName;
        ReadFile();
    }

    protected void ReadFile()
    {
        m_Reader = new StreamReader(m_FilePath);
        ReadRows();
        SplitRows();
    }

    private void ReadRows()
    {
        string FileContents = m_Reader.ReadToEnd();
        m_Reader.Close();
        m_Rows = FileContents.Split("\n"[0]);
    }

    private void SplitRows()
    {
        m_SplitRows = new List<string[]>();
        foreach (string row in m_Rows)
        {
            m_SplitRows.Add(row.Split(m_ColumnDivider[0]));
        }
    }

    protected void WriteFile()
    {
        m_Writer = new StreamWriter(m_FilePath);
        bool first = true;
        foreach (string[] splitRow in m_SplitRows)
        {
            foreach (string split in splitRow)
            {
                if (!first)
                {
                    m_Writer.Write(",");
                }
                first = false;
                m_Writer.Write(split);
            }
            m_Writer.Write("\n");
            first = true;
        }
        m_Writer.Close();
    }

    /*protected string ReadFromTable(int row, int column)
    {
        return m_SplitRows[row][column];
    }

    protected void PutToTable(string text, int row, int column)
    {
        m_SplitRows[row][column] = text;
    }*/
}
