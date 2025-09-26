using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsDBZ
{
    class Database
    {
        public static List<Card> GetCards()
        {
            List<Card> maze = new List<Card>
            {
                //Id, atk, def, title
                new Card(8, 70, 10, new List<int>{1}, "la furia de vegeta", "vegeta llega a la tierra en busca de kakaroto (goku) y trata de convencerlo para que se una a el."),
                new Card(9, 70, 30, new List<int>{3}, "super velocidad", "gracias a años de entrenamiento, goku es capaz de trasladarse a la velocidad de la luz."),
                new Card(11, 60, 10, new List<int>{1}, "el conquistador", "freezer esta dispuesto a conquistar el universo entero sin importarle quien se interponga en su camino."),
                new Card(12, 60, 20, new List<int>{3}, "la ira de goku", "si bien goku es un ser extremadamente bondadoso y divertido, no es bueno hacerlo enojar."),
                new Card(13, 50, 10, new List<int>{1}, "ataque de energía", "goku es capaz de generar una gran cantidad de energia y dirigirla contra su adversario."),
                new Card(15, 50, 30, new List<int>{4}, "kame hame ha", "esta tecnica fue creada por mutenroshi, a quien le llevo mas de 50 años perfeccionarla."),
                new Card(17, 40, 10, new List<int>{2}, "choque de titanes", "freezer y goku, transformado en supar saiyan, se encuentran en un duro combate."),
                new Card(18, 70, 10, new List<int>{4}, "revivir", "busca en tu cementerio y vuelve una carta a tu mano (no esfera). luego descartar una carta."),
                new Card(19, 40, 30, new List<int>{7}, "llega trunks", "desde el futuro, un extraño personaje llega a la tierra a avisar a los guerreros z de un peligro inminente."),
                new Card(20, 30, 40, new List<int>{2}, "androide a-18", "si ataca junto a otro androide los dos pueden ser bajados con una esfera (la de cualquiera de ellos)."),
                new Card(21, 30, 50, new List<int>{4}, "androide a-17", "si ataca junto a otro androide los dos pueden ser bajados con una esfera (la de cualquiera de ellos)."),
                new Card(22, 30, 60, new List<int>{6}, "androide a-16", "si ataca junto a otro androide los dos pueden ser bajados con una esfera (la de cualquiera de ellos)."),
                new Card(24, 20, 30, new List<int>{2}, "cell el implacable", "cell no dudara en destruir a quien sea necesario para absorber su energia y hacerse asi mas poderoso."),
                new Card(26, 20, 50, new List<int>{7}, "campo de energia", "la energia puede ser usada de muchas maneras. el campo de energia, aunque no genera mucho daño, suele ser efectivo."),
                new Card(28, 20, 70, new List<int>{7}, "descarga de energia", "vegeta genera una poderosa descarga de energia."),
                new Card(30, 10, 50, new List<int>{5}, "mister satan", "en la tierra todos piensan que mister satan es un verdadero heroe y un gran guerrero."),
                new Card(32, 10, 70, new List<int>{7}, "gohan", "entrenado por picoro, gohan se transformo rapidamente en un gran guerrero saiyan."),
                new Card(33, 70, 10, new List<int>{1}, "vegeta super saiyan", "vegeta lucha internamente entre el bien y el mal. es uno de los personajes mas poderosos de la saga."),
                new Card(34, 70, 30, new List<int>{3}, "explosion de energia", "la ira de goku ha generado una terrible explosion de energia."),
                new Card(36, 60, 10, new List<int>{1}, "trunks", "trunks viene de un futuro alternativo, donde la tierra ha sufrido terribles acontecimientos."),
                new Card(37, 60, 20, new List<int>{3}, "goku y sus amigos", "cuando las cosas se ponen dificiles, lo mejor es unir fuerzas."),
                new Card(39, 50, 10, new List<int>{1}, "lucha de colosos", "goku y cell se enfrentan en una batalla sin igual.e"),
                new Card(40, 70, 20, new List<int>{4}, "kame hame ha nivel 2", "esta es una de las mas potentes tecnicas utilizadas por goku y su familia."),
                new Card(41, 50, 20, new List<int>{6}, "embestida", "este ataque no puede ser bloqueado"),
                new Card(42, 40, 10, new List<int>{2}, "gohan super saiyan 2", "el poderoso gohan alcanzo el nivel de super saiyan a corta edad para sorpresa de goku y vegeta."),
                new Card(44, 40, 30, new List<int>{7}, "yamcha", "aunque no tenga los poderes de un saiyan, yamcha es un guerrero muy valiente y leal a sus amigos."),
                new Card(45, 30, 40, new List<int>{2}, "el poder de gohan", "gracias a horas de entrenamiento en la capsula del tiempo junto a goku, gohan alcanza muchisimo poder."),
                new Card(47, 30, 60, new List<int>{6}, "golpe de gracia", "tras una dura pelea, goku se despide de su derrotado adversario."),
                new Card(49, 20, 30, new List<int>{2}, "rayos de energia", "vegeta lanza un terrible ataque utilizando su energia.")
            };
            return maze;
        }
    }
}
