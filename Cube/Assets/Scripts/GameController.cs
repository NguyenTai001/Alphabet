using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using UnityEngine.UI;



public class GameController : MonoBehaviour
{
    int coin;
    public Text coinWinTxt;
    public Text CoinNowtxt;
    int sceneIndex;
    public int poinPlayer;
    public float scalePlayer;
    string nameboss;
    public GameObject UI_Beforestart;
    public GameObject UI_Start;
    public GameObject camera1;
    public GameObject camera2;
    public GameObject GameOverUI;
    public GameObject GameWinUi;
    public Material maLine;
    public Material maGround;
    bool gamePaus = true;
    Player player;
    ArrayMaps am;
    float timeExchange = 2f;
    Color[] color = { new Color(0.03137255f, 0.2196078f, 0.3098039f), new Color(0.8431373f, 0.8392158f, 0.3411765f), new Color(0.4f, 0.7254902f, 0.3647059f), new Color(0.5019608f, 0.7921569f, 0.8352942f), new Color(0.5686274f, 0.4235294f, 0.3490196f, 1) };

    private void Awake()
    {
        UI_Start.SetActive(false);
        UI_Beforestart.SetActive(true);
        GameWinUi.SetActive(false);
        player = FindObjectOfType<Player>();
        player.setInf(poinPlayer, scalePlayer);
    }
    void Start()
    {
        CoinNowtxt.text = "" + PlayerPrefs.GetInt(pref.coin);
        Debug.Log(PlayerPrefs.GetInt(pref.coin));
        coin = 200 + (PlayerPrefs.GetInt(pref.SceneNow) * 10);
        sceneIndex = PlayerPrefs.GetInt(pref.SceneNow);
        setColor();
        GameOverUI.SetActive(false);
        am = FindObjectOfType<ArrayMaps>();
        camera1.SetActive(true);
        camera2.SetActive(false);

        /*if(am.arrmaps[0].name.Equals(SceneManager.GetActiveScene().name))
            {
            Instantiate(am.arrmaps[0], new Vector3(0, 0, -2.0571f), Quaternion.identity);
        }*/
        /*string s = (SceneManager.GetSceneAt(sceneIndex+1).name.Replace("level", ""));*/
        string s = SceneManager.GetActiveScene().name.Replace("level","");
        Debug.Log("Scene"+s);
        if (int.Parse(s) >= 1 && int.Parse(s) <= 10)
        {
            Instantiate(am.arrmaps[0], new Vector3(0.37f, -0.811f, 0.21f), Quaternion.Euler(0, -90, 0));
            am.arrmaps[0].transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);

        }

        /*Instantiate(player, new Vector3(-1, 0, -6), Quaternion.identity);*/
    }

    // Update is called once per frame
    void Update()
    {
        
        if (camera2.active && !gamePaus)
        {
            timeExchange -= Time.deltaTime;
            if(timeExchange<=0)
            {
                UI_Start.SetActive(true);
                gamePaus = true;
                Debug.Log("abc");
            }
        }
    }
    

        /*  if(Input.GetKeyDown(KeyCode.K))
          {
              float rd = Random.Range(0f, 3f);
              Debug.Log(rd);
          }*/
        // Debug.Log(an.GetInteger("status"));
        /* if (an.GetInteger("status") == 1)
         {
             Debug.Log("status = 1");

                 timeExchange -= Time.deltaTime;
                 if (timeExchange <= 0)
                 {
                     an.SetInteger("status", 2);
                      Debug.Log("status = 2");
                 UI_start.SetActive(false);
                 btn_move.SetActive(true);
             }
         }*/

    
    public void btn_Start()
    {
        /*an.SetInteger("status", 1);*/
        camera1.SetActive(false);
        camera2.SetActive(true);
        UI_Beforestart.SetActive(false);
        gamePaus = false;
        Debug.Log("start");
    }

   
    public void btn_replay()
    {
        SceneManager.LoadScene(sceneIndex);
    }
    public void setGameOver()
    {
        gamePaus = true;
        Debug.Log("GameOver11");
        GameOverUI.SetActive(true);
        UI_Start.SetActive(false);
        Player.instance.setOver();
    }
    public void WinUi()
    {
        coinWinTxt.text = "" + coin;

        gamePaus = true;
        GameWinUi.SetActive(true);
        UI_Start.SetActive(false);
    }
    /*public void btn_nextScene()
    {
        
        SceneManager.LoadScene(0);
    }*/
    public void btn_CoinX2()
    {
        UpdateCoin(2*coin);
        PlayerPrefs.SetInt(pref.SceneNow, PlayerPrefs.GetInt(pref.SceneNow) + 1);
        SceneManager.LoadScene(PlayerPrefs.GetInt(pref.SceneNow));
    }
    public void btn_nextLevel()
    {
        
        UpdateCoin(coin);
        PlayerPrefs.SetInt(pref.SceneNow, PlayerPrefs.GetInt(pref.SceneNow) + 1);
        SceneManager.LoadScene(PlayerPrefs.GetInt(pref.SceneNow));
    }
    public void UpdateCoin(int coin)
    {
        PlayerPrefs.SetInt(pref.coin, PlayerPrefs.GetInt(pref.coin) + coin);
        
    }
    public void setColor()
    {
        int rdl = random();
        maLine.color = color[rdl];
        int rdg = random(rdl);
        maGround.color = color[rdg];
        Debug.Log(rdl + "" + rdg);
    }
    public int random()
    {
        return Random.Range(0, color.Length);
    }
    public int random(int x)
    {
        int r = Random.Range(0, color.Length);
        if (x == r)
        {
            
            return random(x);
        }
        else
        {
            return r;
        }
        
    }
}
