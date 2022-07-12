using System;
using currency.marshallzehr.app.Operations;
using currency.marshallzehr.business;
using currency.marshallzehr.business.Interface;
using currency.marshallzehr.model;

namespace currency.marshallzehr.app
{
    class Program
    {
        static IConfigBusiness configBusiness;
        static ICurrencyUnitOperations currencyUnitOperations;
        static OperationsLogic operationsLogic;

        static void Main(string[] args)
        {
            StartUp();
        }
       
        static void StartUp()
        {
            
            Console.WriteLine("******************************************");
            Console.WriteLine("*                                        *");
            Console.WriteLine("*           Currency Application         *");
            Console.WriteLine("*                                        *");
            Console.WriteLine("******************************************");

            Init();
            
            
        }

        static void Init() 
        {
            configBusiness = new ConfigBusiness();
            currencyUnitOperations = new CurrencyUnitOperations(configBusiness);
            operationsLogic = new OperationsLogic(configBusiness);
            
            Load();
            ChooseOperationType();
        }

        static void Load() 
        {
            Console.WriteLine("");
            Console.WriteLine("Program parameters are loading...!");
            StaticsVariables.currencylist = currencyUnitOperations.GetCurrencyList().Result;
            StaticsVariables.basecurrency = currencyUnitOperations.GetBase();

            Console.WriteLine("");
            Console.WriteLine("Program parameters are loaded...!");
        }
         
        static void ChooseOperationType() 
        {

            operationsLogic._chooseOperation.List();
            if (!operationsLogic._chooseOperation.Choose(out StaticsVariables.currentOperation, ChooseOperationUnit)) 
            {
                ChooseOperationType();
            }
        }


        static void ChooseOperationUnit()
        {
            operationsLogic._chooseUnitOperation.List();
            if (!operationsLogic._chooseUnitOperation.Choose(out StaticsVariables.targetcurrency, ChooseOperationTerm)) 
            {
                ChooseOperationUnit();
            }
        }

        static void ChooseOperationTerm()
        {
            operationsLogic._chooseTermOperation.List();
            if (!operationsLogic._chooseTermOperation.Choose(out StaticsVariables.currentOperationTerm, ChooseOperationExchange, ChooseOperationYear))
            {
                ChooseOperationTerm();
            }
        }


        static void ChooseOperationYear()
        {

            operationsLogic._chooseYearOperation.List();
            if (!operationsLogic._chooseYearOperation.Choose(out StaticsVariables.currentYear, ChooseOperationMonth))
            {
                ChooseOperationYear();
            }
        }

        static void ChooseOperationMonth()
        {

            operationsLogic._chooseMonthOperation.List();
            if (!operationsLogic._chooseMonthOperation.Choose(out StaticsVariables.currentMonth, ChooseOperationDay))
            {
                ChooseOperationMonth();
            }
        }

        static void ChooseOperationDay()
        {
            
            operationsLogic._chooseDayOperation.List();
            if (!operationsLogic._chooseDayOperation.Choose(out StaticsVariables.currentDay, ChooseOperationExchange))
            {
                ChooseOperationDay();
            }


        }
        

        static void ChooseOperationExchange()
        {
            var request = new ExchangeRequest
            {
                TargetUnit = StaticsVariables.currentOperation.Id.Equals(1) ? StaticsVariables.basecurrency.AlphabeticCode : StaticsVariables.targetcurrency.AlphabeticCode,
                SourceUnit = StaticsVariables.currentOperation.Id.Equals(1) ? StaticsVariables.targetcurrency.AlphabeticCode : StaticsVariables.basecurrency.AlphabeticCode
            };
            if (StaticsVariables.currentOperationTerm.NeedEntry) 
            {
                request.dateTime = new DateTime(StaticsVariables.currentYear.Id, StaticsVariables.currentMonth.Id, StaticsVariables.currentDay.Id);
            }

            operationsLogic._exchangeOperation.Validate();
            if (!operationsLogic._exchangeOperation.Choose(request, ChooseOperationRestart))
            {
                ChooseOperationExchange();
            }
        }


        static void ChooseOperationRestart()
        {

            operationsLogic._restartOperation.Ask();
            if (!operationsLogic._restartOperation.Choose(ChooseOperationType, CloseOperation))
            {
                ChooseOperationRestart();
            }


        }

        static void CloseOperation()
        {
            configBusiness.Dispose();
            currencyUnitOperations.Dispose();
            operationsLogic.Dispose();
            Environment.Exit(1);
        }
    }
}
