using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace BinarySearcher.Tests
{
    [TestFixture]
    public class BinarySearcherTests
    {
        IEnumerable<TestCaseData> testCaseDatas
        {
            get
            {
                yield return new TestCaseData(new[] {3,5,10,15},10,2);
                yield return new TestCaseData(new[] { 3, 5, 10, 15 }, 17, -1);
                yield return new TestCaseData(new[] { "a","b","c" }, "d",-1);
                yield return new TestCaseData(new[] {"a", "b", "c"}, "c", 2);
                yield return new TestCaseData(new int[]{ }, 3, 10).Throws(typeof(ArgumentException));
            }
            
        }

        [Test,TestCaseSource(nameof(testCaseDatas))] 
        public void SeacherTestsInterface<T>(T[] collection,T item,int index)
        {
            int result=BinarySearcher<T>.Search(collection, item, (IComparator<T>)null);
            Assert.AreEqual(index,result);
        }

        [Test, TestCaseSource(nameof(testCaseDatas))]
        public void SeacherTestsDelegate<T>(T[] collection, T item, int index)
        {
            int result = BinarySearcher<T>.Search(collection, item, (a, b) => ((IComparable)a).CompareTo(b));
            Assert.AreEqual(index, result);
        }
    }
}
