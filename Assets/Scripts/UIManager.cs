using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region Singleton
    public static UIManager Instance;
    #endregion

    [SerializeField] private ThemePanelController themePanel;
    [SerializeField] private WordPanelController wordPanel;

    private void Awake()
    {
        Instance = this;
        themePanel.Init(Manager.Instance.GetThemeDatas);
    }
    
    public void ShowThemePanel()
    {
        Debug.Log("Theme Panel Showed");
        themePanel.Show();
    }

    public void HideThemePanel()
    {
        Debug.Log("Theme Panel Hided");
        themePanel.Hide();
    }

    public void ShowWordPanel(int themeId)
    {
        Debug.Log("Word Panel Showed.");
        wordPanel.Show(Manager.Instance.GetWordDatas(themeId));
    }

    public void HideWordPanel()
    {
        Debug.Log("Word Panel Hided.");
        wordPanel.Hide();
    }
}
