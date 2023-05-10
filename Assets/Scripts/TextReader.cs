using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TextReader : MonoBehaviour
{
    private List<string> textList = new List<string>();

    void Awake()
    {
        ReadText();
    }

    private void ReadText()
    {
        string line;

        // Read the file and display it line by line.  
        StreamReader file = new StreamReader(@"words.txt");
        while ((line = file.ReadLine()) != null)
        {
            textList.Add(line);
        }
        file.Close();
    }

    public List<string> GetTextList()
    {
        return textList;
    }
}
