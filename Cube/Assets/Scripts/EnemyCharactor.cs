using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class EnemyCharactor : MonoBehaviour
{
    int sceneIndex ;
    public Text pointxt;
    public int poin;
    public float scale;
    GameController gc;
    bool isCollider = false;
    bool isDefeate = false;
     bool Boss ;
    float radi;
    float timeUp = 0.3f;
    float timeDefeate = 1.37f;
    float timeMove = 1f;
    JSONReader js;
    Vector3 dir;
    private void Awake()
    {
        Debug.Log(sceneIndex);
        gc = FindObjectOfType<GameController>();
        js = FindObjectOfType<JSONReader>();
    }
    // Start is called before the first frame update
    void Start()
    {
        sceneIndex = PlayerPrefs.GetInt(pref.SceneNow);
        Boss = false;
        poin = PlayerPrefs.GetInt(gameObject.name);
        scale = PlayerPrefs.GetFloat(gameObject.name + "_scale");
        /*pointxt.text = poin +"";*/
        if (poin >= 1000 && poin < 1000000)
        {
            pointxt.text = poin / 1000 + "K";
        }
        else if (poin < 1000)
        {
            pointxt.text = " " + poin;

        }
        else if (poin >= 1000000 && poin < 1000000000)
        {
            pointxt.text = poin / 1000000 + "M";

        }
        /*Debug.Log(gameObject.name + "_scale");*/
        transform.localScale = new Vector3(scale, scale, scale);
    }

    // Update is called once per frame
     void Update()
    {
        rotationEnemy();
        processColli();
        if (poin == js.getPoinMax())
        {
            /*Debug.Log("Boss is " + gameObject.name);*/
            Boss = true;
            
        }

    }

    void collierPlayer()
    {
        if (Vector3.Distance(Player.instance.transform.position, transform.position) <= Player.instance.transform.localScale.x - 0.2f)
        {
            Debug.Log("Enemy va chạm :" + gameObject.name);
            //Lấy gameObject
            Debug.Log("Poin Enemy: " + poin);
            if (Player.instance.poinPlayer >= poin)
            {
                Player.instance.setAnimator("attack",true );
                Player.instance.setAnimator("status",2);
                Player.instance.setMove();
                isCollider = true;
                
                
            }
            else
            {
                /*Player.instance.setAnimator("attack", false);*/
                Player.instance.setAnimator("status", 3);
                gc = FindObjectOfType<GameController>();
                
                gc.setGameOver();
                
                isDefeate = true;
                /*SceneManager.LoadScene("level1");*/
            }
        }

    }
    //Xoay Enemy
    void rotationEnemy()
    {
        dir = (Vector3)transform.position - (Vector3)Player.instance.transform.position;
        radi = Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 90 - radi + 90, 0);
    }

    //Xử lý hành động player khi va chạm với Enemy
    void processColli()
    {
        if (!isCollider && !isDefeate)
        {
            collierPlayer();
        }

        if (isCollider && timeUp > 0)
        {

            timeUp -= Time.deltaTime;
            if (timeUp < 0)
            {
                
                Player.instance.setPoinPlayer(poin);        //tăng điểm player
                Player.instance.scalePlayer();
                Player.instance.setAnimator("attack", false);
                Player.instance.setPosition(transform.position.x, transform.position.z);
                if (Boss)
                {
                    gc.WinUi();
                    /*PlayerPrefs.SetInt(pref.SceneNow, sceneIndex + 1);*/

                }    
                Destroy(gameObject);
                /*timeUp = 0.2f;
                isCollider = false;*/
            }

        }
       
        if (isDefeate && timeDefeate > 0)
        {
            timeDefeate -= Time.deltaTime;
            if (timeDefeate < 0)
            {
                /*Player.instance.setPoinPlayer(poin);        //tăng điểm player
                Player.instance.scalePlayer();*/
                Player.instance.setAnimator("status", 0);
                /*Player.instance.setPosition(transform.position.x, transform.position.z);*/
                /*Destroy(gameObject);*/
                timeDefeate = 1.37f;
            }

        }
    }
    public void setBoss()
    {
        Boss = true;
        Debug.Log("BOss"+Boss);

    }
}
