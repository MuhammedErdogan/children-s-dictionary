using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ThemePanelController : MonoBehaviour
{

    [SerializeField] private Button[] themeButtons;

    public void Show(List<ThemeData> themeDatas)
    {
        gameObject.SetActive(true);

        for (int i = themeButtons.Length - 1; i >= 0; i--)
        {
            themeButtons[i].gameObject.SetActive(false);
        }
        
        for (int i = themeDatas.Count - 1; i >= 0; i--)
        {
            themeButtons[i].gameObject.SetActive(true);
            themeButtons[i].GetComponent<Image>().sprite = themeDatas[i].themeImage;
            themeButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = themeDatas[i].themeName;
        }
    }

    public void Hide()
    {

    }
}
