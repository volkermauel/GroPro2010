using System.Collections.Generic;
using System.Linq;

namespace Senderlandschaft
{
    class Senderlandschaft
    {
        private readonly List<Sender> _senderliste=new List<Sender>();

        public void Add(Sender s)
        {
            _senderliste.Add(s);
        }

        public void Remove(Sender s)
        {
            _senderliste.Remove(s);
        }

        public List<Sender> Result
        {
            get
            {
                var tmpList = new List<Sender>(_senderliste);
                foreach (var sender in tmpList)
                {
                    sender.Ueberschneidungen = tmpList.Where(x => x != sender && x.InRange(sender)).ToList();
                    sender.GesperrteFrequenzen= new List<int>();
                    sender.Frequenz = 0;
                }
                while (tmpList.Count >= 1)
                {
                    tmpList.Sort();
                    var start = tmpList[0];
                    start.Frequenz = start.NextFreeFreq;
                    start.Ueberschneidungen.ForEach(x => x.GesperrteFrequenzen.Add(start.Frequenz));
                    tmpList.Remove(start);
                }


                return _senderliste;
            }
        }
    }
}