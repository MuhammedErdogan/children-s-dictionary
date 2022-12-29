using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] private ThemeQuery themeQuery;


    public List<ThemeData> GetThemeDatas() => themeQuery.GetQueryResult<ThemeData>();
}
