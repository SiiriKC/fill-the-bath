using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FillTheBath : MonoBehaviour
{
    #region Variables
    public GameObject raindropTemplate;//Prefab
    public TMP_Text costText; //UI text to display the cost of upgrades.
    public TMP_Text costSizeText;ß
    public int clickMultiplier = 1; //Click multipliers for drops and size increases.
    public TMP_Text clickCountText; // UI text to keep count of clicks.
    public int clickCount = 0;
    public int priceIncreaseDrops = 20; //Price for drop increase.
    public int priceIncreaseSize = 40; //Price for size increase.
    #endregion

    #region Unity Event Functions
     public void Start(){
        costText.text = "Cost:$" + (priceIncreaseDrops * clickMultiplier); //Shows 20 as a cost on start screen.
        costSizeText.text = "Cost:$" + (priceIncreaseSize * clickMultiplier); //Shows 40 as a cost on start screen.
    }
    #endregion

    #region Functions
 public void ClickRainDrop()
    {

        for(int loop = 0; loop < clickMultiplier; loop++){ //Loops from 0 to the value of click multiplier.
        clickCount = clickCount + 1;
        clickCountText.text = "$:" + clickCount.ToString();
        Instantiate(raindropTemplate, new Vector2(0,4), Quaternion.identity); //Creates a drop from a correct spot.
        }
        
        }
        public void UpgradeDrops(){ //Method to increase the number of drops created.

        if(clickCount >= priceIncreaseDrops * clickMultiplier){ 
            clickCount -= priceIncreaseDrops * clickMultiplier; //Deduct clicks.
            clickMultiplier = clickMultiplier + 1; //Increase multiplier.
            clickCountText.text = "$:" + clickCount.ToString(); //Update UI text.
            costText.text = "Cost:$" + (priceIncreaseDrops * clickMultiplier); //Update upgrade cost.
            costSizeText.text = "Cost:$" + (priceIncreaseSize * clickMultiplier); //Update size upgrade cost.
        }
    }
   
    public void UpgradeSize(){ //Method to increase the raindrop size.
        if(clickCount >= priceIncreaseSize * clickMultiplier){
            clickCount -= priceIncreaseSize * clickMultiplier;
            clickCountText.text = "$:" + clickCount.ToString();  
            clickMultiplier = clickMultiplier + 1;
            costSizeText.text = "Cost:$" + (priceIncreaseSize * clickMultiplier);
            costText.text = "Cost:$" + (priceIncreaseDrops * clickMultiplier);
            raindropTemplate.transform.localScale *= 2; //Increases the size of a drop by 2.
        }
    }
    #endregion
    
}
    