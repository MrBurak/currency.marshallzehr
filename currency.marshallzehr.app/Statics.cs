using currency.marshallzehr.model;
using System.Collections.Generic;

namespace currency.marshallzehr.app
{
    public class StaticsVariables
    {
        public static Operation currentOperation;
        public static OperationTerm currentOperationTerm;
        public static Operation currentYear;
        public static Operation currentMonth;
        public static Operation currentDay;
        public static Dictionary<string, CurrencyUnit> currencylist;
        public static CurrencyUnit targetcurrency;
        public static CurrencyUnit basecurrency;
    }

    
}
