using System;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class ItemStack
{
	public Item itemType
	{
		get => ItemType;
		set
		{
			ItemType = value;
			CallObservers();
		}
	}
	[SerializeField] private Item ItemType;
	public int count
	{
		get => Count;
		set
		{
			Count = value;
			CallObservers();
		}
	}
	[SerializeField] private int Count;

	private void CallObservers()
	{
		foreach (Observer i in observers)
		{
			i();
		}
	}

	[HideInInspector]
	public List<Observer> observers = new List<Observer>();

	public bool containsItem => itemType != null;
	public static ItemStack empty => new ItemStack(null, 0);

	public ItemStack(Item itemType, int count)
	{
		this.itemType = itemType;
		this.count = count;
	}
}