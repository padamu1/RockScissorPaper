using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class SpriteAtlasManager : MonoSingleton<SpriteAtlasManager>
{

    private Dictionary<string, SpriteAtlas> SpriteAtlases = new Dictionary<string, SpriteAtlas>();

    void Start()
    {
        UnityEngine.U2D.SpriteAtlasManager.atlasRequested += RequestAtlas;
    }

    void OnApplicationQuit()
    {
        UnityEngine.U2D.SpriteAtlasManager.atlasRequested -= RequestAtlas;
    }

    public void RequestAtlas(string _key, System.Action<SpriteAtlas> callback)
    {
        bool exist = ExistSpriteAtlas(_key);
        if (false == exist)
        {
            var result = Resources.Load<SpriteAtlas>(_key);
            if (result == null)
            {
                Debug.LogError($"[SpriteAtlas]  Load Error ::{_key} !! ");
                return;
            }
            SpriteAtlases.Add(_key, result);
        }

        callback(GetSpriteAtlas(_key));
    }

    private bool ExistSpriteAtlas(string _key)
    {
        if (SpriteAtlases == null)
        {
            Debug.LogError($"[SpriteAtlas]  ExistSpriteAtlas Initalize Error  !! ");
            return false;
        }

        return SpriteAtlases.ContainsKey(_key);
    }

    private SpriteAtlas GetSpriteAtlas(string _key)
    {
        if (false == ExistSpriteAtlas(_key))
            return null;

        SpriteAtlases.TryGetValue(_key, out SpriteAtlas returnValue);

        return returnValue;
    }
}