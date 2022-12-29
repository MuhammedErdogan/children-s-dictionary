using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-101)]
public class Manager : MonoBehaviour
{
    public static Manager Instance;
    
    [SerializeField] private ThemeQuery themeQuery;

    public List<ThemeData> GetThemeDatas() => themeQuery.GetQueryResult<ThemeData>();

    private void Awake()
    {
        Instance = this;
    }
}
