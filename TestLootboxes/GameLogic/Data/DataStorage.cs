using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using TestLootboxes.GameLogic.Chest;

namespace TestLootboxes.GameLogic.Data
{
	public class DataStorage
	{
		private static readonly string cAbsolutePath = "";
		private static readonly string cPlayerDataFilename = "PlayerData.json";
		private static readonly string cItemsFile = "ItemsCollection.json";
		private static readonly string cChestRawContentFile = "ChestContentCollection.json";

		private JsonSerializer serializer;
		private PlayerData playerData;
		private List<Item> itemsCollection;
		private List<ChestRawContent> chestRawContentCollection;

		public PlayerData PlayerData => playerData;
		public List<Item> ItemsCollection => itemsCollection;
		public List<ChestRawContent> ChestRawContentCollection => chestRawContentCollection;

		public DataStorage()
		{
			this.serializer = new JsonSerializer();
			this.playerData = LoadPlayerData();
			this.itemsCollection = LoadAllItems();
			this.chestRawContentCollection = LoadAllChestRawContent();
			if (playerData.IsFirstLaunch)
			{
				SavePlayerData();
			}
		}

		private PlayerData LoadPlayerData()
		{
			PlayerData retVal;
			string filename = GetPath(cPlayerDataFilename);
			if (File.Exists(filename))
			{
				using (StreamReader file = File.OpenText(filename))
				{
					retVal = (PlayerData)serializer.Deserialize(file, typeof(PlayerData));
				}
				retVal.AnotherLaunch();
			}
			else
			{
				retVal = new PlayerData();
			}
			return retVal;
		}

		public void SavePlayerData()
		{
			string filename = GetPath(cPlayerDataFilename);
			if (File.Exists(filename))
			{
				File.Delete(filename);
			}
			using (StreamWriter file = File.CreateText(filename))
			{
				serializer.Serialize(file, playerData);
			}
		}

		private List<Item> LoadAllItems()
		{
			List<Item> retVal = null;
			string filename = GetPath(cItemsFile);
			if (File.Exists(filename))
			{
				using (StreamReader file = File.OpenText(filename))
				{
					retVal = (List<Item>)serializer.Deserialize(file, typeof(List<Item>));
				}
			}
			return retVal;
		}

		private List<ChestRawContent> LoadAllChestRawContent()
		{
			List<ChestRawContent> retVal = null;
			string filename = GetPath(cChestRawContentFile);
			if (File.Exists(filename))
			{
				using (StreamReader file = File.OpenText(filename))
				{
					retVal = (List<ChestRawContent>)serializer.Deserialize(file, typeof(List<ChestRawContent>));
				}
			}
			return retVal;
		}

		private string GetPath(String filename)
		{
			return cAbsolutePath + filename;
		}

		public Item GetItemById(int id)
		{
			return itemsCollection.Find(i => i.id == id);
		}
	}
}
