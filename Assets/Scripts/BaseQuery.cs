using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using Mono.Data;

public class BaseQuery : MonoBehaviour
{
    protected string dbPath;

    protected virtual void Awake()
    {
        dbPath = "Data Source=" + Application.persistentDataPath + "/childrin-s-dictionary-database.sqlite3";
    }

    protected virtual void Query(object[] objects) { }

    public virtual List<T> GetQueryResult<T>(object[] objects)
    {
        return null;
    }
}
