using System;
using System.Collections.Generic;
using System.Linq;

namespace TDDBank
{
    delegate void EinfacherDelegate();
    delegate void DelegateMitPara(string msg);
    delegate long CalcDelegate(int a, int b);

    class HalloDelegates
    {
        public HalloDelegates()
        {
            EinfacherDelegate meinDele = EinfacheMethode;
            Action meineDeleAlsAction = EinfacheMethode;
            EinfacherDelegate meinDeleAno = delegate () { Console.WriteLine("Hallo111"); };
            EinfacherDelegate meinDeleAno2 = () => { Console.WriteLine("Hallo111"); };
            EinfacherDelegate meinDeleAno3 = () => Console.WriteLine("Hallo111");

            DelegateMitPara deleMitPara = EineMethodeMitStringAlsPara;
            Action<string> deleAlsActionMitPara = EineMethodeMitStringAlsPara;
            DelegateMitPara deleMitParaAno = delegate (string txt) { Console.WriteLine(txt); };
            DelegateMitPara deleMitParaAno2 = (string txt) => { Console.WriteLine(txt); };
            DelegateMitPara deleMitParaAno3 = (txt) => Console.WriteLine(txt);
            DelegateMitPara deleMitParaAno4 = x => Console.WriteLine(x);

            CalcDelegate calcDele = Multi;
            Func<int, int, long> calcAlsFunc = Summ;
            CalcDelegate calcDeleAno = delegate (int a, int b) { return a - b; };
            CalcDelegate calcDeleAno2 = (a, b) => { return a - b; };
            CalcDelegate calcDeleAno3 = (a, b) => a - b;

            long result2 = calcAlsFunc.Invoke(5, 6);
            long result = calcDele.Invoke(5, 6);

            List<string> texte = new List<string>();
            texte.Where(Filter);
            texte.Where(x => x.StartsWith("b"));

            
        }

        private bool Filter(string arg)
        {
            if (arg.StartsWith("b"))
                return true;
            else
                return false;
        }

        private long Multi(int a, int b)
        {
            return a * b;
        }

        long Summ(int x, int y)
        {
            return x + y;
        }
        void EineMethodeMitStringAlsPara(string txt)
        {
            System.Console.WriteLine(txt);
        }
        void EinfacheMethode()
        {
            System.Console.WriteLine("Hallo");
        }
    }
}
