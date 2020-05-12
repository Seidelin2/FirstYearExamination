using FirstYearExamination.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstYearExamination.Observer
{
	public interface IGameListener
	{
		void Notify(GameEvent gameEvent, Component component);
	}
}
