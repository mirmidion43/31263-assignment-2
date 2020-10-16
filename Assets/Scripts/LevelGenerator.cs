using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    // a 14x15 2d array
    int[,] levelMap =
    {
        {1,2,2,2,2,2,2,2,2,2,2,2,2,7},
        {2,5,5,5,5,5,5,5,5,5,5,5,5,4},
        {2,5,3,4,4,3,5,3,4,4,4,3,5,4},
        {2,6,4,0,0,4,5,4,0,0,0,4,5,4},
        {2,5,3,4,4,3,5,3,4,4,4,3,5,3},
        {2,5,5,5,5,5,5,5,5,5,5,5,5,5},
        {2,5,3,4,4,3,5,3,3,5,3,4,4,4},
        {2,5,3,4,4,3,5,4,4,5,3,4,4,3},
        {2,5,5,5,5,5,5,4,4,5,5,5,5,4},
        {1,2,2,2,2,1,5,4,3,4,4,3,0,4},
        {0,0,0,0,0,2,5,4,3,4,4,3,0,3},
        {0,0,0,0,0,2,5,4,4,0,0,0,0,0},
        {0,0,0,0,0,2,5,4,4,0,3,4,4,0},
        {2,2,2,2,2,1,5,3,3,0,4,0,0,0},
        {0,0,0,0,0,0,5,0,0,0,4,0,0,0},
    }; 

    
    public GameObject OutCorner;
    public GameObject OutWall;
    public GameObject InCorner;
    public GameObject InWall;
    public GameObject TJunc;
    public GameObject normPellet;
    public GameObject powPellet;
    public GameObject RInCorner;
    public GameObject Parent1;
    public GameObject Parent2;
    public GameObject Parent3;
    public GameObject Parent4;

    Vector3 rotation1 = new Vector3(0,0,0);
    Vector3 rotation2 = new Vector3(0,0,90);
    Vector3 rotation3 = new Vector3(0,0,180);
    Vector3 rotation4 = new Vector3(0,0,270);



    // Called before Start
    private void Awake() 
    {
        GameObject[] remove = GameObject.FindGameObjectsWithTag("1");
        for(int i = 0; i < remove.Length; i++)
        Destroy(remove[i]);

        Parent1 = new GameObject();
        Parent2 = new GameObject();
        Parent3 = new GameObject();
        Parent4 = new GameObject();
        Instantiate(Parent1, new Vector3(-13.5f,14.5f,0.0f), Quaternion.identity);
        Instantiate(Parent2, new Vector3(-13.5f,14.5f,0.0f), Quaternion.identity);
        Instantiate(Parent3, new Vector3(-13.5f,14.5f,0.0f), Quaternion.identity);
        Instantiate(Parent4, new Vector3(-13.5f,14.5f,0.0f), Quaternion.identity);

        for (int i = 0; i < 14; i++)
        {
            for (int j = 0; j < 15; j++)
            {
                makeTile(levelMap[j,i], i, j, Parent1);
                makeTile(levelMap[j,i], i, j, Parent2); 
            }
            for (int j = 0; j < 14; j++)
            {
                makeTile(levelMap[j,i], i, j, Parent3); 
                makeTile(levelMap[j,i], i, j, Parent4); 
            }
        }
        //Parent2.transform.Translate(13.5f,0.0f,0.0f);
        Parent2.transform.Rotate(new Vector3(0f,180f,0f));
        Parent3.transform.Translate(0.0f,1.0f,0.0f);
        Parent3.transform.Rotate(new Vector3(180f,0f,0f));
        Parent4.transform.Translate(0.0f, 1.0f,0.0f);
        Parent4.transform.Rotate(new Vector3(180f,180f,0f));
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //instantiate a tile based on the levelMap array
    private void makeTile(int ID, int x1, int y2, GameObject parent)
    {
        float x = (float)x1;
        float y = (float)y2;

        float a1 = x - 13.5f;
        float a2 = -y + 14.5f;
        
        makeDecider(ID, a1,a2, parent);

    }

    private void makeDecider(int ID, float x, float y, GameObject parent)
    {
        if(ID == 1)
            make1(x,y, parent);

        if(ID == 2)
            make2(x,y, parent);

        if(ID == 3)
            make3(x,y, parent);

        if(ID == 4)
            make4(x,y, parent);

        if(ID == 5)
            make5(x,y, parent);

        if(ID == 6)
            make6(x,y, parent);

        if(ID == 7)
            make7(x,y, parent);
    }

    //make an Outside Corner
    private void make1(float x, float y, GameObject parent)
    {
        if(x==-13.5 && y==5.5)
            Instantiate(OutCorner, new Vector3(x,y,0), Quaternion.Euler(rotation2), parent.transform);
        else if(x==-8.5 && y==5.5)
            Instantiate(OutCorner, new Vector3(x,y,0), Quaternion.Euler(rotation4), parent.transform);
        else if(x==-8.5 && y==1.5)
            Instantiate(OutCorner, new Vector3(x,y,0), Quaternion.Euler(rotation3), parent.transform);
        else
            Instantiate(OutCorner, new Vector3(x,y,0), Quaternion.Euler(rotation1), parent.transform);

            
        
    }
    //make an Outside Wall
    private void make2(float x, float y, GameObject parent)
    {
        if(y==14.5||y==5.5||y==1.5)
            Instantiate(OutWall, new Vector3(x,y,0), Quaternion.Euler(rotation2), parent.transform);
        else
            Instantiate(OutWall, new Vector3(x,y,0), Quaternion.Euler(rotation1), parent.transform);
    }

    //make an Inside Corner
    private void make3(float x, float y, GameObject parent)
    {
        if((x==-5.5 && y ==5.5)||(x==-5.5 && y==4.5)||(x==-0.5 && y ==7.5))
            make3R(x,y, parent);
        else
            make3N(x,y, parent);  
    }

    private void make3R(float x, float y, GameObject parent)
    {
        if(x==-5.5 && y==4.5)
        Instantiate(RInCorner, new Vector3(x,y,0), Quaternion.Euler(rotation4), parent.transform);
        else if (x==-0.5 && y==7.5)
        Instantiate(RInCorner, new Vector3(x,y,0), Quaternion.Euler(rotation3), parent.transform);
        else
        Instantiate(RInCorner, new Vector3(x,y,0), Quaternion.Euler(rotation1), parent.transform);
    }

    private void make3N(float x, float y, GameObject parent)
    {
        if(y==12.5||y==8.5||y==5.5)
        {
            if(x==-8.5||x==-2.5||x==-5.5)
                Instantiate(InCorner, new Vector3(x,y,0), Quaternion.Euler(rotation4), parent.transform);
            else 
            Instantiate(InCorner, new Vector3(x,y,0), Quaternion.Euler(rotation1), parent.transform);
        }

        else if(y==10.5||y==7.5||y==1.5||y==4.5)
        {
            if(x==-11.5||x==-6.5||x==-3.5||x==-0.5)
                Instantiate(InCorner, new Vector3(x,y,0), Quaternion.Euler(rotation2), parent.transform);
            else if(x==-8.5||x==-2.5||x==-5.5)
                Instantiate(InCorner, new Vector3(x,y,0), Quaternion.Euler(rotation3), parent.transform);
        }
                   
        else 
            Instantiate(InCorner, new Vector3(x,y,0), Quaternion.Euler(rotation1), parent.transform);
    }

    //make an Inside Wall
    private void make4(float x, float y, GameObject parent)
    {
        if(-11.0<x && x<-1.0 && x!=-6.5 && y>2)
            if(y==11.5||y==6.5||y==3.5||(y==7.5&&x==-5.5)||(y==2.5&&x==-5.5))
                Instantiate(InWall, new Vector3(x,y,0), Quaternion.Euler(rotation1), parent.transform);
            else if(y==10.5||y==4.5||y==7.5)
                Instantiate(InWall, new Vector3(x,y,0), Quaternion.Euler(rotation4), parent.transform);
            else  
                Instantiate(InWall, new Vector3(x,y,0), Quaternion.Euler(rotation2), parent.transform);
        
        else if(y==8.5 && x==-0.5)
            Instantiate(InWall, new Vector3(x,y,0), Quaternion.Euler(rotation2), parent.transform);
        else    
            Instantiate(InWall, new Vector3(x,y,0), Quaternion.Euler(rotation3), parent.transform);
    }

    //make a Standard Pellet
    private void make5(float x, float y, GameObject parent)
    {
        Instantiate(normPellet, new Vector3(x,y,0), Quaternion.Euler(rotation1), parent.transform);      
    }

    //make a Power Pellet
    private void make6(float x, float y, GameObject parent)
    {
        Instantiate(powPellet, new Vector3(x,y,0), Quaternion.Euler(rotation1), parent.transform);
         
    }

    //make a T-junction
    private void make7(float x, float y, GameObject parent)
    {
        Instantiate(TJunc, new Vector3(x,y,0), Quaternion.Euler(new Vector3(0,180,0)), parent.transform);
    }
}
