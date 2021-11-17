using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class KeyConfig
{
    public struct Action
    {
        public KeyCode front;
        public KeyCode back;
        public KeyCode left;
        public KeyCode right;
        public KeyCode jump;
        public KeyCode sprint;
        public KeyCode events;
        public KeyCode inventory;

        public void ReadKeys()
        {
            StreamReader sr = new StreamReader(@"..\\Game Start\\Assets\\TextBooks\\KeyConfig.txt", System.Text.Encoding.Default);

            front = (KeyCode)Convert.ToInt32(sr.ReadLine());
            back = (KeyCode)Convert.ToInt32(sr.ReadLine());
            left = (KeyCode)Convert.ToInt32(sr.ReadLine());
            right = (KeyCode)Convert.ToInt32(sr.ReadLine());
            jump = (KeyCode)Convert.ToInt32(sr.ReadLine());
            sprint = (KeyCode)Convert.ToInt32(sr.ReadLine());
            events = (KeyCode)Convert.ToInt32(sr.ReadLine());
            inventory = (KeyCode)Convert.ToInt32(sr.ReadLine());

            sr.Close();
        }
    }

    public Action action;
    
}
