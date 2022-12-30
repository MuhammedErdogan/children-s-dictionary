using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WordPanelController : MonoBehaviour
{
    [SerializeField] private List<WordData> wordDatas = new();

    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI sentence;
    [SerializeField] private TextMeshProUGUI word;

    private void Init()
    {
        SetData(wordDatas[0]);
        wordDatas.RemoveAt(0);
    }

    public void SetData(WordData wordData)
    {
        image.sprite = wordData.image;
        sentence.text = wordData.sentence;
        word.text = wordData.word;
    }

    public void Show(List<WordData> wordDatas)
    {
        gameObject.SetActive(true);
        Debug.Log(wordDatas.Count);
        this.wordDatas = wordDatas;
        Init();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void NextWord()
    {
        if (wordDatas.Count > 0)
        {
            wordDatas.RemoveAt(0);
            if (wordDatas.Count > 0)
            {
                SetData(wordDatas[0]);
            }
            else
            {
                Hide();
            }
        }
    }
}