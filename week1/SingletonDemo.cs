using System;

class Logger {
    private static Logger _instance;
    private static readonly object _lock = new object();

    // Private constructor to prevent external instantiation
    private Logger() {
        Console.WriteLine("Logger created");
    }

    // Public static method to get the single instance
    public static Logger GetInstance() {
        if (_instance == null) {
            lock (_lock) // Thread-safe lazy initialization
            {
                if (_instance == null) {
                    _instance = new Logger();
                }
            }
        }

        return _instance;
    }

    public void Log(string message) {
        Console.WriteLine($"[LOG]: {message}");
    }
}


class SingletonDemo {
    public static void Main() {
        Logger logger1 = Logger.GetInstance();
        Logger logger2 = Logger.GetInstance();

        logger1.Log("Hello from logger1");
        logger2.Log("Hello from logger2");

        Console.WriteLine($"Same instance? {object.ReferenceEquals(logger1, logger2)}");
    }
}
