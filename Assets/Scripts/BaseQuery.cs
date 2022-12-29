using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class BaseQuery : MonoBehaviour
{
    protected string dbPath;

    protected virtual void Awake()
    {
        dbPath = "Data Source=" + Application.persistentDataPath + "/childrin-s-dictionary-database.sqlite3";
        Query();
    }

    protected virtual void Query() { }

    public virtual List<T> GetQueryResult<T>()
    {
        return null;
    }
}
