using FirstYearExamination.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstYearExamination.ObjectPool
{
	public class UnitPool : ObjectPool
	{
		#region INSTANCE
		private static UnitPool instance;

		public static UnitPool Instance
		{
			get
			{
				if(instance == null)
				{
					instance = new UnitPool();
				}
				return instance;
			}
		}
		#endregion

		protected override void Cleanup(GameObject gameObject)
		{

		}

		protected override GameObject Create()
		{
			return UnitFactory.Instance.Create("Unit");
		}
	}
}
