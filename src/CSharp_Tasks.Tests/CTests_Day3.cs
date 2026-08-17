namespace CSharp_Tasks.Tests;

[TestFixture]
public class CTests_Day3
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase(new int[] { 2, 7, 11, 15 }, 9, new int[] { 0, 1 })]
    [TestCase(new int[] { 1,1,1,5, 10, 11, 11, 14, 25, 40,41,42 }, 22, new int[] { 5, 6 })]
    [TestCase(new int[] { 1, 1, 1, 5, 10, 11, 11, 14, 25, 40, 41, 42 }, 23, new int[] { -1, -1 })]
    [TestCase(new int[] { 1 }, 23, new int[] { -1, -1 })]
    [TestCase(new int[] { 2, 10 }, 12, new int[] { 0, 1 })]
    public void Test_TwoSum(int[] input, int target, int[] expresult)
    {
        int[] res = CSharp_Tasks.CTasks_Day3.FindTwoSum(input, target);
        Assert.That(res, Is.EqualTo(expresult));     
    }

    [TestCase("swiss", 'w')]
    [TestCase("aaabbbccc", null)]
    [TestCase("aaabbbcccdddeeefffg", 'g')]
    [TestCase("swwisshg", 'i')]
    [TestCase("a", 'a')]
    [TestCase("", null)]
    public void Test_FirstNonRepeating(string input, char? expresult)
    {
        char? res = CTasks_Day3.FirstNonRepeating(input);
        
        if (expresult == null) 
        {
            Assert.That(res, Is.Null);
        }
        else
        {
            Assert.That(res, Is.EqualTo(expresult));
        }        
    }

    private static IEnumerable<TestCaseData> MyTupleTestCases()
    {
        // Wrap the tuple inside TestCaseData
        yield return new TestCaseData("abcabcbb", (3, "abc"));
        yield return new TestCaseData("abababcdefghibacdfghi", (9, "abcdefghi"));
        yield return new TestCaseData("aaaaaaaaa", (1, "a"));
        yield return new TestCaseData("babababadec", (5, "badec"));
        yield return new TestCaseData("a", (1, "a"));
        yield return new TestCaseData("", (0, (string?)null));
    }

    [Test]
    [TestCaseSource(nameof(MyTupleTestCases))]    
    public void Test_LongestSubstringWoRepeatingChars(string input, (int, string?) expresult)
    {
        (int, string?) res = CTasks_Day3.LongestSubstringWoRepeatingChars(input);
        Assert.That(res.Item1, Is.EqualTo(expresult.Item1));
        Assert.That(res.Item2, (expresult.Item2 == null) ? Is.Null : Is.EqualTo(expresult.Item2));
    }
}
