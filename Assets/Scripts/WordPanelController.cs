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

    private int totalWordCount;

    private void Init()
    {
        totalWordCount = wordDatas.Count;
        Camera.main.GetComponent<AudioSource>().clip = wordDatas[0].audio;
        SetData(wordDatas[0]);
        wordDatas.RemoveAt(0);

        MascotController.Instance.SetMascotEmotion(MascotEmotion.Happy);
        MascotController.Instance.SetMascotDialog("Hadi ilk kelimemizle ba�layal�m!", .05f);
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
            SetEmotion(wordDatas.Count);
            if (wordDatas.Count > 0)
            {
                Camera.main.GetComponent<AudioSource>().clip = wordDatas[0].audio;
                SetData(wordDatas[0]);
            }
            else
            {
                MascotController.Instance.SetMascotEmotion(MascotEmotion.VeryHappy);
                Hide();
            }
        }
    }

    private void SetEmotion(int count)
    {
        if (count == 0)
        {
            MascotController.Instance.SetMascotEmotion(MascotEmotion.Congrulation_2);
            MascotController.Instance.SetMascotDialog("Tebrikler! �ok faydal� kelimeler ��rendik.", .05f);
            Controller.Instance.WordsCompleted();
            return;
        }

        if (count == totalWordCount - 2)
        {
            MascotController.Instance.SetMascotEmotion(MascotEmotion.Happy);
            MascotController.Instance.SetMascotDialog("�ok iyi gidiyorsun!", .05f);
            return;
        }

        if (count == (int)(totalWordCount / 2))
        {
            MascotController.Instance.SetMascotEmotion(MascotEmotion.Happy);
            MascotController.Instance.SetMascotDialog("Daha �imdiden bir�ok kelime ��rendik.", .05f);
        }
        else if (count == (int)(totalWordCount / 3))
        {
            MascotController.Instance.SetMascotEmotion(MascotEmotion.VeryHappy);
            MascotController.Instance.SetMascotDialog("Neredeyse bitti. �ok iyi ilerliyorsun.", .05f);
        }
        else if (count == (int)(totalWordCount / 4))
        {
            MascotController.Instance.SetMascotEmotion(MascotEmotion.Congrulation);
            string theme = wordDatas[0].theme;
            string s = theme[theme.Length - 2] == 'e' ? "i" : "�";
            MascotController.Instance.SetMascotDialog($"{theme}{s} �ok iyi ��reniyorsun. Hadi son birka� kelime daha ��renelim.", .05f);
        }
    }

    public void PlayAudio()
    {
        Camera.main.GetComponent<AudioSource>().Play();
    }
}