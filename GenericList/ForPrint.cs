using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures_Course_Oded_High_School
{
    class ForPrint
	{
		public static bool SameTree(BinNode<int> a, BinNode<int> b)
		{
			/*בודק האם שני עצים זהים לחלוטין*/
			if (a == null && b == null)
				return true;
			if (a == null || b == null || a.GetValue() != b.GetValue())
				return false;
			return SameTree(a.GetLeft(), b.GetLeft()) && SameTree(a.GetRight(), b.GetRight());
		}

		public static void SwipeTree<T>(BinNode<T> t)
		{
			//מחליף את ערכי העץ השמאליים לימין והימניים לשמאל
			BinNode<T> left;
			if (t == null)
				return;
			if (t.GetRight() == t.GetLeft())
				return;
			else
				left = t.GetLeft();
			t.SetLeft(t.GetRight());
			t.SetRight(left);
			SwipeTree(t.GetLeft());
			SwipeTree(t.GetRight());

		}

		public static bool P177T22(BinNode<int> bt, int num)
		{
			/*הפעולה בודקת האם עץ מכיל את כל המספרים מאחד ועד "נום" (שהתקבל בקלט) פעם אחת בלבד*/
			for (int i = 1; i < num + 1; i++)
			{
				if (!IsExistInTree(bt, i))
				{
					return false;
				}


			}
			return true;
		}
		public static bool Simetri(BinNode<int> bt)
		{
			/*בדיקה האם עץ סימטרי*/
			if (bt == null)
				return false;
			bool simetri = (Math.Abs(TreeHeight(bt.GetLeft()) - TreeHeight(bt.GetRight()))) == 1;
			return simetri;

		}

		public static bool SonsTest(BinNode<int> bt)
		{
			/*בודק אם לכל צומת יש 2 או 0 בנים*/
			if (bt == null)
				return true;
			if (IsLeaf(bt))
				return true;
			if (bt.HasLeft() && bt.HasRight())
				return true && SonsTest(bt.GetLeft()) && SonsTest(bt.GetRight());
			if (!bt.HasRight() && bt.HasLeft())
				return false;
			if (bt.HasRight() && !bt.HasLeft())
				return false;
			else
				return true;
		}
		public static bool IsExistStackRec(Stack<int> s, int n)
		{
			if (s.IsEmpty())
				return false;
			int x = s.Pop();
			bool exists = (x == n || IsExistStackRec(s, n));
			s.Push(x); //לאחר הקריאה הרקורסיבית, האיבר שנשלף נדחף בחזרה אל תוך המחסנית
			return exists;
		}

		// טענת כניסה: הפעולה מקבלת עץ בינארי של מספרים שלמים ומספר שלם המייצג רמה בעץ
		// טענת יציאה: הפעולה מחזירה את מספר הצמתים ברמה שהתקבלה
		// סיבוכיות זמן ריצה: O(n)
		public static int NodesInLevel(BinNode<int> bt, int level)
		{
			if (bt == null)
				return 0;
			if (level == 0)
				return 1;
			return NodesInLevel(bt.GetLeft(), level - 1) + NodesInLevel(bt.GetRight(), level - 1);
		}












	}
}
