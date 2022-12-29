using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private ThemePanelController themePanel;

    public void ShowThemePanel()
    {
        Debug.Log("Theme Panel Showed");
        themePanel.Show(Manager.Instance.GetThemeDatas());
    }

    public void HideThemePanel()
    {
        themePanel.Hide();
    }
}
