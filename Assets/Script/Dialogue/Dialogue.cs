using System;
using System.IO;
using UnityEngine;

[System.Serializable]
public class Dialogue
{

    [TextArea(1, 1000)]
    public string[] _names;
    public string[] _sentences;

    public void SetContext(string dialogueTXT) {

        StreamReader sr = new StreamReader(@"..\\Game-Start\\Assets\\Dialogue\\" + dialogueTXT + ".txt", System.Text.Encoding.Default);

        int _nameCount = Convert.ToInt32(sr.ReadLine());
        int _sentenceCount = Convert.ToInt32(sr.ReadLine());

        _names = new string[_nameCount + 1];
        _sentences = new string[_sentenceCount];

        _names[0] = "";

        int lineCount = 0;
        int nameCount = 1;

        string line;

        while (true)
        {
            line = sr.ReadLine();

            if(line == "") { continue; }

            if(line[0] == '0') { 
                SetName(nameCount, line);
                nameCount++;
            }

            if(line[0] == '1') {
                _sentences[lineCount] = line;
                lineCount++;
            }

            if(lineCount == _sentenceCount) { break; }
        }

        sr.Close();
    }

    private void SetName(int nameCount,string line) 
    {
        bool nameCheck = false;

        foreach (char word in line) {

            if (word == '[') { nameCheck = true; }

            else if (word == ']') { nameCheck = false; }

            else if (nameCheck) { _names[nameCount] += word; }
        
        }
    
    }

}


