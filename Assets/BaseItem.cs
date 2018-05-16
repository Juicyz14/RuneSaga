//Item Database
using UnityEngine;
using System.Collections;

[System.Serializable]
//Base Item class.
public class BaseItem {
	//Item Paremeters
	private string itemName;
	private string itemDescription;
	private string itemID;

	private int health;
	private int mana;
	private int strength;
	private int intelligence;
	private int dexterity;
	private int defense;
	private int spirit;
	private int proficiency;
	//Item Types
	public enum ItemTypes{
		WEAPON,
		EQUIPMENT,
		RUNE,
		POTION,
		QUEST
	}
	
	private ItemTypes itemType;
	
	public string ItemName
    {
		get{return itemName;}
		set{itemName = value;}
	}
	public string ItemDescription
    {
		get{return itemDescription;}
		set{itemDescription = value;}
	}

	public string ItemID
    {
		get{return itemID;}
		set{itemID = value;}
	}
	public ItemTypes ItemType
    {
		get{return itemType;}
		set{itemType = value;}
	}
	public int Health
    {
		get{return health;}
		set{health = value;}
	}
	public int Mana
    {
		get{return mana;}
		set{mana = value;}
	}
	public int Strength
    {
		get{return strength;}
		set{strength = value;}
	}
	public int Intelligence
    {
		get{return intelligence;}
		set{intelligence = value;}
	}
	public int Dexterity
    {
		get{return dexterity;}
		set{dexterity = value;}
	}
	public int Defense
    {
		get{return defense;}
		set{defense = value;}
	}
	public int Spirit
    {
		get{return spirit;}
		set{spirit = value;}
	}
	public int Proficiency
    {
		get{return proficiency;}
		set{proficiency = value;}
	}
}