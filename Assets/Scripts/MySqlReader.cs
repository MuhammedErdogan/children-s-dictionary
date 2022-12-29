using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using Mono.Data;
using UnityEngine.UI;
using System.Drawing;

public class MySqlReader : MonoBehaviour
{
    private string dbPath;

    public GameObject tst;

    private void Start()
    {
        dbPath = "Data Source=" + Application.persistentDataPath + "/test.sqlite3";
        FindTheme();
    }

    public void FindTheme()
    {
        var dbCon = new SqliteConnection(dbPath);
        dbCon.Open();

        var dbCmd = dbCon.CreateCommand();
        string sqlQuery = "SELECT column_2 FROM resimler2 WHERE column_1 = 1;";
        dbCmd.CommandText = sqlQuery;

        var reader = dbCmd.ExecuteReader();

        while (reader.Read())
        {
            byte[] imageData = reader.GetValue(0) as byte[];
            Texture2D tex = new Texture2D(1, 1);
            tex.LoadImage(imageData);

            tst.GetComponent<Image>().material.mainTexture = tex;

            //System.BitConverter.IsLittleEndian = true;
        }
        try
        {
        }
        catch
        {
            Debug.Log("Data can not readed.");
            dbCon.Close();
            return;
        }
        finally
        {
            dbCon.Close();
        }
    }
}
