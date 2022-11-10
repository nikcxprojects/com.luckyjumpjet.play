using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{

    [Serializable]
    public struct ObjectToSpawn
    {
        public float spawnTime;
        public GameObject prefab;
    }

    
    [Header("MainSettings")]
    [SerializeField] private ObjectToSpawn _gem;
    [SerializeField] private ObjectToSpawn _enemy;
    
    [SerializeField] private GameConfig _config;
    [SerializeField] private Transform _camera;

    [Space]
    
    [Header("UI")]
    [SerializeField] private Text _moneyText;
    [SerializeField] private Text _moneyText2;
    [SerializeField] private Image _moneyImage;
    [SerializeField] private Image _moneyImage2;
    [SerializeField] private GameObject _gameOverUI;
    [SerializeField] private AudioClip _gameOverClip;



    private int _money;
    
    private void Start()
    {
        CreateBackground(_config.background);
        PrepareAndPushObjects();
        _moneyImage.sprite = _config.gem;
        _moneyImage2.sprite = _config.gem;
        _gameOverUI.SetActive(false);
    }

    private void PrepareAndPushObjects()
    {
        _gem.prefab.GetComponent<SpriteRenderer>().sprite = _config.gem;
        _enemy.prefab.GetComponent<SpriteRenderer>().sprite = _config.ship;
        StartCoroutine(SpawnObjects(_gem.prefab, _gem.spawnTime));
        StartCoroutine(SpawnObjects(_enemy.prefab, _enemy.spawnTime));
    }

    private void CreateBackground(Sprite sprite)
    {
        var background = new GameObject();
        var spriteRenderer = background.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite;
        spriteRenderer.sortingLayerName = "Background";
        background.transform.parent = _camera;
    }

    private IEnumerator SpawnObjects(GameObject prefab, float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            var x = DisplayManager.RightX + 2;
            var y = (int) Math.Round(Random.Range(DisplayManager.BottomY, DisplayManager.TopY) / 2) * 2;
            var objPos = new Vector2(x,y);
            var obj = Instantiate(prefab, objPos, Quaternion.identity);
        }
    }

    public void AddMoney(int value)
    {
        _money += value;
        _moneyText.text = _money.ToString();
        _moneyText2.text = _money.ToString();
    }
    
    public void GameOver()
    {
        _gameOverUI.SetActive(true);
        AudioManager.getInstance().PlayAudio(_gameOverClip);
        SaveRecord();
    }

    private void SaveRecord()
    {
        var record = PlayerPrefs.GetInt($"R{_config.id}");
        if(record < _money) PlayerPrefs.SetInt($"R{_config.id}", _money);
    }

    private void Pause(bool pause)
    {
        Time.timeScale = pause ? 0 : 1;
    }

}
