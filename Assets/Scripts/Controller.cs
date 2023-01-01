using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;

public class Controller : MonoBehaviour
{
    #region Singleton
    public static Controller Instance;
    #endregion

    [SerializeField] private Mascot[] mascots;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        MascotController.Instance.SetMascot(mascots[Random.Range(0, mascots.Length)]);
        StartCoroutine(IntroductoryDialogue());
    }

    private IEnumerator IntroductoryDialogue()
    {
        MascotController.Instance.SetMascotEmotion(MascotEmotion.Happy);

        if (PlayerPrefs.GetInt(MascotController.Instance.Mascot.name) == 1)
        {
            MascotController.Instance.SetMascotDialog("Ho�geldin! Hadi bir tema se� ve yeni kelimeler ��renelim.");
            yield break;
        }

        MascotController.Instance.SetMascotDialog("Merhaba ben " + MascotController.Instance.Mascot.name + "!");

        yield return new WaitForSeconds(3f);

        MascotController.Instance.SetMascotDialog("Birlikte bir�ok yeni kelime ��renece�iz.");
        PlayerPrefs.SetInt(MascotController.Instance.Mascot.name, 1);

        yield return new WaitForSeconds(5f);

        MascotController.Instance.SetMascotDialog(" Hadi bir tema se� ve yeni kelimeler ��renelim.");
    }

    public void WordsCompleted()
    {
        StartCoroutine(ContinueDialog());
    }

    private IEnumerator ContinueDialog()
    {
        yield return new WaitForSeconds(3f);

        MascotController.Instance.SetMascotEmotion(MascotEmotion.Neutral);
        MascotController.Instance.SetMascotDialog("Hadi bir tema se� ve yeni kelimeler ��renelim.");
    }
}
