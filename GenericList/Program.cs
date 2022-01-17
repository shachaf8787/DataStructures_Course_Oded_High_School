using System;

namespace StacksAndLists
{
	class Program
	{
		public static void Main(string[] args)
		{

			// Declare List:
			Node<int> p1 = new Node<int>(5), p2 = new Node<int>(5), p3 = new Node<int>(8), p4 = new Node<int>(10), p5 = new Node<int>(13);
			p1.SetNext(p2); p2.SetNext(p3); p3.SetNext(p4); p4.SetNext(p5);

			Node<int> po1 = new Node<int>(5), po2 = new Node<int>(7), po3 = new Node<int>(8), po4 = new Node<int>(40), po5 = new Node<int>(45);
			po1.SetNext(po2); po2.SetNext(po3); po3.SetNext(po4); po4.SetNext(po5);

			Couple c1 = new Couple(2,5);
			Couple c2 = new Couple(0,4);
			Couple c3 = new Couple(3,0);
			Couple c4 = new Couple(4,6);
			Stack<Couple> Couples = new Stack<Couple>();
			Couples.Push(c4);
			Couples.Push(c3);
			Couples.Push(c2);
			Couples.Push(c1);

            //Console.WriteLine(Tar18(Couples));//
            Console.WriteLine("Hello");

			Change(p1);
            Console.WriteLine(p1);


		}
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
				pos = pos.GetNext();		// הגעה לתא האחרון ברשימה
            }
			last = pos;
			SwitchVals(first, last);		// מחליף את ערכי הראשון והאחרון
			pos = first;
			first = first.GetNext();
			
			while(first != last)
            {
				while (pos.GetNext() != last)
                {
					pos = pos.GetNext();	// מקרב את ההתחלה והסוף לאמצע

                }
				last = pos;
				SwitchVals(first, last);
				first = first.GetNext();
				pos = first;
            }
			

			

        }
		public static Stack<int> Tar18(Stack<Couple> stk)
        {
			Stack<int> stk2 = new Stack<int>();
			do
			{
				for (int i = 0; i < stk.Top().GetAppears(); i++)
				{
					stk2.Push(stk.Top().GetNum());
				}
				stk.Pop();

			} while (!stk.IsEmpty());
				return stk2;
        }

		

		public static int GetEvenCountAfter(Node<int> first, Node<int> after)
		{
			while (first != after && first != null)
			{
				first = first.GetNext();
			}

			if (first == null)
			{
				return 0;
			}
			if (after.GetValue() % 2 == 0)
			{
				return 1 + GetEvenCountAfter(first, first.GetNext());
			}
			else
			{
				return 0 + GetEvenCountAfter(first, first.GetNext());
			}


			static void PrintTheEvenIndexesValues(Node<int> first)
			{
				Console.WriteLine(first.GetValue());
				if (first.HasNext() && first.GetNext().HasNext())
				{
					PrintTheEvenIndexesValues(first.GetNext().GetNext());
				}
			}


			static int SumFromPToQ(Node<int> lst, Node<int> p, Node<int> q)
			{
				if (p.GetNext() == q)
				{
					return p.GetValue();
				}

				return p.GetValue() + SumFromPToQ(lst, p.GetNext(), q);
			}



			static int DifferenceInLength(Node<int> lst1, Node<int> lst2)
			{
				if (lst1.HasNext() && !lst2.HasNext())
				{
					int count = 0;
					for (; lst1.HasNext(); count++)
					{
						lst1 = lst1.GetNext();
					}

					return count;
				}
				else if (lst2.HasNext() && !lst1.HasNext())
				{
					int count = 0;
					for (; lst2.HasNext(); count++)
					{
						lst2 = lst2.GetNext();
					}

					return count;
				}
				else if (!lst1.HasNext() && !lst2.HasNext())
				{
					return 0;
				}

				return DifferenceInLength(lst1.GetNext(), lst2.GetNext());
			}
			static Node<string> RemoveLongWords(Node<string> first, int len)
			{
				if (first == null)
					return first;
				Node<string> head = first;
				do
				{
					if (first.GetNext().GetValue().Length < len)
						first.SetNext(first.GetNext().GetNext());
					else
						first = first.GetNext();




				} while (first.HasNext() && first.GetNext().HasNext());
				return head;
			}

			static Node<T> AddLast<T>(Node<T> p, T value) // Function in kind of listservices
			{
				Node<T> newNode = new Node<T>(value);
				p.SetNext(newNode);
				return newNode;
			}

			static int NumOfWordsStartingWithCapitalLetters(Node<string> first)
			{
				if (first == null)
					return 0;

				int counter = 0;
				do
				{

					if (char.IsUpper(first.GetValue()[0]))
						counter++;
					first = first.GetNext();
				} while (first.HasNext());

				return counter;

			}
		}
            public static int Power(int n1, int n2) { 
			
				if (n2 == 0)
					return 1;
				else
					return Power(n1, n2-1) * n1;
			}
		public static void PrintTheZugiIndexes(Node<int> first)
		{
			if (first == null)
				Console.WriteLine("No values in list");
			if (!first.HasNext())
				Console.WriteLine("End of List");

			first = first.GetNext();
			Console.WriteLine(first.GetValue());
			while (first.GetNext().HasNext()) { 

				PrintTheZugiIndexes(first.GetNext()); 
			}
        }

		
	}
}