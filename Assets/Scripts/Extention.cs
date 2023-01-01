using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public static class Extention
{
    public static IEnumerator AnimateText(this TextMeshProUGUI textMeshPro, string text, float animationSpeed = 0.1f)
    {
        textMeshPro.text = "";
        int i = 0;
        while (i < text.Length)
        {
            textMeshPro.text += text[i++];
            yield return new WaitForSeconds(animationSpeed);
        }
    }
}