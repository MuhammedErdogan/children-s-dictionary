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
    public string theme;
    public string word;
    public string sentence;
    public Sprite image;
    public AudioClip audio;
    public AudioClip wordAudio;
}

[System.Serializable]
public struct Mascot
{
    public Gender gender;
    public string name;
    public MascotEmotionStruct[] emotionStructs;
}

[System.Serializable]
public struct MascotEmotionStruct
{
    public MascotEmotion emotion;
    public Sprite image;
}