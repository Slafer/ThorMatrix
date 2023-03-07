using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ThorMatrix
{
    class ThorMatrix : IEnumerable {
        private Dictionary<(int, int), String> Elems = new Dictionary<(int, int), String>();
        private (int, int) Size;
        private readonly String std = new string("0 ");

        public ThorMatrix((int, int) nsize)
        {
            Size = nsize;
        }

        public String this[int i, int j]
        {
            get
            {
                (i, j) = GetCorrectPos((i, j));
                if (IsNotEmpty((i, j))) return Elems[(i, j)];
                else return std;
            }
            set
            {
                (i, j) = GetCorrectPos((i, j));
                Elems.Add((i, j), value);
            }
        }
        private bool IsNotEmpty((int, int) pos)
        {
            foreach (var Elem in Elems)
            {
                if (Elem.Key == pos) return true;
            }
            return false;
        }
        private (int, int) GetCorrectPos((int, int) pos)
        {
            int x = Size.Item1;
            int y = Size.Item2;
            while (pos.Item1 < 0)
            {
                pos.Item1 += x;
            }
            while (pos.Item2 < 0)
            {
                pos.Item2 += y;
            }
            pos.Item2 %= y;
            pos.Item1 %= x;
            return pos;
        }
        public ThorMatrix Neighbours((int, int) pos)
        {
            pos = GetCorrectPos(pos);
            var x = pos.Item1;
            var y = pos.Item2;
            var ans = new ThorMatrix((3,3));
            ans[1, 1] = this[x, y];
            ans[0, 0] = this[x-1, y-1];
            ans[2, 2] = this[x + 1, y + 1];
            ans[1, 2] = this[x , y + 1];
            ans[2, 1] = this[x + 1, y];
            ans[0, 1] = this[x - 1, y];
            ans[1, 0] = this[x, y - 1];
            ans[0, 2] = this[x - 1, y + 1];
            ans[2, 0] = this[x + 1, y - 1];
            return ans;
        }
        public override string ToString()
        {
            StringBuilder ans = new StringBuilder();
            for (int i = 0; i < Size.Item1; i++) 
            {
                for (int j = 0; j < Size.Item2; j++)
                    ans.Append(this[i, j]);
                ans.Append(Environment.NewLine);
            }
            return ans.ToString();
        }
        public IEnumerator<String> GetEnumerator()
        {
            for (int i = 0; i < Size.Item1; ++i)
                for (int j = 0; j < Size.Item2; ++j)
                    yield return Elems.ContainsKey((i, j)) ? Elems[(i, j)] : std;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Elems.GetEnumerator();
        }
    }
}
