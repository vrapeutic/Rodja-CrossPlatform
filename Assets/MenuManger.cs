using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//enum MenuVar { Time, Level, Environment, Track ,Npc ,Lang}

[Serializable]
public class MenuVariables
{
    public int time = 0;
    public int level = 1;
    public string Environment_name = "Desert";
    public string Collectable_name = "desert_jewel";
    public string Track_name = "square";
    public string Character = "boy";
    public string language = "eng";
}

public class MenuManger : MonoBehaviour
{
    
    public MenuVariables menu;
    

    private void Awake()
    {
       
        if (FindObjectsOfType<MenuManger>().Length > 1)
            Destroy(FindObjectsOfType<MenuManger>()[1].gameObject);
        DontDestroyOnLoad(this.gameObject);
    }

    public void SetLevel(int _level)
    {
        menu.level = _level;
    }

    public void SetLevelTime(int _time)
    {
        menu.time = _time;
    }

    public void SetLang(string _lang)
    {
        menu.language = _lang;
    }

    public void SetNpc(string _npc)
    {
        menu.Character = _npc;
    }

    public void SetEnvironment(string _Enviro)
    {
        menu.Environment_name = _Enviro;
    }

    public void SetTrack(string _track)
    {
        menu.Track_name = _track;
    }

    public void SetCollactable_Name(string _name)
    {
        menu.Collectable_name = _name;
    }
}