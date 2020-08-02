using Binary_Tree.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Binary_Tree.TreeInfo
{
    public class Test : BaseFunctions
    {
        public string TestName { get; set; }
        public DateTime DateOfCompletion { get; set; }
        public int Mark { get; set; }
        public Test(string testname, DateTime dateOfCompletition, int mark)
        {
            TestName = testname;
            DateOfCompletion = dateOfCompletition;
            Mark = mark;
        }
        public Test()
        { }

        public override int GetHashCode()
        {
            return GetStringHashCode(TestName, 3) ^ 
                DateOfCompletion.GetHashCode() ^ Mark;
        }

        public override bool Equals(object obj)
        {
            if (obj is Test && (obj as Test).TestName == TestName && 
                (obj as Test).DateOfCompletion == DateOfCompletion && 
                (obj as Test).Mark == Mark)
                return true;
            else
                return false;
        }
    }
}
