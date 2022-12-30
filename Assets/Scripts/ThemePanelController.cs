using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ThemePanelController : MonoBehaviour
{

    [SerializeField] private Button[] themeButtons;

    public void Init(List<ThemeData> themeDatas)
    {
        for (int i = themeButtons.Length - 1; i >= 0; i--)
        {
            themeButtons[i].gameObject.SetActive(false);
            //themeButtons[i].onClick.RemoveAllListeners();
        }

        for (int i = 0; i < themeDatas.Count; i++)
        {
            Debug.Log(themeDatas[i].themeId);
            themeButtons[i].gameObject.SetActive(true);
            //themeButtons[i].onClick.AddListener(() => UIManager.Instance.ShowWordPanel(themeDatas[i].themeId));
            themeButtons[i].GetComponent<Image>().sprite = themeDatas[i].themeImage;
            themeButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = themeDatas[i].themeName;
        }
    }
    
    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
