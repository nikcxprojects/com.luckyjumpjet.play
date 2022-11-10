using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class GameConfigController : MonoBehaviour
{

    [SerializeField] private GameConfig[] _configs;
    [SerializeField] private GameConfig _config;

    public void OpenLevel(int id)
    {
        _config.background = _configs[id].background;
        _config.gem = _configs[id].gem;
        _config.ship = _configs[id].ship;
        _config.id = _configs[id].id;
    }
}
