using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    public Transform [] trees;
    public Vector3 [] treePositions;
    public Transform [] skys;
    public Vector3 [] skyPositions;

    [SerializeField] float qZtrees;
    [SerializeField] float qZskys;
    bool IsParallax = false;

    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] Transform player;
    private Transform cameraTransform;
    

    private void Start() 
    {
        setSkyPositions();
        setTreePositions();
        cameraTransform = Camera.main.transform;
        qZtrees = 1 - Mathf.Abs(cameraTransform.position.z/trees[0].position.z);
        qZskys = 1 - Mathf.Abs(cameraTransform.position.z/skys[0].position.z);    
    }

    private void Update() 
    {
        if(IsParallax)
        {
            parallaxTrees();
            parallaxSky();
        }
    }

    private void parallaxTrees()
    {
        for(int i = 0; i < trees.Length; i++)
        {
            trees[i].position = new Vector3(treePositions[i].x + player.position.x *  qZtrees, trees[i].position.y, trees[i].position.z);
        }
    }

    private void parallaxSky()
    {
        for(int i = 0; i < skys.Length; i++)
        {
            skys[i].position = new Vector3(skyPositions[i].x + player.position.x *  qZskys, skys[i].position.y, skys[i].position.z);
        }
    }

    private void setTreePositions()
    {
        IsParallax = true;
        treePositions = new Vector3[trees.Length];
        for(int i = 0; i < trees.Length; i++)
        {
            treePositions[i] = new Vector3(trees[i].position.x, 4.3f, 12f);
        }
    }

    private void setSkyPositions()
    {
        skyPositions = new Vector3[skys.Length];
        for(int i = 0; i < skys.Length; i++)
        {
            skyPositions[i] = new Vector3(skys[i].position.x, 5.01f, 100f);
        }
    }

    private void Test()
    {
        print(player.position.x);
        print(trees[0].position.x);
    }
    
}



