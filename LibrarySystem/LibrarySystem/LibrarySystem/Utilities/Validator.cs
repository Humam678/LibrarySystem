using System;

namespace LibrarySystem.Utilities
{
    public static class Validator
    {
        public static bool IsValidEmail(string email)//يتحقق ان البريد الالكتروني يحوي على @ و . يعني صالح
        {
            if(string.IsNullOrEmpty(email)) 
                return false;

            bool isValid1 = false;
            bool isValid2 = false;
            for(int i=0; i<email.Length; i++)
            {
                if(email[i] =='@')
                    isValid1 = true;
                else if(email[i] =='.')
                    isValid2 = true;
            }
            //البريد صالح اذا وجدنا الرمزين معا
            return isValid1 && isValid2;
        }
        public static bool IsNotEmpty(string Text)
        {
            if(string.IsNullOrEmpty(Text))
                return false;

            for (int i = 0; i < Text.Length; i++)
            {
                if (Text[i] != ' ')
                    return true;
            }
            return false;
        }

       public static bool IsValidId(string Id)// يمنع المعرفات القصير جدا او الفارغة
        {
            if(Id != null&&Id.Length > 2)
                return true;
            else
                return false;
        }

        //يتحقق من ان الرقم موجب
        //نستخدمه  للتحقق من عدد الصفحات والمدة 
        public static bool IsPositive(int Number)
        {
            return Number > 0;
        }

    }
}
