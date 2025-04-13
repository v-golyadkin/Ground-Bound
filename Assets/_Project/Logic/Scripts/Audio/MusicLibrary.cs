using System;
using UnityEngine;


[Serializable]
public struct Music
{
    public string name;
    public AudioClip clip;
}
public class MusicLibrary : MonoBehaviour
{
    [SerializeField] private Music[] _musics;

    public AudioClip GetClipFromName(string name)
    {
        foreach (var music in _musics)
        {
            if(music.name == name)
            {
                return music.clip;
            }
        }

        return null;
    }
}
