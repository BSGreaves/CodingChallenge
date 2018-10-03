using System;
using System.Linq;

namespace CodingChallenge.FamilyTree
{
    public class Solution
    {
        // so there's a couple of ways to go about this one
        // but considering the relative simplicity of the family tree 
        //  (no marriages/couples so no more than one parent,
        //   entry to the tree from the top as opposed to entry from the middle or bottom,
        //   etc.)
        // probably the most straightforward method is to use recursion
        public string GetBirthMonth(Person person, string descendantName)
        {
            if (descendantName == person.Name) return person.Birthday.ToString("MMMM");
            if (!(bool)person.Descendants?.Any()) return string.Empty;
            foreach (var descendant in person.Descendants)
            {
                var resultFromAllDescendents = GetBirthMonth(descendant, descendantName);
                if (!string.IsNullOrWhiteSpace(resultFromAllDescendents)) return resultFromAllDescendents;
            }
            return string.Empty;
        }
    }
}