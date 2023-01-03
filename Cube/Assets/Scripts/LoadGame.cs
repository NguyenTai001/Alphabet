using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LoadGame : MonoBehaviour
{
    public Image loadGameimg;
    float x = 0f;
    float y = 100f;
    int coin;
    public bool resetLv = false;
    public bool resetCoin = false;
    public Text LoadMap;
    // Start is called before the first frame update
    void Start()
    {
        
        if (resetLv)
        {
            PlayerPrefs.SetInt(pref.SceneNow, 1);
        }
        if (resetCoin)
        {
            PlayerPrefs.SetInt(pref.coin, 0);
        }
        Debug.Log(PlayerPrefs.GetInt(pref.SceneNow));
    }

    // Update is called once per frame
    void Update()
    {
        if (x < y)
        {
            x = x+20*Time.deltaTime;
            loadGameimg.fillAmount = (float)(x / y);
            LoadMap.text =  (int)x/1+"%";
        }
        else {
            
            SceneManager.LoadScene(PlayerPrefs.GetInt(pref.SceneNow));
        }
    }
    
    
}
