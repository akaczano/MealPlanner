using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanning {
    public class Ingredient {

        public string Name { get; set; }

        public UOMClass UOMClass { get; set; }

        public StoreSection Section { get; set; } = 0;

        public override string ToString() {
            return Name;
        }
    }

    public enum UOMClass {
        VOLUME = 0, COUNT = 1, WEIGHT = 2
    }

    public enum StoreSection {
        PRODUCE, DAIRY, DELI, MEAT
    }

    public class UOM {
        public UOMClass Class { get; set; }
        public string Name { get; set; }
        public UOM Base { get; set; }
        public double ConversionFactor { get; set; }
    
        public string Abbreviation { get; set; }

        public override string ToString() {
            return Name;
        }
        

        public static UOM ValueOf(string name) {
            return UOMList.Where(u => u.Name == name).First();
        }

        static UOM cup = new UOM() {
            Class = UOMClass.VOLUME,
            Name = "Cup",
            Base = null,
            ConversionFactor = 1,
            Abbreviation = "C"
        };

        static UOM tablespoon = new UOM() {
            Class = UOMClass.VOLUME,
            Name = "Tablespoon",
            Base = cup,
            ConversionFactor = 0.0625,
            Abbreviation = "tbsp."
        };
        static UOM teaspoon = new UOM() {
            Class = UOMClass.VOLUME,
            Name = "Teaspoon",
            Base = cup,
            ConversionFactor = 0.0208333,
            Abbreviation = "tsp."
        };
        static UOM each = new UOM() {
            Class = UOMClass.COUNT,
            Name = "Each",
            Base = null,
            ConversionFactor = 1,
            Abbreviation = ""
        };
        static UOM pound = new UOM() {
            Class = UOMClass.WEIGHT,
            Name = "Pound",
            Base = null,
            ConversionFactor = 1,
            Abbreviation = "lb."
        };
        static UOM ounce = new UOM() {
            Class = UOMClass.WEIGHT,
            Name = "Ounce",
            Base = pound,
            ConversionFactor = 0.0625,
            Abbreviation = "Oz."
        };
        public static UOM[] UOMList = {
                    cup, tablespoon, teaspoon, each, pound, ounce
                };
        public static UOM GetBaseUOM(UOMClass type) {
            switch (type) {
                case UOMClass.COUNT:
                    return each;
                case UOMClass.VOLUME:
                    return cup;
                case UOMClass.WEIGHT:
                    return pound;
                default:
                    return null;
            }
        }

        public static UOM[] GetUOMs(UOMClass type) {
            switch (type) {
                case UOMClass.COUNT:
                    return new UOM[] { each };
                case UOMClass.VOLUME:
                    return new UOM[] { cup, tablespoon, teaspoon };
                case UOMClass.WEIGHT:
                    return new UOM[] { pound, ounce };
                default:
                    return null;
            }
        }


    }

}
