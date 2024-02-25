using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Services.Interfaces;

namespace Services.Implementations
{
    public class MathCalculConstantesService : IMathCalculConstantesService
    {
        public decimal CalculatePi(int decimals)
        {
            // Utilisation de la série de Nilakantha pour calculer π
            BigInteger pi = BigInteger.Pow(10, decimals) * 3;  // Initialisation à 3 * 10^decimals pour préserver la précision
            BigInteger sign = BigInteger.One;  // Alternance des signes dans la série
            BigInteger two = new BigInteger(2);
            BigInteger precision = BigInteger.Pow(10, decimals + 5);  // Précision interne accrue pour minimiser l'erreur d'arrondi

            for (BigInteger i = 1; i <= precision; i++)
            {
                BigInteger termDenominator = (2 * i) * (2 * i + 1) * (2 * i + 2);
                BigInteger term = 4 * BigInteger.Pow(10, decimals) * sign / termDenominator;

                pi += term;
                sign *= -1;  // Alternance des signes

                // Vérification de la convergence
                if (term == BigInteger.Zero)
                    break;
            }

            // Conversion du résultat en décimal et ajustement de la précision
            decimal piDecimal = (decimal)pi / (decimal)BigInteger.Pow(10, decimals);
            return decimal.Round(piDecimal, decimals);
        }

    }
}
