using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_concept.BuiltItems;

namespace Wpf_concept.Restriction
{
    public static class FIlterCV
    {
        //private static string _curCompName;
        //private static List<ComponentValue> _CVs;
        //private static List<RestrictedData> _restrictedList;
        //private static Dictionary<string, ComponentValue> _preAnsDict;

        public static List<ComponentValue> Filter(string curCompName, List<ComponentValue> cvsAll, List<RestrictedData> restrictedList, Dictionary<string, ComponentValue> preAnsDict)
        {
            //_curCompName = curCompName;
            //_CVs = cvs;
            //_restrictedList = restrictedList;
            //_preAnsDict = preAnsDict;

            List<string> childVal = FilterChildVal(curCompName, restrictedList, preAnsDict, cvsAll);
            if (childVal.Count != 0)
            {
                return GetCVObject(curCompName, childVal, cvsAll);
            }

            List<ComponentValue> CVlist = GetPossibleValues(curCompName, cvsAll);
            return CVlist;
        }

        private static List<ComponentValue> GetPossibleValues(string compName, List<ComponentValue> cvList)
        {
            var list = new List<ComponentValue>();
            foreach (var cv in cvList)
            {
                if (cv.Component.Name == compName)
                    list.Add(cv);
            }
            return list;
        }

        private static List<string> FilterChildVal(string compName, List<RestrictedData> restritedList, Dictionary<string,ComponentValue> preAnsDict, List<ComponentValue> CVs)
        {
            var childValList = new List<string>();

            var filterList = restritedList.Where(x =>
                x.ChildName == compName &&
                preAnsDict.ContainsKey(x.ParentName) &&
                preAnsDict[x.ParentName]?.Value == x.ParentValue).ToList();

            if (filterList != null)
            {
                filterList.ForEach(t => childValList.Add(t.ChildValue));
            }
            return childValList;
        }

        private static List<ComponentValue> GetCVObject(string compName, List<string> childValList, List<ComponentValue> cvs)
        {
            cvs = cvs.Where(t => t.Component.Name == compName).ToList();

            var result = from cv in cvs
                     join val in childValList
                     on cv.Value equals val
                     select cv;
            return result.ToList();
        }
        private static void ShowChoices()
        {
            // when there is 'choice' under CompValue
        }
    }
}
