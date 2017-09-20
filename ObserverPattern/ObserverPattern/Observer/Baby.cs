using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern.Observer
{
    public class Baby : IObserver
    {
        public void Action()
        {
            this.Cry(5);
        }

        public void Cry(int second)
        {
            Console.WriteLine("{0} Cry", this.GetType().Name);
        }
    }
}
