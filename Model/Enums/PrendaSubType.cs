using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenModuloC.Model.Enums
{
    public enum PrendaSubType {
        #region CamisaSubType
        MangaCorta, 
        MangaLarga, 
        CuelloMao, 
        CuelloComun,
        #endregion
        #region PantalonesSubType
        Comun,
        Chupin
        #endregion
    }
    public static class PrendaSubTypeFriendlyString
    {
        public static string toFriendlyString(this PrendaSubType me)
        {
            switch (me)
            {
                case PrendaSubType.MangaCorta:
                    return "Manga corta";
                case PrendaSubType.MangaLarga:
                    return "Manga larga";
                case PrendaSubType.CuelloMao:
                    return "Cuello mao";
                case PrendaSubType.CuelloComun:
                    return "Cuello comun";
                case PrendaSubType.Comun:
                    return "Comun";
                case PrendaSubType.Chupin:
                    return "Chupin";
                default:
                    return "ERROR";
            }
        }
    }
}
