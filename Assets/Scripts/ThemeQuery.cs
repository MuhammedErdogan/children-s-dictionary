using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using Mono.Data;
using UnityEngine.UI;
using System.Drawing;

public class ThemeQuery : BaseQuery
{
    [SerializeField] private List<ThemeData> themeDatas = new();

    public override List<T> GetQueryResult<T>() 
    {
        return themeDatas as List<T>;
    }

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Query()
    {
        var dbCon = new SqliteConnection(dbPath);
        dbCon.Open();

        var dbCmd = dbCon.CreateCommand();
        string sqlQuery = "SELECT themeID, theme, image FROM images INNER JOIN themes on themes.imageID = images.imageID;";
        dbCmd.CommandText = sqlQuery;

        var reader = dbCmd.ExecuteReader();

        try
        {
            while (reader.Read())
            {
                int themeID = reader.GetInt32(0);
                string theme = reader.GetString(1);
                byte[] data = (byte[])reader.GetValue(2);

                Texture2D texture = new Texture2D(1, 1);
                texture.LoadImage(data);
                Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);

                themeDatas.Add(new ThemeData() { themeId = themeID, themeName = theme, themeImage = sprite });
            }
        }
        catch
        {
            Debug.Log("Data can not readed.");
        }
        finally
        {
            dbCon.Close();
        }
    }
}
