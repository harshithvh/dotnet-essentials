using System;

namespace EmpMgmtUI.GreetingCode
{
    public class Greetings : IGreeting
    {
        public string GeetingMessage()
        {
            int hour = DateTime.Now.Hour;
            if (hour > 0 && hour < 12)
                return "Good morning";
            else if (hour >= 12 && hour < 16)
                return "Good afternoon";
            else if (hour >= 16 && hour < 20)
                return "Good evening";
            else
                return "Good night";
        }
    }
}
