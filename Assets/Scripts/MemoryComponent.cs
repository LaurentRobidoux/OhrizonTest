using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MemoryComponent : MonoBehaviour {

    public List<Material> CardColors;
	// Use this for initialization
	void Start () {
     
	}

    public void BeginGame()
    {
        firstCard = null;
        var CardComponents = transform.GetComponentsInChildren<CardComponent>();

        System.Random rng = new System.Random();
        CardComponents = CardComponents.OrderBy(x => rng.Next()).ToArray();
        int CardColorIndex = 0;
        Material currentMat = CardColors[CardColorIndex];
        for (int index = 0; index < CardComponents.Length; index++)
        {
            if (index % 2 == 0 && index != 0)
            {
                CardColorIndex++;
                currentMat = CardColors[CardColorIndex];
            }
            CardComponents[index].ResetRotation();
            CardComponents[index].ChangeMaterial(currentMat);
            print(currentMat.name);
        }

    }

    // Update is called once per frame
    void Update () {
		
	}
    //the card we are trying to find a pair for
    public CardComponent firstCard;
    public void ChildClickedOn(CardComponent card)
    {
        if (firstCard==null)
        {
            firstCard = card;

        }
        else if (firstCard.GetMaterial().name==card.GetMaterial().name)
        {
            firstCard = null;
        }
        else
        {
            firstCard.StartRotation(false);
            card.StartRotation(false);
            firstCard = null;
        }
    }
}
