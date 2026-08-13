namespace CSharp_Tasks
{       
    public class CTasks_Day2
    {
        // Task 1: Check if a string is a palindrome
        public static bool IsPalindrome(string p_text) 
        {
            bool v_Result = true;
            
            int v_RightPtr = p_text.Length - 1;
            int v_LeftPtr = 0;
            
            while (v_LeftPtr < v_RightPtr)
            {
                // whitespace throttling
                while (Char.IsWhiteSpace(p_text[v_LeftPtr]) && v_LeftPtr < p_text.Length)
                {
                    v_LeftPtr++;
                }               

                while (Char.IsWhiteSpace(p_text[v_RightPtr]) && (v_RightPtr >= 0))
                {
                    v_RightPtr--;
                }

                // Guard checks                
                if (v_LeftPtr > v_RightPtr) break;
                
                char v_FirstC = Char.ToLowerInvariant(p_text[v_LeftPtr]);
                char v_SecondC = Char.ToLowerInvariant(p_text[v_RightPtr]);

                if (v_FirstC != v_SecondC) 
                {
                    v_Result = false;
                    break;
                }
                
                v_LeftPtr++;
                v_RightPtr--;
            }	
            
            return v_Result;
        }

        // Task 2: Find the minimum and maximum values in an array
        public static (int MinVal, int MaxVal) GetMinMaxVals(int[] nums)
        {
            (int MinVal, int MaxVal) v_Result = (0, 0);

            if (nums.Length == 0) return v_Result;

            v_Result.MinVal = nums[0];
            v_Result.MaxVal = nums[0];
            
            for (int v_Index=1; v_Index < nums.Length; v_Index++)
            {
                if (v_Result.MinVal > nums[v_Index]) v_Result.MinVal = nums[v_Index];
                if (v_Result.MaxVal < nums[v_Index]) v_Result.MaxVal = nums[v_Index];
            }
            return v_Result;
        }
    }
}