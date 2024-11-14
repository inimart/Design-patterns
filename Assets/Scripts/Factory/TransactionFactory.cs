using System;
using System.Collections.Generic;

public class TransactionFactory
{
    private static Dictionary<Type, PlayerTransaction> transactionsPool = new();
        public static T Get<T>() where T : PlayerTransaction, new()
        {
            Type t = typeof(T);
            if (transactionsPool.ContainsKey(t))
            {
                return transactionsPool[t] as T;
            }

            T transaction = new T();
            Initializer.Injector.Inject(transaction);
            return transaction;
        }
}
