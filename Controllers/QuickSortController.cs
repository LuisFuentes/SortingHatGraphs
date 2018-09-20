using SortingHatGraphs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace SortingHatGraphs.Controllers
{
    public class QuickSortController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Sorting Page";

            return View();
        }

        // POST /quicksort/sort
        [System.Web.Http.HttpPost]
        public JsonResult Sort(IList<IComparable> list)
        {
            // Perform QuickSort on the list and return the list
            QuickSort sort = new QuickSort(list);
            IList<IComparable> sortedList = sort.Sort();

            //return Json(sortedList);
            return Json(sort.GetChart());
        }
    }

    public class QuickSortChart
    {
        public IList<IComparable> List;
        public int IndexOne;
        public int IndexTwo;

        public QuickSortChart(IList<IComparable> list, int indexOne, int indexTwo)
        {
            List = list;
            IndexOne = indexOne;
            IndexTwo = indexTwo;
        }

    }

    public class QuickSort
    {
        private Random _Random;
        private PartitionDelegate _PartitionFunction;
        public delegate int PartitionDelegate(IList<IComparable> list, int left, int right);
        private IList<IComparable> _SortedList;

        private List<QuickSortChart> chart;

        public QuickSort(IList<IComparable> list)
        {
            _Random = new Random();
            _PartitionFunction = PartitionRandom;
            _SortedList = list;
            chart = new List<QuickSortChart>();

        }

        public List<QuickSortChart> GetChart()
        {
            return chart;
        }

        public IList<IComparable> Sort()
        {
            IList<IComparable> list = Sort(_SortedList, 0, _SortedList.Count - 1);
            chart.Add(new QuickSortChart(list.ToArray(), -1, -1));
            return list;
        }

        private IList<IComparable> Sort(IList<IComparable> list, int indexLeft, int indexRight)
        {
            if (indexLeft < indexRight)
            {
                int pivotIndex = _PartitionFunction(list, indexLeft, indexRight);
                IList<IComparable> tempList = Sort(list, indexLeft, pivotIndex - 1);
                tempList = Sort(tempList, pivotIndex + 1, indexRight);
                return tempList;
            }
            return list;
        }

        private int PartitionRandom(IList<IComparable> list, int leftIndex, int rightIndex)
        {
            int pivot = leftIndex + _Random.Next(rightIndex - leftIndex);
            chart.Add(new QuickSortChart(list.ToArray(), pivot, rightIndex));

            Swap(list, rightIndex, pivot);

            return PartitionRight(list, leftIndex, rightIndex);
        }

        private int PartitionRight(IList<IComparable> list, int leftIndex, int rightIndex)
        {
            IComparable pivot = list[rightIndex];
            int middle = leftIndex;
            for (int index = middle; index < rightIndex; index++)
            {
                if (list[index].CompareTo(pivot) <= 0)
                {
                    chart.Add(new QuickSortChart(list.ToArray(), index, middle));
                    Swap(list, index, middle);
                    middle++;
                }
            }

            chart.Add(new QuickSortChart(list.ToArray(), leftIndex, rightIndex));
            Swap(list, rightIndex, middle);
            return middle;
        }

        private void Swap(IList<IComparable> list, int indexOne, int indexTwo)
        {
            if (indexOne != indexTwo)
            {
                IComparable temp = list[indexOne];
                list[indexOne] = list[indexTwo];
                list[indexTwo] = temp;
            }
        }

    }
}