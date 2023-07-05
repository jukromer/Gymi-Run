using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    [SerializeField] GameObject [] tables;
    [SerializeField] int bookAmount;
    [SerializeField] GameObject coin;
    [SerializeField] Transform Coins;
    [SerializeField] GameObject [] CoinList;
    void Start()
    {
        tables = GameObject.FindGameObjectsWithTag("Ground");
        spawnCoins();
    }

    void Update()
    {
        
    }

    private int getRandomValue()
    {
        return (int) Random.Range(0f, tables.Length);
    }

    public void spawnCoins()
    {
        for(int i = 0; i < bookAmount; i++)
        {
            int value = getRandomValue();
            Transform tableTransform = tables[value].GetComponent<Transform>();
            GameObject Coin = Instantiate(coin, new Vector2(tableTransform.position.x, tableTransform.position.y + 1.5f), Quaternion.identity);
            Transform CoinTransform = Coin.GetComponent<Transform>();
            CoinTransform.SetParent(Coins);
        }
        CoinList = GameObject.FindGameObjectsWithTag("Coin");
    }

    public void deleteCoins()
    {
        for(int i = 0; i< CoinList.Length; i++)
        {
            Destroy(CoinList[i]);
        }
    }
}
