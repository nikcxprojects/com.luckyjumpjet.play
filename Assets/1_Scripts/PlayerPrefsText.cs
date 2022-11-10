using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPrefsText : MonoBehaviour
{

    private Text text;
    [SerializeField] private string PlayerPrefsName;
    
    void Start()
    {
        text = GetComponent<Text>();
        text.text = PlayerPrefs.GetInt(PlayerPrefsName).ToString();
    }

}
