using FirstYearExamination.ObjectPool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstYearExamination.Components
{
	public class WaveController
	{
		public int waveIndex = 1;
		public List<GameObject> wave_Units = new List<GameObject>();

		public void NextWave()
		{
			for (int i = 0; i < waveIndex * 10; i++)
			{
				GameObject go = UnitPool.Instance.GetObject();
				wave_Units.Add(go);
			}
			waveIndex++;
		}

		public GameObject GetNextGameObject()
		{
			if(wave_Units.Count > 0)
			{
				GameObject result = wave_Units[wave_Units.Count - 1];
				wave_Units.RemoveAt(wave_Units.Count - 1);
				return result;
			}
			else
			{
				return null;
			}
		}
	}
}
