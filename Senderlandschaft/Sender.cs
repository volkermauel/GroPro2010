using System;
using System.Collections.Generic;
using System.Linq;

namespace Senderlandschaft
{
    class Sender : IComparable<Sender>
    {
        private readonly double _x;
        private readonly double _y;
        private readonly double _radius;
        private static int _senderCounter = 1;
        public int InstanceId ;
        public List<int> GesperrteFrequenzen = new List<int>();
        public List<Sender> Ueberschneidungen = new List<Sender>();
        public int Frequenz;



        public Sender(float x,float y,float r)
        {
            InstanceId = _senderCounter++;
            _x = x;
            _y = y;
            _radius = r;
        }

        public bool InRange(Sender other)
        {
            var xq = Math.Pow(_x - other._x, 2);
            var yq = Math.Pow(_y - other._y, 2);
            return Math.Sqrt(xq + yq) < (_radius + other._radius);
        }

        public int NextFreeFreq
        {
            get
            {
                return Enumerable.Range(1, 30).Where(x => !GesperrteFrequenzen.Contains(x)).Min();
            }
        }

        public int CompareTo(Sender obj)
        {
            if (GesperrteFrequenzen.Count != obj.GesperrteFrequenzen.Count)
            {
                return obj.GesperrteFrequenzen.Count - GesperrteFrequenzen.Count;
            }
            if (Ueberschneidungen.Count != obj.Ueberschneidungen.Count)
            {
                return obj.Ueberschneidungen.Count - Ueberschneidungen.Count;
            }
            if (Math.Abs(_x - obj._x) > 0.15)
                return (int)(_x - obj._x);
            
            return (int)(_y - obj._y);

        }

        public override string ToString()
        {
            return InstanceId.ToString("00") + "->" + Frequenz;
        }
    }
}