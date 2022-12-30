using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-101)]
public class Manager : MonoBehaviour
{
    public static Manager Instance;

    [SerializeField] private ThemeQuery themeQuery;
    [SerializeField] private ContentQuery wordQuery;
    
    public List<ThemeData> GetThemeDatas => themeQuery.GetQueryResult<ThemeData>(null);

    public List<WordData> GetWordDatas(int i) => wordQuery.GetQueryResult<WordData>(new object[] { i });

    private void Awake()
    {
        Instance = this;
    }
}
