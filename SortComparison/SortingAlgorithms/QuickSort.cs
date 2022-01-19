using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SortComparison.SortingAlgorithms
{
    // Lomuto implementation
    class QuickSort : SortAlgorithm
    {
        public override string Name => "Quicksort";
        public override void Sort(IList<int> arrayToSort)
        {
            QuickSort_(arrayToSort, 0, arrayToSort.Count-1);
        }

        private void QuickSort_(IList<int> array, int start, int end)
        {
            if (start < end)
            {
                var pivot = Partition_(array, start, end);

                QuickSort_(array, start, pivot - 1);
                QuickSort_(array, pivot + 1, end);
            }
        }

        private static int Partition_(IList<int> array, int start, int end)
        {
            // Pivotelement setzen
            var pivot = array[end];

            // Index des kleineren Elements setzen
            var i = start;
            
            for (var j = start; j < end; j++)
            {
                // Falls das aktuelle Element kleiner gleich dem Pivotelement ist
                if (array[j] <= pivot)
                {
                    // Elemente tauschen
                    Swap_(array, i, j);

                    // Index des kleineren Elements inkerementieren
                    i++;
                }
            }

            // Elemente tauschen
            Swap_(array, i, end);
            return i;
        }

        private static int Random_(IList<int> array, int start, int end)
        {
            // Zufällige Nummer zwischen Start und Ende generieren
            Random rand = new Random();
            var pivot = rand.Next(start-1, end+1);

            // Elemente tauschen
            Swap_(array, pivot, end);
            return Partition_(array, start, end);
        }

        private static void Swap_(IList<int> array, int a, int b)
        {
            var temp = array[a];
            array[a] = array[b];
            array[b] = temp;
        }
    }
}
