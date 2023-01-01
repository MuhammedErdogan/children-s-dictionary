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
            "SELECT wordID ,word, image, audio, sentence \r\n " +
            "FROM words JOIN themes on themes.themeID = words.themeID\r\n" +
            "JOIN images on images.imageID = words.imageID\r\n" +
            "JOIN audios on audios.audioID = words.audioID\r\n" +
            "JOIN sentences ON words.sentenceID = sentences.sentenceID \r\n" +
            $"Where themes.themeID = {themeID}";
        dbCmd.CommandText = sqlQuery;

        var reader = dbCmd.ExecuteReader();

        try
        {
            while (reader.Read())
            {
                int wordID = reader.GetInt32(0);
                string word = reader.GetString(1);

                byte[] data = (byte[])reader.GetValue(2);

                Texture2D texture = new Texture2D(1, 1);
                texture.LoadImage(data);
                Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);

                //byte[] audioData = (byte[])reader.GetValue(2);

                //byte[] audioDataCuted = new byte[audioData.Length - 44];
                //Array.Copy(audioData, 44, audioDataCuted, 0, audioData.Length - 44);
                //float[] audio = new float[audioDataCuted.Length / 4];

                //for (int i = 1; i < audio.Length; i++)
                //{
                //    float sample = BitConverter.ToSingle(audioData, i * 4);
                //    sample *= 2147483647f;
                //    audio[i] = sample;
                //}

                //AudioClip audioClip = AudioClip.Create(word, audio.Length, 2, 44100, false);
                //audioClip.SetData(audio, 0);

                AudioClip audioClip = Resources.Load($"Themes/{themeID}/{wordID}") as AudioClip;

                string sentence = reader.GetString(4);

                wordDatas.Add(new WordData() { word = word, sentence = sentence, image = sprite, audio = audioClip });
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