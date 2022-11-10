using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Game Config", order = 50)]
public class GameConfig : ScriptableObject
{
    public Sprite background;
    public Sprite ship;
    public Sprite gem;
    public int id;
}
