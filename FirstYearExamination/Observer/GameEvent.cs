using FirstYearExamination.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstYearExamination.Observer
{
	public class GameEvent
	{
		private List<IGameListener> listeners = new List<IGameListener>();
		public string Title { get; private set; }

		public GameEvent(string title)
		{
			this.Title = title;
		}

		public void Attach(IGameListener listener)
		{
			listeners.Add(listener);
		}

		public void Detach(IGameListener listener)
		{
			listeners.Remove(listener);
		}

		public void Notify(Component other)
		{
			foreach (IGameListener listener in listeners)
			{
				listener.Notify(this, other);
			}
		}
	}
}
