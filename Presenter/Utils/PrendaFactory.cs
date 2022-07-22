using ExamenModuloC.Model.Director;
using ExamenModuloC.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace ExamenModuloC.Presenter.Utils
{
    static internal class PrendaFactory
    {
        public static IPrenda getPrendaFromJson(JsonNode node)
        {
            Model.Enums.PrendaType type = (Model.Enums.PrendaType)((int)node["Type"]["TypeOfPrenda"]);
            if (type == Model.Enums.PrendaType.Camisa)
            {
                Model.Prendas.Camisa result = new Model.Prendas.Camisa();
                result.Id = (int)node["Id"];
                result.Stock = (int)node["Stock"];
                result.Quality = (Model.Enums.PrendaQuality)(int)node["Quality"];
                result.UnitPrice = (float)node["UnitPrice"];
                //result.Type.TypeOfPrenda = Model.Enums.PrendaType.Camisa;
                var subtypes = node["Type"]["PrendaSubTypes"].AsArray();
                foreach (int subtype in subtypes)
                {
                    result.Type.PrendaSubTypes.Add((Model.Enums.PrendaSubType)subtype);
                }
                return result;

            } else if (type == Model.Enums.PrendaType.Pantalon)
            {
                Model.Prendas.Pantalon result = new Model.Prendas.Pantalon();
                result.Id = (int)node["Id"];
                result.Stock = (int)node["Stock"];
                result.Quality = (Model.Enums.PrendaQuality)(int)node["Quality"];
                result.UnitPrice = (float)node["UnitPrice"];
                var subtypes = node["Type"]["PrendaSubTypes"].AsArray();
                foreach (int subtype in subtypes)
                {
                    result.Type.PrendaSubTypes.Add((Model.Enums.PrendaSubType)subtype);
                }
                return result;
            } else
            {
                throw new Exceptions.InvalidPrendaTypeException(type);
            }
        }
        public static IPrenda getPrendaFromView(IViewCotizador view)
        {
            IPrendaBuilder builder;
            PrendaDirector director;
            if (view.isCamisaChecked())
                createCamisaBuilder(view, out builder, out director);
            else
                createPantalonBuilder(view, out builder, out director);
            if (view.isPremiumChecked())
                director.makePremium();
            else
                director.makeStandard();
            return builder.getResult();
        }

        private static void createCamisaBuilder(IViewCotizador view, out IPrendaBuilder builder, out PrendaDirector director)
        {
            List<Model.Enums.PrendaSubType> subTypes = new List<Model.Enums.PrendaSubType>();
            if (view.isCuelloMaoChecked())
                subTypes.Add(Model.Enums.PrendaSubType.CuelloMao);
            else
                subTypes.Add(Model.Enums.PrendaSubType.CuelloComun);
            if (view.isMangaCortaChecked())
                subTypes.Add(Model.Enums.PrendaSubType.MangaCorta);
            else
                subTypes.Add(Model.Enums.PrendaSubType.MangaLarga);
            builder = new Model.Builders.CamisaBuilder();
            director = new Model.Director.PrendaDirector(builder, subTypes);
        }

        private static void createPantalonBuilder(IViewCotizador view, out IPrendaBuilder builder, out PrendaDirector director)
        {
            List<Model.Enums.PrendaSubType> subTypes = new List<Model.Enums.PrendaSubType>();
            if (view.isChupinChecked())
                subTypes.Add(Model.Enums.PrendaSubType.Chupin);
            else
                subTypes.Add(Model.Enums.PrendaSubType.Comun);
            builder = new Model.Builders.PantalonBuilder();
            director = new Model.Director.PrendaDirector(builder, subTypes);
        }
    }
}
