using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pigAction : ReplyAction
{
    [SerializeField] Backpack mbackpack;
    public Player_Attributes PA;
    [SerializeField] public itemstat[] itemgiven = new itemstat[100];
    
    public override void nextMove(int optionChose){
         if (optionChose == 0)
        {
            PA.changeFace(1, 5);
        }
        //relic
        if (optionChose == 1)
        {
            mbackpack.addObject(itemgiven[0]);
            PA.changeFace(1, itemgiven[0].emo);
            PA.changeFace(2, itemgiven[0].con);
            PA.changeFace(3, itemgiven[0].ext);
            PA.changeFace(4, itemgiven[0].ope);
            PA.changeFace(5, itemgiven[0].hon);
            PA.changeFace(6, itemgiven[0].agr);
        }
    }
}
