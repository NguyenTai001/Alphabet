using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArrays : MonoBehaviour
{
    public EnemyCharactor j;
    public Arrayenemy[] myArray2;
    [System.Serializable]
    public class Arrayenemy
    {
        public EnemyCharactor enemy;
    }
    public Arrayenemy[] myArray;

    private void Awake()
    {
        myArray2 = (Arrayenemy[])myArray.Clone();
        PlayerPrefs.SetInt("countArr", myArray2.Length);
       
    }
    private void Start()
    {
        Debug.Log("length arr2: "+PlayerPrefs.GetInt("countArr"));
    }
        //cập nhật lại mảng sau khi lấy 1 phần tử
    public void updateArr(int i,int cout)
    {
        if (i < cout - 1)
        {
            for (int j = i; j < cout-1; j++)
            {
                myArray2[j].enemy = myArray2[j+1].enemy;
            }
        }
        int count = PlayerPrefs.GetInt("countArr") - 1;
        PlayerPrefs.SetInt("countArr", count);
    }
}
