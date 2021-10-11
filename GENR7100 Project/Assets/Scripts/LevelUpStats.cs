using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpStats : MonoBehaviour
{
    public int level = 1;
    public float experience { get; private set; }
    public Text lvlText;
    public Image xpBarImage;

    public static int XPNeedToLvlUp(int currentLevel)
    {
        if(currentLevel == 0)
        {
            return 0;
        }

        return (currentLevel * currentLevel + currentLevel) * 5;
    }

    public void SetExperience(float xp)
    {
        experience += xp;

        float xpNeeded = XPNeedToLvlUp(level);
        float previousExperience = XPNeedToLvlUp(level - 1);

        //level up with XP
        if(experience >= xpNeeded)
        {
            LevelUp();
            xpNeeded = XPNeedToLvlUp(level);
            previousExperience = XPNeedToLvlUp(level - 1);
        }

        //Fill XP Bar
        xpBarImage.fillAmount = (experience - previousExperience) / (xpNeeded - previousExperience);

        //Reset the Fillbar
        if(xpBarImage.fillAmount == 1)
        {
            xpBarImage.fillAmount = 0;
        }
    }

    public void LevelUp()
    {
        level++;
        lvlText.text = level.ToString("");

        //Stat Increase Per Level would go here
    }

}
