using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortalSos.Infra.CrossCutting.Common.Helpers
{
    /// <summary>
    /// Métodos avançados para randomização
    /// </summary>
    public static class Randomizer
    {
        private static Random ListRandom;
        private static Random NextRandom;
        private static ArrayList NextRandomHistory;

        static Randomizer()
        {
            ListRandom = new Random();
            NextRandom = new Random();
            NextRandomHistory = new ArrayList();
        }

        /// <summary>
        /// Gera uma lista preencida com números organizados de forma aleatória
        /// </summary>
        /// <param name="min">O número de partida</param>
        /// <param name="count">Quantidade de números</param>
        /// <returns></returns>
        public static IList<int> Random(int min, int count)
        {
            IList<int> list = Enumerable.Range(min, count).OrderBy(r => ListRandom.Next()).ToList();
            return list;
        }

        /// <summary>
        /// Gerar um número aleatório único
        /// </summary>
        /// <returns>Retorna um número aleatório único nesta instância do aplicativo</returns>
        public static int Next()
        {
            int value = NextRandom.Next();
            while (true)
            {
                if (!NextRandomHistory.Contains(value))
                {
                    NextRandomHistory.Add(value);
                    return value;
                }
                value = NextRandom.Next();
            }
        }

        /// <summary>
        /// Gerar uma letra aleatória
        /// </summary>
        /// <returns></returns>
        public static char RandomLetter()
        {
            return (char)((new int[] { 
                NextRandom.Next(65, 90), 
                NextRandom.Next(97, 122), 
                NextRandom.Next(128, 166) 
            })[NextRandom.Next(0, 3)]);
        }

        /// <summary>
        /// Gerar um número de 0 a 9 aleatóriamente
        /// </summary>
        /// <returns></returns>
        public static int RandomDigit()
        {
            return NextRandom.Next(0, 10);
        }

        /// <summary>
        /// Gerar um caractere aleatório
        /// </summary>
        /// <returns></returns>
        public static char RandomChar()
        {
            return (char)NextRandom.Next(1, 256);
        }

        /// <summary>
        /// Gerar uma palavra com letras aleatórias
        /// </summary>
        /// <param name="charCount">Quantidade de letras</param>
        /// <returns></returns>
        public static string RandomWord(int charCount)
        {
            StringBuilder str = new StringBuilder();
            char previous = (char)0;
            for (int i = 1; i <= charCount; i++)
            {
                char rnd = RandomLetter();
                while (true)
                {
                    if (rnd != previous) break;
                    rnd = RandomLetter();
                }
                str.Append(rnd);
                previous = rnd;
            }
            return str.ToString();
        }
    }
}
