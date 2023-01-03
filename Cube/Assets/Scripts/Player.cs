using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Rigidbody),typeof(BoxCollider))]
public class Player : MonoBehaviour
{
    [SerializeReference] private FixedJoystick _joyStick;
    public MovementConfig movementConfig;
    public  inforPlayerConfig inforPlayerConfig;
    /*bool check = true;*/
    internal bool isMoveleft = false;
    internal bool isMoveright = false;
    internal bool isMoveup = false;
    internal bool isMovedown = false;
    float checkForce=0;
    Vector3 movePosNext;
    internal int poinPlayer;
    public Text Pointxt;
    Animator an;
    bool gameOver;
    public Material boxM;
    bool Ismove = true;
    float timeMove = 1f;
    public static Player instance { get;private set; }

    private void Awake()
    {
        an = GetComponent<Animator>();
        /*Pointxt.text = " " + inforPlayerConfig.poins;*/
    }
    void Start()
    {
        gameOver = false;
        poinPlayer = inforPlayerConfig.poins;
        Pointxt.text = " " + poinPlayer;
        if (instance != this && instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        
        Debug.Log(inforPlayerConfig.poins);
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameOver)
        {
            move();

        }
        if (!Ismove)
        {
            timeMove -= Time.deltaTime;
            if (timeMove < 0)
            {
                setMove(true);
                timeMove = 1f;
            }
        }
    }
    void move()
    {
        

       if(!isMoveright&& !isMoveleft && !isMovedown && !isMoveup && !an.GetBool("attack"))
        {
            checkForce = 0;
            if(Ismove)
            {
                checkMove();

            }

            an.SetInteger("status", 0);
        }
       //các hàm di chuyển
        moveUp();
        moveLeft();
        moveRight();
        moveDown();

        if (isMoveright || isMoveleft || isMovedown || isMoveup)
        {
            an.SetInteger("status", 1);
            /*raycast(setMovePosnext());*/
            movePosNext = setMovePosnext();
        }
        
    }
    void moveUp()
    {
        if (transform.position.z >= 4.00f)
        {
            isMoveup = false;
        }
        if (isMoveup)
        {
            if (checkForce >= 2.449f)
            {
                Ismove = false;
                isMoveup = false;
                checkForce = 0;
            }
            transform.rotation = Quaternion.Euler(0, -90, 0);

            transform.position = transform.position + new Vector3(0, 0, movementConfig.speedMove * 0.01f);
                checkForce += movementConfig.speedMove * 0.01f;
                Debug.Log(checkForce);
        }
        
    }
    void moveDown()
    {
        if (transform.position.z <= -3.5f )
        {
            isMovedown = false;
        }
        if (isMovedown)
        {
            /*if (checkForce >= 2.449f)
            {
                isMovedown = false;
                checkForce = 0;
            }*/
            checkForce += movementConfig.speedMove * 0.01f;
            if (checkForce < 2.5f)
            {
                transform.rotation = Quaternion.Euler(0, 90, 0);

                transform.position = transform.position + new Vector3(0, 0, -movementConfig.speedMove * 0.01f);
            }
            else
            {
                isMovedown = false;
                checkForce = 0;
            }
            
            Debug.Log(checkForce);
            

        }
        
    }

    void moveLeft()
    {
        if (transform.position.x <= -3.4f || transform.position.z < -4.52f)
        {
            isMoveleft = false;
        }
        if (isMoveleft)
        {
            if (checkForce >= 2.349f)
            {
                isMoveleft = false;
                checkForce = 0;
            }
            transform.rotation = Quaternion.Euler(0, -180, 0);
            transform.position = transform.position + new Vector3(-movementConfig.speedMove * 0.01f, 0, 0);
            checkForce += movementConfig.speedMove * 0.01f;
            


        }
        
    }

    void moveRight()
    {
        if (transform.position.x >= 3.8f || transform.position.z < -4.52f)
        {
            isMoveright = false;
        }
        if (isMoveright)
        {
            if (checkForce >= 2.349f)
            {
                isMoveright = false;
                checkForce = 0;
            }
            transform.rotation = Quaternion.Euler(0, 0, 0);
            {
                transform.position = transform.position + new Vector3(movementConfig.speedMove * 0.01f, 0, 0);
                checkForce += movementConfig.speedMove * 0.01f;
            }
            
            

        }
       
    }
    //kiểm tra hướng di chuyển
    void checkMove()
    {
        float ver = _joyStick.Vertical;
        float hor = _joyStick.Horizontal;

        if ((ver>-0.5f || ver<0.5f)&& hor<=-0.8f)
        {
            isMoveleft = true;
        }
        if ((ver > -0.5f || ver < 0.5f) && hor >= 0.8f)
        {
            isMoveright = true;


        }
        if ((hor > -0.5f || hor < 0.5f) && ver >= 0.8f)
        {
            isMoveup = true;

        }
        if ((hor > -0.5f || hor < 0.5f) && ver <= -0.8f)
        {
            isMovedown = true;


        }
    }
    //set tọa độ di chuyển tiếp theo của player
    Vector3 setMovePosnext()
    {

        if (isMoveup )
        {
            return new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
        }
        if (isMovedown)
        {
            return new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
        }
        if(isMoveright) {
            return new Vector3(transform.position.x+1, transform.position.y, transform.position.z);
        }
        if (isMoveleft)
        {
            return new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
        }
        else
        {
            return new Vector3(transform.position.x, transform.position.y+1, transform.position.z);
        }    
    }

    void raycast(Vector3 movePostNext)
    {
        Vector3 disMove =  movePostNext - transform.position;   //tìm hướng vector di chuyển
        RaycastHit[] hits = Physics.RaycastAll(movePostNext, disMove);  //trả về mảng các vector nằm trên hướng di chuyển
        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            Debug.Log(hit.collider.name);
            if (hit.collider && Vector3.Distance(hit.collider.transform.position, transform.position) < transform.localScale.x + 1f)
            {
                Debug.Log("Enemy va chạm :" + hit.collider.name);
                Enemy enemy = hit.collider.GetComponent<Enemy>();   //Lấy gameObject
                Debug.Log("Poin Enemy: " + enemy.poin);
                if (inforPlayerConfig.poins >= enemy.poin)
                {
                    setPoinPlayer(enemy.poin);  //tăng điểm player
                    scalePlayer();              //tăng chiều cao
                    /*enemy.destroyEnemy(); */      //xóa enemy
                }
            }
        }
    }

    internal void setPoinPlayer(int poinEnemy)
    {
        inforPlayerConfig.poins += poinEnemy;
        poinPlayer = inforPlayerConfig.poins;
        Debug.Log(poinPlayer);
        if (poinPlayer >= 1000 && poinPlayer < 1000000)
        {
            Pointxt.text = poinPlayer / 1000 + "K";
        }
        else if (poinPlayer < 1000)
        {
            Pointxt.text = " " + poinPlayer;

        }
        else if (poinPlayer >= 1000000 && poinPlayer < 1000000000)
        {
            Pointxt.text = poinPlayer / 1000000 + "M";

        }
        /*Pointxt.text = " " + inforPlayerConfig.poins;*/
    }

    internal void scalePlayer()
    {
        inforPlayerConfig.scale += 0.05f;
        transform.localScale = new Vector3(inforPlayerConfig.scale, inforPlayerConfig.scale, inforPlayerConfig.scale);
    }
   
    public void setInf(int poins,float scale)
    {
        inforPlayerConfig.poins = poins;
        inforPlayerConfig.scale = scale;
        transform.localScale = new Vector3(scale, scale, scale);
    }
    
    public void setMove()
    {
        Ismove = false;
        isMovedown = false;
        isMoveleft = false;
        isMoveup = false;
        isMoveright = false;/*
        an.SetBool("attack", false);*/
    }
    public void setMove(bool status)
    {
        Ismove = status;
    }
    public void setAnimator(string nameAni,bool bo)
    {
            an.SetBool(nameAni, bo);
        
    }
    public void setAnimator(string nameAni, int index)
    {
        an.SetInteger(nameAni, index);
    }
    public void setPosition(float x, float z)
    {
        transform.position = new Vector3(x, transform.position.y, z);
    }

    public void setOver()
    {
        gameOver = true;
    }
    private void OnTriggerEnter(Collider other)
    {

        Color[] color = { Color.blue, Color.green };
        if (other.CompareTag("box"))
        {
            boxM.color = color[0];
        }
    }
}
