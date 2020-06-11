using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstYearExamination.SQLiteFrameWork.Models
{
	/// <summary>
	/// Lavet af Marius Rysgaard
	/// </summary>
	public class Gold
	{
		public Int32 ID { get; set; }
		public int Amount { get; set; }

		public Gold()
		{

		}

		public Gold(int _amount)
		{
			this.Amount = _amount;
		}
	}
}
