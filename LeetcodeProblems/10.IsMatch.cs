using System.Text;

namespace LeetcodeProblems;

public class IsMatch
{
    public static IEnumerable<object[]> TestData => new List<object[]>
    {
        new object[] { "aa", "a", false },
        new object[] { "aa", "a*", true },
        new object[] { "aa", ".*", true },
        new object[] { "ab", ".*", true },
        new object[] { "aab", "c*a*b", true },
        new object[] { "mississippi", "mis*is*ip*.", true },
        new object[] { "abcd", "d*", false },
        new object[] { "ab", ".*c", false },
        new object[] { "aaa", "aaaa", false },
        new object[] { "aaa", "a*a", true },
        new object[] { "aaa", "ab*ac*a", true },
        new object[] { "a", "ab*a", false },
        new object[] { "aaa", "a.a", true },
        new object[] { "a", ".*..a*", false },
        new object[] { "ab", ".*..", true },
        // todo : needs to redesign algorithm - first of all we should to find all matches and after that will try to accept all possible combinations of these matches to pattern
        // new object[] { "ab", ".*..c*", true }, 
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string s, string p, bool result)
    {
        Assert.Equal(result, Method(s, p));
    }

    private bool Method(string s, string p)
    {
        if (!p.Contains('*') && !p.Contains('*') && p.Length > s.Length) return false;
        if (s.Length > p.Length && p[^1] != '*') return false;
        if (p.Length == 1 && s.Length == p.Length) return p == "." || p == s;
        if (!p.Contains('*') && !p.Contains('.') && p.Length == s.Length) return p == s;
        if (p is [var letter, '*']) return letter is '.' || s.All(x => x == letter);

        var patterns = new List<string>();
        var buffer = new StringBuilder(p.Length);
        for (var i = 0; i < p.Length; i++)
        {
            buffer.Append(p[i]);
            switch (p[i])
            {
                case '.':
                    if (i + 1 >= p.Length) break;
                    if (p[i + 1] is '.') continue;
                    if (p[i + 1] != '*')
                    {
                        var first = new char[buffer.Length - 1];
                        buffer.CopyTo(0, first, 0, buffer.Length - 1);
                        patterns.Add(new string(first));

                        first = new char[1];
                        buffer.CopyTo(buffer.Length - 1, first, 0, 1);
                        patterns.Add(new string(first));

                        buffer.Clear();
                    }

                    break;
                case '*':
                {
                    if (buffer.Length == 2)
                    {
                        var pattern = new char[2];
                        buffer.CopyTo(0, pattern, 0, 2);
                        patterns.Add(new string(pattern));
                    }
                    else
                    {
                        var first = new char[buffer.Length - 2];
                        buffer.CopyTo(0, first, 0, buffer.Length - 2);
                        patterns.Add(new string(first));

                        first = new char[2];
                        buffer.CopyTo(buffer.Length - 2, first, 0, 2);
                        patterns.Add(new string(first));
                    }

                    buffer.Clear();
                    break;
                }
            }
        }

        if (buffer.Length > 0)
        {
            var pattern = new char[buffer.Length];
            buffer.CopyTo(0, pattern, 0, buffer.Length);
            buffer.Clear();
            patterns.Add(new string(pattern));
        }

        string str;

        if (!patterns[^1].EndsWith('*'))
        {
            var lastPattern = patterns[^1];
            var patternIndex = lastPattern.Length - 1;
            var strIndex = s.Length - 1;
            for (; patternIndex >= 0; patternIndex--, strIndex--)
            {
                if (lastPattern[patternIndex] is '.') continue;
                if (lastPattern[patternIndex] != s[strIndex]) return false;
            }

            str = new string(s.ToCharArray(), 0, s.Length - lastPattern.Length);
            patterns.RemoveAt(patterns.Count - 1);
        }
        else str = new string(s);

        foreach (var pattern in patterns)
        {
            if (pattern is [var l, '*'])
            {
                str = l is '.' ? string.Empty : str.TrimStart(l);
                continue;
            }

            if (string.IsNullOrEmpty(str)) return false;

            if (pattern == ".")
            {
                str = str[1..];
                continue;
            }

            if (pattern.Where((t, i) => str[i] != t).Any()) return false;

            str = str[pattern.Length..];
        }

        return str.Length == 0;
    }
}