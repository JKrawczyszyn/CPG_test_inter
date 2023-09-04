using System;
using UnityEngine;

[CreateAssetMenu(fileName = "BoardConfig", menuName = "ScriptableObjects/BoardConfig")]
public class BoardConfig : ScriptableObject
{
    private const string fileName = "BoardConfig";

    private Lazy<BoardConfigJson> config;

    public int Width => config.Value.Width;
    public int Height => config.Value.Height;

    public void Initialize()
    {
        config = new Lazy<BoardConfigJson>(LoadConfig);
    }

    private static BoardConfigJson LoadConfig()
    {
        TextAsset asset = Resources.Load<TextAsset>(fileName);
        string json = asset.text;

        return JsonUtility.FromJson<BoardConfigJson>(json);
    }

    internal class BoardConfigJson
    {
        public int Width;
        public int Height;
    }
}