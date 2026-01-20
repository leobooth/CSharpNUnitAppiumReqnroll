namespace CSharpNUnitAppiumReqnroll.TestFramework.Framework.Waits;

public class HardWait
{
    private static void hardWait(int waitTimeInMillis) {
        try {
            Thread.Sleep(waitTimeInMillis);
        } catch (Exception e)
        {
            Console.WriteLine("Unable to sleep execution thread: \n" + e.Message);
        }
    }

    public static void forSeconds(int seconds) {
        hardWait(seconds * 1000);
    }

    public static void forMillis(int milliseconds) {
        hardWait(milliseconds);
    }
}