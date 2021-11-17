using System;
using System.IO;
using UnityEngine;

[System.Serializable]
public class Dialogue
{

    public struct Chara
    {
        public string name;
        public int posiX;
    }

    [TextArea(1, 1000)]
    public string[] _sentences;
    public Chara[] _charas;

    public void SetContext(string dialogueTXT) {

        StreamReader sr = new StreamReader(@"..\\Game Start\\Assets\\TextBooks\\" + dialogueTXT + ".txt", System.Text.Encoding.Default);

        int _nameCount = Convert.ToInt32(sr.ReadLine());
        int _sentenceCount = Convert.ToInt32(sr.ReadLine());

        _charas = new Chara[_nameCount + 1];
        _sentences = new string[_sentenceCount];

        _charas[0].name = "";
        _charas[0].posiX = 0;

        int lineCount = 0;
        int nameCount = 1;
        int posiCount = 1;

        string line;

        while (true)
        {
            line = sr.ReadLine();

            if(line == "") { continue; }

            if(line[0] == '0') { 
                SetName(nameCount, line);
                nameCount++;
            }

            else if (line[0] == 'x')
            {
                SetPosiX(posiCount, line);
                posiCount++;
            }

            else if(line[0] == '1') {
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

            else if (nameCheck) { _charas[nameCount].name += word; }
        
        }
    
    }

    private void SetPosiX(int posiCount, string line)
    {
        bool posiCheck = false;
        string temp = "";

        foreach (char word in line)
        {
            if (word == '[') { posiCheck = true; }

            else if (word == ']') { posiCheck = false; }

            else if (posiCheck) { temp += word; }
        }

        _charas[posiCount].posiX = System.Convert.ToInt32(temp);
    }

}


