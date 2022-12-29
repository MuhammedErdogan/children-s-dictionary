using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject themePanel;

    public void ShowThemePanel()
    {
        themePanel.SetActive(true);
    }

    public void HideThemePanel()
    {
        themePanel.SetActive(false);
    }
}
