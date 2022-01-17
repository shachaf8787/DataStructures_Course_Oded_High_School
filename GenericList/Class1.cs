using System;
using System.Collections.Generic;
using System.Text;

namespace StacksAndLists
{
    class Class1
    {
		public static void SwitchVals(Node<int> one, Node<int> two)
		{

			int temp = one.GetValue();
			one.SetValue(two.GetValue());
			two.SetValue(temp);
		}

		public static void Change(Node<int> first)
		{
			Node<int> last = first;
			Node<int> pos = first;

			while (pos.GetNext() != null)
			{
				pos = pos.GetNext();        // הגעה לתא האחרון ברשימה
			}
			last = pos;
			SwitchVals(first, last);        // מחליף את ערכי הראשון והאחרון
			pos = first;
			first = first.GetNext();

			while (first != last)
			{
				while (pos.GetNext() != last)
				{
					pos = pos.GetNext();    // מקרב את ההתחלה והסוף לאמצע

				}
				last = pos;
				SwitchVals(first, last);
				first = first.GetNext();
				pos = first;
			}




		}
	}
}
