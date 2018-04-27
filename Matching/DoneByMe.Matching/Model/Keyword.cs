using System.Collections.Generic;

namespace DoneByMe.Matching.Model
{
    public class Keyword
    {
        public string Text { get; private set; }

        private Keyword(string text)
        {
            this.Text = text;
        }

        public static Keyword Has(string text)
        {
            return new Keyword(text);
        }

        public static ISet<Keyword> From(IEnumerable<string> keywords)
		{
			ISet<Keyword> steps = new HashSet<Keyword>();

			foreach (string text in keywords)
			{
				steps.Add(Keyword.Has(text));
			}

			return steps;
		}

        public override int GetHashCode()
		{
			return (Text?.GetHashCode()).GetValueOrDefault();
		}

		public override bool Equals(object other)
		{
			if (other == null || other.GetType() != typeof(Keyword))
			{
				return false;
			}
    
			return this.Text.Equals(((Keyword)other).Text);
		}

		public override string ToString()
		{
			return $"#{Text}";
		}
    }
}