using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MascotController : MonoBehaviour
{
    #region Singleton
    public static MascotController Instance;
    #endregion

    [SerializeField] private Mascot mascot;
    [SerializeField] private Image mascotImage;
    [SerializeField] private Animator mascotAnimator;

    private void Awake()
    {
        Instance = this;
    }

    public void SetMascot(Mascot mascot)
    {
        this.mascot = mascot;
        mascotImage.sprite = mascot.emotionStructs[0].image;
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

    public void SetMascotEmotion(MascotEmotion emotion, bool isAnimation)
    {
        if (isAnimation)
        {
            mascotAnimator.SetTrigger(emotion.ToString());
        }
        else
        {
            mascotImage.sprite = mascot.emotionStructs[(int)emotion].image;
        }
    }

    public void SetMascotEmotion(int emotion, bool isAnimation)
    {
        if (isAnimation)
        {
            mascotAnimator.SetTrigger(mascot.emotionStructs[emotion].emotion.ToString());
        }
        else
        {
            mascotImage.sprite = mascot.emotionStructs[emotion].image;
        }
    }

    public void SetMascotEmotion(string emotion, bool isAnimation)
    {
        if (isAnimation)
        {
            mascotAnimator.SetTrigger(emotion);
        }
        else
        {
            mascotImage.sprite = mascot.emotionStructs[(int)System.Enum.Parse(typeof(MascotEmotion), emotion)].image;
        }
    }
}
