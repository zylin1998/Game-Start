using System;
using System.IO;
using UnityEngine;

[System.Serializable]
public class KeyConfig
{

    public struct Action
    {
        public string keyName;
        public KeyCode KeyCode;
    }

    public Action[] actions;
    public int _actionCount;

    public void ReadKeys()
    {
        string path = Application.dataPath + "\\TextBanks\\KeyConfig.txt";
        //Debug.Log(path);
        StreamReader sr = new StreamReader(path, System.Text.Encoding.Default);

        _actionCount = Convert.ToInt32(sr.ReadLine());
        int _lineCount = 0;

        actions = new Action[_actionCount];

        string line;
        while (true)
        {
            bool failure = true;

            line = sr.ReadLine();

            if(line != "") { failure = SplitLine(line, _lineCount); }

            if (!failure) { _lineCount++; }

            if(_lineCount == _actionCount) { break; }
        }

        sr.Close();
    }

    public void WriteKeys(Action[] actions) 
    {
        string path = Application.dataPath + "\\TextBanks\\KeyConfig.txt";

        StreamWriter sw = new StreamWriter(path);

        string line;

        line = _actionCount.ToString();
        sw.WriteLine(line);

        line = "";
        sw.WriteLine(line);

        foreach (Action action in actions)
        {
            line = "[" + action.keyName + "] {" + Convert.ToInt32(action.KeyCode).ToString() + "}";
            sw.WriteLine(line);
        }

        sw.Close();
    }

    private bool SplitLine(string line, int lineCount) 
    {
        int typechange = 0;
        string name = "";
        string number = "";

        if(line[0] == '[') 
        { 
            foreach(char word in line) 
            { 
                if(word == ']' || word == '}') { typechange = 0; }

                else if(word == '[') { typechange = 1; }

                else if(word == '{') { typechange = 2; }

                else if(typechange == 1) { name += word; }

                else if(typechange == 2) { number += word; }
            }

            actions[lineCount].keyName = name;
            actions[lineCount].KeyCode = (KeyCode)Convert.ToInt32(number);

            return false;
        }

        return true;
    }
}
