using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFactory : Singleton<CardFactory>
{
    public GameObject CardPrefab;
    private const string URL = "Cards/";

    public  Card CreateCard(string cardName) {
        Card card = Resources.Load<Card>(URL + cardName + "/" + cardName);

        return card;
    }

    public GameObject WrapCard(Card card) {



        GameObject go = Instantiate(CardPrefab);
        go.GetComponent<CardDisplay>().cardObj = card;
        go.GetComponent<CardDisplay>().Init();

        return go;
    }
}
