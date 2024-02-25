using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces.Maths
{
    public interface IMathCalculAlgebreService
    {
        object CalculerRacineCarree(double nombre);
        object ConvertirBase(string valeur, int baseOrigine, int baseDestination);
        object ResoudreEquationPremierDegre(double a, double b);
        object ResoudreEquationSecondDegre(double a, double b, double c);
    }
}
