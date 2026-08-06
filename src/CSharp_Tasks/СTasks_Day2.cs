namespace CSharp_Tasks
{       
    public class CTasks_Day2
    {
        // Task 1: Check if a string is a palindrome
        public static bool IsPalindrome(string text) 
        {
            bool v_Result = true;
            string v_CleanText = text.Replace(" ", string.Empty).ToLower();
            
            int v_RightPtr = (int)(v_CleanText.Length / 2);
            int v_LeftPtr = (v_CleanText.Length % 2 == 1) ? v_RightPtr: v_RightPtr - 1;
            
            while ((v_LeftPtr >= 0) && (v_RightPtr < v_CleanText.Length))
            {
                    if (v_CleanText[v_LeftPtr] != v_CleanText[v_RightPtr]) 
                    {
                        v_Result = false;
                        break;
                    }
                    
                    v_LeftPtr--;
                    v_RightPtr++;
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