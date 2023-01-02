using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Net;
using System;

public class ContentQuery : BaseQuery
{
    [SerializeField] private List<WordData> wordDatas = new();

    public override List<T> GetQueryResult<T>(object[] objects)
    {
        Query(objects);
        return wordDatas as List<T>;
    }

    protected override void Awake()
    {
        base.Awake();
        //Query(new object[] { 1 });
    }

    protected override void Query(object[] objects)
    {
        var dbCon = new SqliteConnection(dbPath);
        dbCon.Open();

        int themeID = (int)objects[0];

        var dbCmd = dbCon.CreateCommand();
        string sqlQuery =
            "SELECT theme, wordID ,word, image, sentence \r\n " +
            "FROM words JOIN themes on themes.themeID = words.themeID\r\n" +
            "JOIN images on images.imageID = words.imageID\r\n" +
            "JOIN sentences ON words.sentenceID = sentences.sentenceID \r\n" +
            $"Where themes.themeID = {themeID}";
        dbCmd.CommandText = sqlQuery;

        var reader = dbCmd.ExecuteReader();

        try
        {
            while (reader.Read())
            {
                string theme = reader.GetString(0);
                int wordID = reader.GetInt32(1);
                string word = reader.GetString(2);

                byte[] data = (byte[])reader.GetValue(3);

                Texture2D texture = new Texture2D(1, 1);
                texture.LoadImage(data);
                Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);

                AudioClip audioClip = Resources.Load($"Themes/{themeID}/{wordID}") as AudioClip;
                int v = wordID % 1000;
                AudioClip wordAudio = Resources.Load($"Themes/{themeID}/{((wordID - v) * 10) + v}") as AudioClip;
                Debug.Log(((wordID - v) * 10) + v);
                string sentence = reader.GetString(4);

                wordDatas.Add(new WordData() { theme = theme, word = word, sentence = sentence, image = sprite, audio = audioClip, wordAudio = wordAudio });
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