using System;
using System.Text;
using Readify.Service.Contracts;

namespace Readify.Service.Impl
{
	public class StringReverser : IStringReverser
	{
		public string ReverseWords(string s)
		{
			if (s == null)
			{
				throw new ArgumentNullException("s", "input string is null");
			}

			if (s == "")
			{
				return "";
			}

			var result = new StringBuilder(s.Length);

			int i = 0;
			while (i < s.Length)
			{
				if (s[i] == ' ')
				{
					result.Append(s[i]);
					i++;
				}
				else
				{
					var word = new StringBuilder();
					while (i < s.Length && s[i] != ' ')
					{
						word.Append(s[i]);
						i++;
					}

					result.Append(ReverseString(word));
				}
			}

			return result.ToString();
		}

		public StringBuilder ReverseString(StringBuilder s)
		{
			var sb = new StringBuilder(s.Length);

			for (int i = s.Length - 1; i >= 0; i--)
			{
				sb.Append(s[i]);
			}

			return sb;
		}
	}
}