using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

/// <summary>
/// Manages a list of card names
/// </summary>
public class DeckOfCards:MonoBehaviour
{
    private List<string> _CardList = new List<string>();

    /// <summary>
    /// Loads a list of strings into _CardList
    /// </summary>
    public void LoadCards() {

        TextAsset mytxtData = (TextAsset)Resources.Load("DeckRecipe");
        var deckStrArr = XDocument.Parse(mytxtData.text);

       // Dictionary<string, int> deckComposition = new Dictionary<string, int>();

        foreach (var card in deckStrArr.Element("deck").Elements("card")) {

            int amountOfCopies = Convert.ToInt32(
                    card.Element("amount").Value
                    );

            for (int i=0; i< amountOfCopies;i++) {
                _CardList.Add(card.Element("name").Value.ToString());
            }


        }
      
      
    }

   
    public string DrawCard() {

        if (_CardList.Count > 0) {
            int retIndex = _CardList.Count - 1;
            string retString = _CardList[retIndex];            
           _CardList.RemoveAt(retIndex);
            return retString;
        }
         return "Deck is empty";
    }
    //Add shuffle function

    public void Shuffle()
    {
        int size = _CardList.Count;
        System.Random r = new System.Random();
        for (int i=0; i<size; i++) {
           
            int rInt = r.Next(0, size); //for ints
            string temp = _CardList[i];
            _CardList[i] = _CardList[rInt];
            _CardList[rInt] = temp;
        }
      
    }
    //Add shuffle function





    // Update is called once per frame
    void Update()
    {
        
    }
}
