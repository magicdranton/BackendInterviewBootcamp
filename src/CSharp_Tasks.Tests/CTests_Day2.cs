namespace CSharp_Tasks.Tests;

[TestFixture]
public class CTests_Day2
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase("A man a plan a canal Panama", true)]
    [TestCase("racecar", true)]
    [TestCase("hello", false)]
    [TestCase("Was it a car or a cat I saw", true)]    
    [TestCase("Not a palindrome", false)]
    [TestCase("    a   ", true)]
    [TestCase("A b B  a", true)]
    [TestCase(" ", true)]
    [TestCase("", true)]
    public void Test_IsPalindrome(string p_InputStr, bool p_ExpectedResult)
    {        
        bool v_Result = CSharp_Tasks.CTasks_Day2.IsPalindrome(p_InputStr);
        Assert.That(v_Result, Is.EqualTo(p_ExpectedResult));     
    }    

    [TestCase(new int[] { 3, 1, 4, 1, 5, 9, 2, 6, 5, 3, 5 }, 1, 9)]
    [TestCase(new int[] { -10, 0, 10, 20, -5 }, -10, 20)]
    [TestCase(new int[] { 42 }, 42, 42)]
    [TestCase(new int[] { }, 0, 0)]
    public void Test_GetMinMaxVals(int[] p_ints, int p_ExpectedMinVal, int p_ExpectedMaxVal)
    {
        (int MinVal, int MaxVal) v_Result = CSharp_Tasks.CTasks_Day2.GetMinMaxVals(p_ints);
        Assert.That(v_Result.MinVal, Is.EqualTo(p_ExpectedMinVal));
        Assert.That(v_Result.MaxVal, Is.EqualTo(p_ExpectedMaxVal));
    }    
}

[TestFixture]
public class CTests_LRU_Cache
{
    private CSharp_Tasks.CLRU_Cache? m_Cache = null;
   
    [Test]
    public void Test_LRU_Cache_3()
    {
        m_Cache = new CLRU_Cache(3);

        m_Cache.Put("Apple", "APL");
        m_Cache.Put("Banana", "BAN");
        m_Cache.Put("Coconut", "COC");
        Assert.That(m_Cache.DisplayCache(), Is.EqualTo("COC BAN APL "));

        m_Cache.Get("Apple");
        Assert.That(m_Cache.DisplayCache(), Is.EqualTo("APL COC BAN "));

        m_Cache.Put("Durian", "DUR");
        string? v_Value = m_Cache.Get("Banana");
        Assert.That(v_Value, Is.Null);
        Assert.That(m_Cache.DisplayCache(), Is.EqualTo("DUR APL COC "));

        v_Value = m_Cache.Get("Coconut");
        Assert.That(v_Value, Is.EqualTo("COC"));
        Assert.That(m_Cache.DisplayCache(), Is.EqualTo("COC DUR APL "));
    }

    [Test]
    public void Test_LRU_Cache_1()
    {
        m_Cache = new CLRU_Cache(1);

        m_Cache.Put("A", "A");
        m_Cache.Put("B", "B");

        string? v_Val = m_Cache.Get("A");
        Assert.That(v_Val, Is.Null);

        v_Val = m_Cache.Get("B");
        Assert.That(v_Val, Is.EqualTo("B"));

        m_Cache.Put("A", "1");
        m_Cache.Put("A", "2");
        
        v_Val = m_Cache.Get("A");
        Assert.That(v_Val, Is.EqualTo("2"));
    }
}
