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

        AudioSource audioSource = Camera.main.GetComponent<AudioSource>();
        audioSource.clip = wordDatas[0].wordAudio;
        audioSource.Play();

        StartCoroutine(waitForSetAudio(wordDatas[0].audio));
        
        SetData(wordDatas[0]);
        wordDatas.RemoveAt(0);

        MascotController.Instance.SetMascotEmotion(MascotEmotion.Happy);
        MascotController.Instance.SetMascotDialog("Hadi ilk kelimemizle başlayalım!", .05f);
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
                var audioSource = Camera.main.GetComponent<AudioSource>();
                audioSource.clip = wordDatas[0].wordAudio;
                audioSource.Play();

                StartCoroutine(waitForSetAudio(wordDatas[0].audio));
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
            MascotController.Instance.SetMascotDialog("Tebrikler! Çok faydalı kelimeler öğrendik.", .05f);
            Controller.Instance.WordsCompleted();
            return;
        }

        if (count == totalWordCount - 2)
        {
            MascotController.Instance.SetMascotEmotion(MascotEmotion.Happy);
            MascotController.Instance.SetMascotDialog("Çok iyi gidiyorsun!", .05f);
            return;
        }

        if (count == (int)(totalWordCount / 2))
        {
            MascotController.Instance.SetMascotEmotion(MascotEmotion.Happy);
            MascotController.Instance.SetMascotDialog("Daha şimdiden birçok kelime öğrendik.", .05f);
        }
        else if (count == (int)(totalWordCount / 3))
        {
            MascotController.Instance.SetMascotEmotion(MascotEmotion.VeryHappy);
            MascotController.Instance.SetMascotDialog("Neredeyse bitti. Çok iyi ilerliyorsun.", .05f);
        }
        else if (count == (int)(totalWordCount / 4))
        {
            MascotController.Instance.SetMascotEmotion(MascotEmotion.Congrulation);
            string theme = wordDatas[0].theme;
            string s = theme[theme.Length - 2] == 'e' ? "i" : "ı";
            MascotController.Instance.SetMascotDialog($"{theme}{s} çok iyi öğreniyorsun. Hadi son birkaç kelime daha öğrenelim.", .05f);
        }
    }

    public void PlayAudio()
    {
        Camera.main.GetComponent<AudioSource>().Play();
    }

    IEnumerator waitForSetAudio(AudioClip clip)
    {
        yield return new WaitForSeconds(1);

        Camera.main.GetComponent<AudioSource>().clip = clip;

    }
}