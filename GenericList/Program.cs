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

			

			Stack<int> Integers1 = new Stack<int>();
			Integers1.Push(2);
			Integers1.Push(4);
			Integers1.Push(223);
			Integers1.Push(8);
			Integers1.Push(5);
			Integers1.Push(4);
			
			Stack<int> Integers2 = new Stack<int>();
			Integers2.Push(2);
			Integers2.Push(4);
			Integers2.Push(223);
			Integers2.Push(78);
			Integers2.Push(5);
			Integers2.Push(4);
            //Console.WriteLine(Tar18(Couples));//
            /*
			Console.WriteLine("Stack no.1 = " + Integers1);
			Console.WriteLine("Stack no.2 = " + Integers2);

			Console.WriteLine("The Output of IfEquals(Stack1, Stack2) is: " + IfEquals(Integers1, Integers2));

			Console.WriteLine("The Output of IfExistInStack(Stack1, 8) is: " + IfExistInStack(Integers1, 8));
			Console.WriteLine("The Output of IfExistInStack(Stack1, 1) is: " + IfExistInStack(Integers1, 1));

			//Console.WriteLine("The Output of IfEquals(Stack1, Stack2) is: " + IfEquals(Integers1, Integers2));
			*/

            //Console.WriteLine(AhadotCheck(Integers2, 3));
            Console.WriteLine(FbiTargilMain("hi my name is shachaf, nice to meet you!"));
		}
		
		public static bool LenghtIsEven(string word)
        {
			if (word.Length % 2 == 0)
				return true;
			return false;
        }
		public static string SwitchTheCneterChar(string word)
        {
			char[] charArr = word.ToCharArray();
			if(charArr.Length <= 2)
            {
				return "" + 'a' + 'b';
            }
            if (LenghtIsEven(word))
            {
				charArr[charArr.Length / 2] = 'a';
				charArr[(charArr.Length / 2) - 1] = 'b';
			}
			else
				charArr[(word.Length / 2)] = 'a';

			string fixedString = new string(charArr);
			return fixedString;

		}

		public static string FbiTargilMain(string sentence)
        {
			string[] words = sentence.Split(' ');
			string fixedCentence = "";
            for (int i = 0; i < words.Length; i++)
            {
				fixedCentence += SwitchTheCneterChar(words[i]) + ' ';
            }
			return fixedCentence;
        }

		public static bool AhadotCheck(Stack<int> stk, int num)
        {
			Stack<int> backup = new Stack<int>();
			int x;
			bool flag;

			flag = false;
			while (!stk.IsEmpty())
            {
				x = stk.Pop();
				backup.Push(x);
				if (x % 10 == num)
					flag = true;

				
			}
			
			while (!backup.IsEmpty())
				stk.Push(backup.Pop());
			return flag;
				

        }

		public static int LastAndRemove(Stack<int> stk)
        {
			Stack<int> temp = new Stack<int>();

			int lenght = GetLenght(stk);
            for (int i = 0; i < lenght-1; i++)
            {

				temp.Push(stk.Pop());
            }
			int thelast = stk.Pop();
            while (!temp.IsEmpty())
            {
				stk.Push(temp.Pop());
			}
			return thelast;



        }

		public static int GetLenght(Stack<int> s)
        {
			Stack<int> s2 = new Stack<int>();
			int counter = 0;
            while (!s.IsEmpty())
            {
				s2.Push(s.Pop());
				counter++;

            }
			while (s2.IsEmpty())
            {
				s.Push(s2.Pop());
				
            }
			return counter;
        }
		public static bool IfExistInStack(Stack<int> s, int num)
        {
			if (s.IsEmpty())
				return false;
			if (s.Pop() == num)
				return true;
			else
				return false | IfExistInStack(s, num);
        }

		public static bool IfEquals(Stack<int> s1, Stack<int> s2)
		{
			if (s1.IsEmpty() && !s2.IsEmpty())		//if s1 is empty and s2 is not
				return false;
			if (!s1.IsEmpty() && s2.IsEmpty())      //if s2 is empty and s1 is not
				return false;
			if (s1.IsEmpty() && s2.IsEmpty())
				return true;
			if (s1.Pop() == s2.Pop())				//if the top values are equals
				return true && IfEquals(s1, s2);		//return true for these values											// and check for the next values
			else
				return false;

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