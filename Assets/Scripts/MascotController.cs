using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MascotController : MonoBehaviour
{
    #region Singleton
    public static MascotController Instance;
    #endregion

    [SerializeField] private TextMeshProUGUI mascotName;
    [SerializeField] private Mascot mascot;
    [SerializeField] private Image mascotImage;
    [SerializeField] private TextMeshProUGUI mascotDialogText;

    public Mascot Mascot => mascot;

    private Coroutine textCoroutine;

    private void Awake()
    {
        Instance = this;
    }

    public void SetMascot(Mascot mascot)
    {
        this.mascot = mascot;
        mascotImage.sprite = mascot.emotionStructs[0].image;
        mascotName.text = mascot.name.ToUpper();
    }

    public void SetMascotEmotion(MascotEmotion emotion)
    {
        mascotImage.sprite = mascot.emotionStructs[(int)emotion].image;
    }

    public void SetMascotEmotion(int emotion)
    {
        mascotImage.sprite = mascot.emotionStructs[emotion].image;
    }

    public void SetMascotEmotion(string emotion)
    {
        mascotImage.sprite = mascot.emotionStructs[(int)System.Enum.Parse(typeof(MascotEmotion), emotion)].image;
    }

    public void SetMascotDialog(string sentence, float delay = .1f)
    {
        if (textCoroutine != null) StopCoroutine(textCoroutine);

        textCoroutine = StartCoroutine(mascotDialogText.AnimateText(sentence, delay));
    }
}
