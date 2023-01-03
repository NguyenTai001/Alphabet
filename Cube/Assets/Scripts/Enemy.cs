using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    internal int poin ;
    private float scale = 1f;
    /*public Text poinEnemyTxt;*/
     JSONReader js;
    EnemyArrays EA;
    GameController gc;
    /*test1 t;*/
    private void Awake()
    {
        EA = FindObjectOfType<EnemyArrays>();
        js = FindObjectOfType<JSONReader>();
        gc = FindObjectOfType<GameController>();

        /*t = FindObjectOfType<test1>();*/

    }
    void Start()
    {

        for (int i = 0; i < js.ArrayScene().Length; i++)
        {
            if (js.ArrayScene()[i].name.Equals(gameObject.name))
            {

                poin = js.ArrayScene()[i].poin;
                scale = js.ArrayScene()[i].scale;

            }
        }
        create_Enemy(poin, scale);
        /*poinEnemyTxt.text = "" + poin;*/


    }

    // Update is called once per frame
    void Update()
    {

        
       /* collierPlayer();*/ // Xử lý va chạm player vs Enemy
    }

    /*public void destroyEnemy()
    {
        Destroy(gameObject);
    }*/

    /*void collierPlayer()
    {
        if (Vector3.Distance(Player.instance.transform.position, transform.position) <= Player.instance.transform.localScale.x+ 0.5f)
        {
            Debug.Log("Enemy va chạm :" + gameObject.name);
               //Lấy gameObject
            Debug.Log("Poin Enemy: " + poin);
            if (Player.instance.poinPlayer >= poin)
            {
                Player.instance.setPoinPlayer(poin);        //tăng điểm player
                Player.instance.scalePlayer();              //tăng chiều cao
                *//*destroyEnemy();  *//*     //xóa enemy
            }
            else
            {
                SceneManager.LoadScene("level1");
            }
        }

    }*/
    void create_Enemy(int poin,float scale)
    {
        int coutArray = PlayerPrefs.GetInt("countArr");
        int randomEnemy = Random.Range(0, coutArray);
        if (coutArray > 1)
        {
            EnemyCharactor en = EA.myArray2[randomEnemy].enemy.GetComponent<EnemyCharactor>();
            Instantiate(en, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.Euler(0, 90, 0));
            PlayerPrefs.SetInt(EA.myArray2[randomEnemy].enemy.name+"(Clone)", poin);
            PlayerPrefs.SetFloat(EA.myArray2[randomEnemy].enemy.name + "(Clone)_scale", scale);
            UpdateArray(randomEnemy, coutArray);
           
        }
        else if (coutArray == 1)
        {
            EnemyCharactor en = EA.myArray2[0].enemy;
            Instantiate(EA.myArray2[0].enemy, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.Euler(0, 90, 0));
            PlayerPrefs.SetInt(EA.myArray2[0].enemy.name + "(Clone)", poin);
            PlayerPrefs.SetFloat(EA.myArray2[0].enemy.name + "(Clone)_scale", scale);
           /* Debug.Log(PlayerPrefs.GetFloat(EA.myArray2[0].enemy.name + "(Clone)_scale", scale););*/
            EA.updateArr(0,0);
            
        }
    }
    void UpdateArray(int i, int cout)
    {
        
        EA.updateArr(i,cout);
    }
    void runArr(int count)
    {
        for (int n = 0; n < count; n++)
        {
            Debug.Log("length :" + PlayerPrefs.GetInt("countArr") + " " + EA.myArray2[n].enemy.name);
        }
    }
    
}
