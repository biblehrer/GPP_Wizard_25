using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Class")]
public class WizardClass : ScriptableObject
{
    public float movementSpeedBase = 5;
    public float movementSpeedIncrease = 0.5f;
    public int maxManaBase = 100;
    public int manaIncrease = 10;
    public int maxHealthBase = 100;
    public int healthIncrease = 10;
    public float manaRegenerationBase = 10;
    public float manaRegenerationIncrease = 1f;    
    public float castingTimeBase = 0.5f; 
    public float castingTimeDecrease = 0.1f;
    
    [System.NonSerialized]
    public float mana, health, xp, movementSpeed, manaRegeneration, castingTime;
    [System.NonSerialized]
    public int level, maxMana, maxHealth, skillPoints;
    

    WizardClass()
    {
        Reset();
    }

    public float HealthPercentage()
    {
        return health / maxHealth;
    }

    public float ManaPercentage()
    {
        return mana / maxMana;
    }

    public float XPPercentage()
    {
        return xp / (level*5);
    }

    public void GainXP(float gainedXP)
    {
        xp += gainedXP;
        while (xp >= level*5)
        {            
            xp -= level*5;
            LevelUp();
            skillPoints += 5;
        }        
    }

    public void AssignSkillPoint(int id)
    {
        switch (id)
        {
            case 0:
                health += healthIncrease;
                maxHealth += healthIncrease;
                skillPoints--;
                break;
        }
    }

    public void RemoveSkillPoint(int id)
    {
        switch (id)
        {
            case 0:
                if (maxHealth > maxHealthBase)
                {
                    maxHealth -= healthIncrease;
                    if (health > maxHealth)
                    {
                        health = maxHealth;
                    }
                }
                skillPoints++;
                break;
        }
    }

    public void LevelUp()
    {
        level++;
        movementSpeedBase += movementSpeedIncrease;
        manaRegeneration += manaRegenerationBase;
        maxMana += manaIncrease;
        maxHealth += healthIncrease;
        mana += manaIncrease;
        health += healthIncrease;
        castingTime = Mathf.Max(0.25f, castingTimeBase - castingTimeDecrease * level);
    }


    public void Reset()
    {
        movementSpeed = movementSpeedBase;
        maxMana = maxManaBase;
        maxHealth = maxHealthBase;
        manaRegeneration = manaRegenerationBase;
        castingTime = castingTimeBase;
        mana = maxMana;
        health = maxHealth;
        level = 1;
    }

}
