using FirstYearExamination.GUI;
using FirstYearExamination.SQLiteFrameWork;
using FirstYearExamination.SQLiteFrameWork.Factories;
using FirstYearExamination.SQLiteFrameWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstYearExamination.SQLite
{
	public class GoldUpdater
	{
		GUIText guiText;

		Gold gold;

		Gold_Factory gold_Factory = new Gold_Factory();

		public GoldUpdater(GUIText _guiText)
		{
			this.guiText = _guiText;
		}

		public void MakeTable()
		{
			AutoTable<Gold> autoTable = new AutoTable<Gold>();

			autoTable.MakeTable();

			if(gold_Factory.Get(1) == null)
			{
				gold = new Gold();

				gold_Factory.Insert(gold);
			}
		}

		public void UpdateGold(int amount)
		{
			gold = gold_Factory.Get(1);

			gold.Amount += amount;

			gold_Factory.Update(gold);

			guiText.Text = $"Gold: {gold.Amount}";
		}

		public void ResetGold()
		{
			gold = gold_Factory.Get(1);

			gold.Amount = 0;

			gold_Factory.Update(gold);

			guiText.Text = $"Gold: {gold.Amount}";
		}
	}
}
