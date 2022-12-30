using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct ThemeData
{
    public int themeId;
    public string themeName;
    public Sprite themeImage;
}

[System.Serializable]
public struct WordData
{
    public int themeId;
    public string word;
    public string sentence;
    public Sprite image;
    public AudioClip audio;
}